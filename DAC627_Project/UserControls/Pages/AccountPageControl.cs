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
    public partial class AccountPageControl : UserControl
    {
        FormMain formMain;
        UsersAccounts.UserData _currentUser;
        private bool isAccountInfoEditable = false;

        public AccountPageControl(FormMain form)
        {
            InitializeComponent();
            formMain = form;
            _currentUser = formMain.UsersAccounts.GetCurrentUser();

            txtUserName.Text = _currentUser.userName;
            txtEmail.Text = _currentUser.emailAddress;
            txtName.Text = _currentUser.fullName;
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
            formMain.ChangeToPage(FormMain.Pages.MyAssetsPage, "asset");
        }

        private void btnUploadAsset_Click(object sender, EventArgs e)
        {
            formMain.ChangeToPage(FormMain.Pages.UploadAssetPage);
        }

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            formMain.ChangeToPage(FormMain.Pages.UploadProjectPage);
        }

        private void btnViewMyProjects_Click(object sender, EventArgs e)
        {
            formMain.ChangeToPage(FormMain.Pages.MyAssetsPage, "project");
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            formMain.UsersAccounts.SetCurrentUser(null);
            formMain.ChangeToPage(FormMain.Pages.HomePage);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(!isAccountInfoEditable)
            {
                txtEmail.ReadOnly = false;
                txtName.ReadOnly = false;
                btnEdit.Text = "Confirm Changes!";
                isAccountInfoEditable = true;
            }
            else
            {
                txtEmail.ReadOnly = true;
                txtName.ReadOnly = true;
                DataBaseAccess dataBaseAccess = new DataBaseAccess();
                dataBaseAccess.StartConnection();
                if (txtEmail.Text.Contains('@') && formMain.UsersAccounts.RetrieveUserData(txtEmail.Text) == null)
                {
                    dataBaseAccess.ChangeUserEmail(_currentUser.userName, txtEmail.Text);

                }
                if (txtName.Text.Count() >= 1 && txtName.Text.Count() < 12)
                {
                    dataBaseAccess.ChangeUserFullName((int)_currentUser.GetUserID(), txtName.Text);
                }
                formMain.UsersAccounts.SetCurrentUser(dataBaseAccess.GetUser((int)_currentUser.GetUserID()));
                dataBaseAccess.CloseConnection();
                btnEdit.Text = "Edit User Information";
                isAccountInfoEditable = false;
            }
        }
    }
}
