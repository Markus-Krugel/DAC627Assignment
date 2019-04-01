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
    public partial class ViewAssetPageControl : UserControl
    {
        FormMain formMain;
        UserAsset _userAsset = null;
        UsersAccounts.UserData _curUserData;
        int? _userAssetID;

        public ViewAssetPageControl(FormMain form, int? userAssetID)
        {
            formMain = form;
            _userAssetID = userAssetID;

            DataBaseAccess dataBase = new DataBaseAccess();
            dataBase.StartConnection();
            _userAsset = dataBase.getAsset((int)userAssetID);
            dataBase.CloseConnection();

            _curUserData = formMain.UsersAccounts.GetCurrentUser();
            InitializeComponent();
            if (formMain.UsersAccounts.GetCurrentUser() != null)
            {
                if (_userAsset == null)
                {
                    formMain.ChangeToPage(FormMain.Pages.HomePage);
                }
                else
                {
                    if (_curUserData.GetUserID() == _userAsset.GetAuthor().GetUserID())
                    {
                        btnEdit.Show();
                    }
                }
            }

            galPictureGallery.SetToLarge();
            galPictureGallery.IsEditable(false);
            galPictureGallery.AddPicturesToGallery(_userAsset.GetPicturesPath());
            pictureBox1.ImageLocation = _userAsset.GetThumbNail();
            lblTitleDisplay.Text = _userAsset.GetAssetTitle();
            lblAssetTypeDisplay.Text = _userAsset.GetAssetType().ToString();
            lblSoftwareDisplay.Text = _userAsset.GetSoftwareUsed();
            lblPegiDisplay.Text = _userAsset.GetPegiRating().ToString();
            lblAssetStatusDisplay.Text = _userAsset.GetAssetStatus().ToString();
            lblCreatorDisplay.Text = _userAsset.GetAuthor().userName;
            lblDescription.Text = _userAsset.GetNotes();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            formMain.curSelectedAssetID = _userAsset.GetID();
            formMain.ChangeToPage(FormMain.Pages.EditAssetPage);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
           HelperTools.SaveFromFile(_userAsset.GetAssetPath());
        }
    }
}
