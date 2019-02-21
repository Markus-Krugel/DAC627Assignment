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

        static public List<AssetButton> CreateTabs(int numberOfAssets, UserControl form)
        {
            Point _defaultLocation = new Point(48, 104);
            const int _amountPerRow = 5;
            const int _distancePerAssetButtonX = 248;
            const int _distancePerAssetButtonY = 280;

            List<AssetButton> listAssetButtons = new List<AssetButton>();

            for (int i = 0; i < numberOfAssets; i++)
            {
                AssetButton newAssetButton = new AssetButton();
                newAssetButton.Name = "newAssetButton" + i;
                if (i < _amountPerRow)
                {
                    newAssetButton.Location = new Point(_defaultLocation.X + (_distancePerAssetButtonX * i), _defaultLocation.Y);
                }
                else
                {
                    newAssetButton.Location = new Point(_defaultLocation.X + (_distancePerAssetButtonX * (i - _amountPerRow)), _defaultLocation.Y + _distancePerAssetButtonY);
                }

                newAssetButton.Show();
                form.Controls.Add(newAssetButton);

                listAssetButtons.Add(newAssetButton);
            }

            return listAssetButtons;
        }
    }
}
