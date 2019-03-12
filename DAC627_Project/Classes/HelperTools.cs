﻿using System;
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

        static public List<AssetButton> CreateAssetButtons(Point startingLocation, FormMain formMain, UserControl curPage ,int numberOfAssets = 2, int amountPerRow = 2, List<UserAsset> userAssets = null, List<UserProject> userProjects = null)
        {
            const int _distancePerAssetButtonX = 248;
            const int _distancePerAssetButtonY = 280;
            int rowLimit = 0; 

            List<AssetButton> listAssetButtons = new List<AssetButton>();
            
            

            for (int i = 0; i < numberOfAssets; i++)
            {
                AssetButton newAssetButton;
                if (userAssets != null)
                {
                    newAssetButton = new AssetButton(formMain, userAssets[i].GetID(), true);
                    newAssetButton.SetName(userAssets[i].GetAssetTitle());
                }
                else if (userProjects != null)
                {
                    newAssetButton = new AssetButton(formMain, userProjects[i].GetID(), false);
                    newAssetButton.SetName(userProjects[i].GetProjectTitle());
                }
                else
                {
                    return null;
                }

                

                if (rowLimit < amountPerRow)
                {
                    newAssetButton.Location = new Point(startingLocation.X + (_distancePerAssetButtonX * rowLimit), startingLocation.Y);
                    rowLimit++;
                }
                else
                {
                    startingLocation.Y += _distancePerAssetButtonY;
                    rowLimit = 0;
                    newAssetButton.Location = new Point(startingLocation.X + (_distancePerAssetButtonX * rowLimit), startingLocation.Y);
                }
                newAssetButton.Show();

                curPage.Controls.Add(newAssetButton);
                listAssetButtons.Add(newAssetButton);
                
            }

            return listAssetButtons;
        }
    }
}