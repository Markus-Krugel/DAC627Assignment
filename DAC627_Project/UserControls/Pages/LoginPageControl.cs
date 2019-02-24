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
    public partial class LoginPageControl : UserControl
    {
        FormMain formMain;
        public LoginPageControl(FormMain form)
        {
            InitializeComponent();
            formMain = form;
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            formMain.RemoveGrayText(txtUserName);
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

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            formMain.CheckEmpty(txtUserName);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UsersAccounts.UserData m_user = formMain.UsersAccounts.RetrieveUserData(txtUserName.Text);

            lblErrorUsername.Hide();
            lblErrorPassword.Hide();

            if (m_user != null)
            {
                if (m_user.IsValidPassword(txtPassword.Text))
                {
                    formMain.UsersAccounts.SetCurrentUser(m_user);
                    formMain.ChangeToPage(FormMain.Pages.AccountPage);
                    this.Hide();
                    return;
                }
                lblErrorPassword.Show();
                return;
            }
            lblErrorUsername.Show();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            formMain.ChangeToPage(FormMain.Pages.CreateAccountPage);
            this.Hide();
        }
    }
}
