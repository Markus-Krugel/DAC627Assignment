﻿using System;
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
        List<UserProject> curUserProjects = null;

        public MyAssetsPageControl(FormMain form, string message)
        {
            InitializeComponent();
            formMain = form;
            DataBaseAccess dataBase = new DataBaseAccess();
            dataBase.StartConnection();
            if (message == "project")
            {
                curUserProjects = dataBase.getOwnedProjectsOfUser((int)formMain.UsersAccounts.GetCurrentUser().GetUserID());
            }
            else if (message == "asset")
            {
                curUserAssets = dataBase.getAssetsOfUser((int)formMain.UsersAccounts.GetCurrentUser().GetUserID());
            }
            dataBase.CloseConnection();

            if (curUserAssets != null && message == "asset") 
            {
                HelperTools.CreateAssetButtons(new Point(48, 104), formMain, this, curUserAssets.Count, 5, curUserAssets);
            }
            else if (curUserProjects != null && message == "project")
            {
                HelperTools.CreateAssetButtons(new Point(48, 104), formMain, this, curUserProjects.Count, 5, null, curUserProjects);
            }
        }

        
    }
}
