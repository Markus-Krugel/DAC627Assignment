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
        
        private string _tempPassword;
        private string _tempUsername;
        private string _tempEmail;
        private string _tempName;

        private List<bool> _isInfoFilledOutCorrectly = new List<bool> { false, false, false, false, false, false, false };

        public CreateAccountPageControl(FormMain form)
        {
            InitializeComponent();

            formMain = form;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            TextBox txtInput = (TextBox)sender;
            formMain.RemoveGrayText(txtInput);
            txtInput.PasswordChar = '•';
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            SaveData(sender, e);
            TextBox txtInput = (TextBox)sender;
            if (formMain.CheckEmpty(txtInput))
            {
                txtInput.PasswordChar = '\0';
            }
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            TextBox txtInput = (TextBox)sender;
            formMain.RemoveGrayText((TextBox)sender);
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            SaveData(sender, e);
            TextBox txtInput = (TextBox)sender;
            formMain.CheckEmpty((TextBox)sender);
        }

        private void SaveData(object sender, EventArgs e)
        {
            var txtSender = sender as TextBox;

            switch (txtSender.Tag)
            {
                case "Username":
                    if (formMain.UsersAccounts.RetrieveUserData(txtSender.Text) == null)
                    {
                        _tempUsername = txtSender.Text;
                        lblErrorUserName.Hide();
                        _isInfoFilledOutCorrectly[0] = true;
                    }
                    else
                    {
                        lblErrorUserName.Show();
                        _isInfoFilledOutCorrectly[0] = false;
                    }
                    break;
                case "Email":
                    if (txtSender.Text.Contains('@') && formMain.UsersAccounts.RetrieveUserData(txtSender.Text) == null)
                    {
                        _tempEmail = txtSender.Text;
                        lblErrorEmail.Hide();
                        _isInfoFilledOutCorrectly[1] = true;
                    }
                    else
                    {
                        if (!txtSender.Text.Contains('@'))
                        {
                            lblErrorEmail.Text = "Error, not an email address";
                        }
                        else
                        {
                            lblErrorEmail.Text = "Error, email already exists";
                        }
                        lblErrorEmail.Show();
                        _isInfoFilledOutCorrectly[1] = false;
                    }
                    break;
                case "ConfirmEmail":
                    if(txtSender.Text != _tempEmail)
                    {
                        lblErrorConfirmEmail.Show();
                        _isInfoFilledOutCorrectly[2] = false;
                    }
                    else
                    {
                        lblErrorConfirmEmail.Hide();
                        _isInfoFilledOutCorrectly[2] = true;
                    }
                    break;
                case "Password":
                    if(txtSender.Text.Count() >= 6 && txtSender.Text.Count() < 12)
                    {
                        _tempPassword = txtSender.Text;
                        _isInfoFilledOutCorrectly[3] = true;
                        lblErrorPassword.Hide();
                    }
                    else
                    {
                        _isInfoFilledOutCorrectly[3] = false;
                        lblErrorPassword.Show();
                    }
                    break;
                case "ConfirmPassword":
                    if(_tempPassword != txtSender.Text)
                    {
                        lblErrorConfirmPassword.Show();
                        _isInfoFilledOutCorrectly[4] = false;
                    }
                    else
                    {
                        lblErrorConfirmPassword.Hide();
                        _isInfoFilledOutCorrectly[4] = true;
                    }
                    break;
                case "FullName":
                    if (txtSender.Text.Count() >= 1 && txtSender.Text.Count() < 12)
                    {
                        _tempName = txtSender.Text;
                        _isInfoFilledOutCorrectly[5] = true;
                        lblErrorName.Hide();
                    }
                    else
                    {
                        _isInfoFilledOutCorrectly[5] = false;
                        lblErrorName.Show();
                    }
                    break;

                default:
                    break;
            }

        }

        private void btnJoin_click(object sender, EventArgs e)
        {
            foreach (bool item in _isInfoFilledOutCorrectly)
            {
                if (item == false)
                {
                    return;
                }
            }

            UsersAccounts.UserData userData = new UsersAccounts.UserData
            {
                userName = _tempUsername,
                emailAddress = _tempEmail,
                name = _tempName
            };
            userData.OneTimeSetUserID(5);
            userData.SetPassword(_tempPassword);
            formMain.UsersAccounts.AddUser(userData);
            formMain.ChangeToPage(FormMain.Pages.HomePage);
        }

        private void chkTermsConditions_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;
            if(checkBox.Checked == true)
            {
                _isInfoFilledOutCorrectly[6] = true;
            }
            else
            {
                _isInfoFilledOutCorrectly[6] = false;
            }
        }
    }
}
