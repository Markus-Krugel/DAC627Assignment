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
    public partial class CreateAccountPageControl : UserControl
    {
        FormMain formMain;

        public CreateAccountPageControl(FormMain form)
        {
            InitializeComponent();

            formMain = form;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            TextBox txtInput = (TextBox)sender;
            formMain.RemoveGrayText(txtInput, txtInput.AccessibleName);
            txtInput.PasswordChar = '•';
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            TextBox txtInput = (TextBox)sender;
            if (formMain.CheckEmpty(txtInput, txtInput.AccessibleName))
            {
                txtInput.PasswordChar = '\0';
            }
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            TextBox txtInput = (TextBox)sender;
            formMain.RemoveGrayText((TextBox)sender, txtInput.AccessibleName);
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            TextBox txtInput = (TextBox)sender;
            formMain.CheckEmpty((TextBox)sender, txtInput.AccessibleName);
        }
    }
}
