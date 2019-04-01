using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DAC627_Project
{
    static class HelperTools
    {

        static public string LoadFromFile(string titleName = "Choose File", string filter = "All files (*.*)|*.*", string initialDirectory = "c:\\")
        {
            string filePath = string.Empty;
            string fileContent = string.Empty;
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = titleName;
                openFileDialog.Filter = filter;
                openFileDialog.InitialDirectory = initialDirectory;
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //ADD YOUR CODE HERE  

                    //Get the path of specified file
                    return filePath = openFileDialog.FileName;

                    using (StreamReader reader = new StreamReader(openFileDialog.OpenFile()))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
                else
                {
                    MessageBox.Show("No File Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return filePath;
                }
            }
        }

        static public void SaveFromFile(string sourcePath)
        {
            string destinationPath = null;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Save";
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    destinationPath = saveFileDialog.FileName;
                }
            }
            if (destinationPath != null)
            {
                string sourceName = Path.GetFileName(sourcePath);
                string sourceDir = Path.GetDirectoryName(sourcePath);
                string dirPath = Path.GetDirectoryName(destinationPath);
                string dirName = Path.GetFileName(destinationPath) + Path.GetExtension(sourceName);
                CopyFile(sourceDir, dirPath, sourceName, dirName);
            }
        }

        static public void CopyFile(string sourcePath, string targetPath, string fileName, string newFileName = null)
        {
            //string fileName = "";
            //string sourcePath = @"C:\Users\Public\TestFolder";
            //string targetPath = @"C:\Users\Public\TestFolder\SubDir";

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = null;
            if (newFileName == null)
            {
                destFile = System.IO.Path.Combine(targetPath, fileName);

            }
            else
            {
                destFile = System.IO.Path.Combine(targetPath, newFileName);
            }


            if (System.IO.Directory.Exists(sourcePath))
            {
                System.IO.File.Copy(sourceFile, destFile, true);
            }
            else
            {
                MessageBox.Show("Source path does not exist!");
            }
        }

        static public string AddFileToStorage(string sourceFilePath, int userID, int? assetID = null)
        {
            string targetPath = @"../../Resources/Users";

            targetPath = Path.Combine(targetPath, "User_" + userID, "Assets", "Asset_" + assetID);

            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            string dirPath = Path.GetDirectoryName(sourceFilePath);
            string fileName = Path.GetFileName(sourceFilePath);
            CopyFile(dirPath, targetPath, fileName);

            return Path.Combine(targetPath, fileName);
        }

        static public List<AssetButton> CreateAssetButtons(Point startingLocation, FormMain formMain, UserControl curPage ,int numberOfAssets = 2, int amountPerRow = 2, List<UserAsset> userAssets = null, List<UserProject> userProjects = null)
        {
            const int _distancePerAssetButtonX = 248;
            const int _distancePerAssetButtonY = 280;
            int rowLimit = 0;
            //This is done so that the value inserted makes sense in our minds, but translates well in the code 
            amountPerRow--; 

            List<AssetButton> listAssetButtons = new List<AssetButton>();
            
            

            for (int i = 0; i < numberOfAssets; i++)
            {
                AssetButton newAssetButton;
                if (userAssets != null)
                {
                    //create user assets
                    newAssetButton = new AssetButton(formMain, userAssets[i].GetID(), true);
                    newAssetButton.SetName(userAssets[i].GetAssetTitle());
                    newAssetButton.SetPicturePath(userAssets[i].GetThumbNail());
                }
                else if (userProjects != null)
                {
                    //Create user projects
                    newAssetButton = new AssetButton(formMain, userProjects[i].GetID(), false);
                    newAssetButton.SetName(userProjects[i].GetProjectTitle());
                    newAssetButton.SetPicturePath(userProjects[i].GetThumbNail());
                }
                else
                {
                    return null;
                }


                newAssetButton.Location = new Point(startingLocation.X + (_distancePerAssetButtonX * rowLimit), startingLocation.Y);

                if (rowLimit < amountPerRow)
                {
                    rowLimit++;
                }
                else
                {
                    startingLocation.Y += _distancePerAssetButtonY;
                    rowLimit = 0;
                }

                newAssetButton.Show();
                curPage.Controls.Add(newAssetButton);
                listAssetButtons.Add(newAssetButton);

            }

            return listAssetButtons;
        }
    }
}
