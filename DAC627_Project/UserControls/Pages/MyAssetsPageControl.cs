using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAC627_Project
{
    public partial class MyAssetsPageControl : UserControl
    {
        Form formMain;

       
        Point defaultLocation = new Point(48, 104);
        const int amountPerRow = 5;
        const int distancePerAssetButtonX = 248;
        const int distancePerAssetButtonY = 280;

        public MyAssetsPageControl(Form form)
        {
            InitializeComponent();
            formMain = form;
            CreateTabs(10);
        }

        List<AssetButton> CreateTabs(int numberOfAssets)
        {
            List<AssetButton> listAssetButtons = new List<AssetButton>();

            for (int i = 0; i < numberOfAssets; i++)
            {
                AssetButton newAssetButton = new AssetButton();
                newAssetButton.Name = "newAssetButton" + i;
                if (i < amountPerRow)
                {
                    newAssetButton.Location = new Point(defaultLocation.X+(distancePerAssetButtonX*i), defaultLocation.Y);
                }
                else
                {
                    newAssetButton.Location = new Point(defaultLocation.X + (distancePerAssetButtonX * (i-amountPerRow)), defaultLocation.Y+distancePerAssetButtonY);
                }

                newAssetButton.Show();
                formMain.Controls.Add(newAssetButton);

                listAssetButtons.Add(newAssetButton);
            }

            return listAssetButtons;
        }

        
    }
}
