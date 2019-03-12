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
    public partial class AccountPageControl : UserControl
    {
        FormMain formMain;
        UsersAccounts.UserData _currentUser;


        public AccountPageControl(FormMain form)
        {
            InitializeComponent();
            formMain = form;
            _currentUser = formMain.UsersAccounts.GetCurrentUser();

            txtUserName.Text = _currentUser.userName;
            txtEmail.Text = _currentUser.emailAddress;
            txtName.Text = _currentUser.name;
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            TextBox txtInput = (TextBox)sender;
            formMain.RemoveGrayText((TextBox)sender);
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            TextBox txtInput = (TextBox)sender;
            formMain.CheckEmpty((TextBox)sender);
        }

        private void btnViewMyAssets_Click(object sender, EventArgs e)
        {
            formMain.ChangeToPage(FormMain.Pages.MyAssetsPage);
        }

        private void btnUploadAsset_Click(object sender, EventArgs e)
        {
            formMain.ChangeToPage(FormMain.Pages.UploadAssetPage);
        }

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            formMain.ChangeToPage(FormMain.Pages.UploadProjectPage);
        }
    }
}