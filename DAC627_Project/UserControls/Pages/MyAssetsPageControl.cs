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
        FormMain formMain;
       
       
        Point defaultLocation = new Point(48, 104);
        const int amountPerRow = 5;
        const int distancePerAssetButtonX = 248;
        const int distancePerAssetButtonY = 280;

        List<UserAsset> curUserAssets = null;

        public MyAssetsPageControl(FormMain form)
        {
            InitializeComponent();
            formMain = form;
            curUserAssets = formMain.UsersAccounts.GetCurrentUser().GetUserAssets();

            if (curUserAssets != null)
            {
                HelperTools.CreateAssetButtons(new Point(48, 104), formMain, this, curUserAssets.Count, 5, curUserAssets);
            }
        }

        
    }
}
