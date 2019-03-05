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
            HelperTools.CreateAssetButtons(new Point(152, 160), this, 3, 2);
            HelperTools.CreateAssetButtons(new Point(700, 160), this, 2, 2);
            
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
                    this.Hide();
                    return;
                }                              
            }
            formMain.ChangeToPage(FormMain.Pages.LoginPage);
            this.Hide();
        }
    }
}
