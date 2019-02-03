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
        Form foo;

        public HomePageControl()
        {
            InitializeComponent();
            //this.foo = form;
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
           // foo.RemoveGrayText(txtUserName, "User Name");
            
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            //foo.CheckEmpty(txtUserName, "User Name");
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            //foo.RemoveGrayText(txtPassword, "Password");
            txtPassword.PasswordChar = '•';
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            //if(foo.CheckEmpty(txtPassword, "Password"))
            //{
                txtPassword.PasswordChar = '\0';
           // }
        }




        
    }
}
