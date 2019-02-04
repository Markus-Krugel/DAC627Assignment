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
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            formMain.RemoveGrayText(txtUserName);
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            formMain.CheckEmpty(txtUserName);
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




        
    }
}
