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
    public partial class HomePageControl : UserControl
    {
        FormMain formMain;
        List<AssetButton> _projectButtons;
        List<AssetButton> _assetButtons;

        public HomePageControl(FormMain form)
        {
            InitializeComponent();
            formMain = form;
            if (formMain.UsersAccounts.GetCurrentUser() != null)
            {
                txtUserName.Hide();
                txtPassword.Hide();
                btnJoin.Hide();
                btnLogin.Hide();
            }

            //Used to create the asset 
            HelperTools.CreateAssetButtons(new Point(152, 160), formMain, this, 3, 2);
            HelperTools.CreateAssetButtons(new Point(700, 160), formMain, this, 2, 2);
          
            
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            formMain.RemoveGrayText((TextBox)sender);
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            formMain.CheckEmpty((TextBox)sender);
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            formMain.RemoveGrayText(txtPassword);
            txtPassword.PasswordChar = '•';
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (formMain.CheckEmpty(txtPassword))
            {
                txtPassword.PasswordChar = '\0';
            }
        }

        private void btn_CreateAnAccount_click(object sender, EventArgs e)
        {
            formMain.ChangeToPage(FormMain.Pages.CreateAccountPage);
            this.Hide();
        }

        private void btn_logIn_click(object sender, EventArgs e)
        {
            UsersAccounts.UserData m_user = formMain.UsersAccounts.RetrieveUserData(txtUserName.Text);

            if (m_user != null)
            {
                if (m_user.IsValidPassword(txtPassword.Text))
                {
                    formMain.UsersAccounts.SetCurrentUser(m_user);
                    formMain.ChangeToPage(FormMain.Pages.AccountPage);
                    return;
                }                              
            }
            formMain.ChangeToPage(FormMain.Pages.LoginPage);
        }

        private void txtSearchAsset_Enter(object sender, EventArgs e)
        {
            //DataBaseAccess data = new DataBaseAccess();
            //data.StartConnection();
            //List<UserAsset> userAssets = data.SearchAsset(txtSearchAsset.Text);
            //data.CloseConnection();
            //HelperTools.CreateAssetButtons(new Point(48, 104), formMain, this, userAssets.Count(), 1, userAssets, null);
            //txt_Leave(sender, e);
        }

        private void txtSearchAsset_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (_assetButtons != null)
                {
                    for (int i = 0; i < _assetButtons.Count; i++)
                    {
                        _assetButtons[i].Dispose();
                        this.Controls.Remove(_assetButtons[i]);
                    }
                }

                DataBaseAccess data = new DataBaseAccess();
                data.StartConnection();
                List<UserAsset> userAssets = data.SearchAsset(txtSearchAsset.Text);
                data.CloseConnection();
                _assetButtons = HelperTools.CreateAssetButtons(new Point(160, 150), formMain, this, userAssets.Count(), 2, userAssets);
            }
        }

        private void txtSearchProject_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_projectButtons != null)
                {
                    for (int i = 0; i < _projectButtons.Count; i++)
                    {
                        _projectButtons[i].Dispose();
                        this.Controls.Remove(_projectButtons[i]);
                    }
                }

                DataBaseAccess data = new DataBaseAccess();
                data.StartConnection();
                List<UserProject> userProjects = data.SearchProject(txtSearchProject.Text);
                data.CloseConnection();
                _projectButtons = HelperTools.CreateAssetButtons(new Point(720, 150), formMain, this, userProjects.Count(), 2, null, userProjects);
            }
        }
    }
}
