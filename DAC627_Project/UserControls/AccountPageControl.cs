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
        UsersAccounts.UserData? m_currentUser;


        public AccountPageControl(FormMain form)
        {
            InitializeComponent();
            formMain = form;
            m_currentUser = formMain.UsersAccounts.GetCurrentUser();

            txtUserName.Text = m_currentUser.Value.m_userName;
            txtEmail.Text = m_currentUser.Value.m_emailAddress;
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

    }
}
