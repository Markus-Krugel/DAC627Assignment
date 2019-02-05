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

        string m_tempPassword;
        string m_tempUsername;
        string m_tempEmail;

        List<bool> m_isInfoFilledOutCorrectly = new List<bool> { false, false, false, false, false, false };

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
                        m_tempUsername = txtSender.Text;
                        lblErrorUserName.Hide();
                        m_isInfoFilledOutCorrectly[0] = true;
                    }
                    else
                    {
                        lblErrorUserName.Show();
                        m_isInfoFilledOutCorrectly[0] = false;
                    }
                    break;
                case "Email":
                    if (txtSender.Text.Contains('@') && formMain.UsersAccounts.RetrieveUserData(txtSender.Text) == null)
                    {
                        m_tempEmail = txtSender.Text;
                        lblErrorEmail.Hide();
                        m_isInfoFilledOutCorrectly[1] = true;
                    }
                    else
                    {
                        lblErrorEmail.Show();
                        m_isInfoFilledOutCorrectly[1] = false;
                    }
                    break;
                case "ConfirmEmail":
                    if(txtSender.Text != m_tempEmail)
                    {
                        lblErrorConfirmEmail.Show();
                        m_isInfoFilledOutCorrectly[2] = false;
                    }
                    else
                    {
                        lblErrorConfirmEmail.Hide();
                        m_isInfoFilledOutCorrectly[2] = true;
                    }
                    break;
                case "Password":
                    m_tempPassword = txtSender.Text;
                    m_isInfoFilledOutCorrectly[3] = true;
                    break;
                case "ConfirmPassword":
                    if(m_tempPassword != txtSender.Text)
                    {
                        lblErrorConfirmPassword.Show();
                        m_isInfoFilledOutCorrectly[4] = false;
                    }
                    else
                    {
                        lblErrorConfirmPassword.Hide();
                        m_isInfoFilledOutCorrectly[4] = true;
                    }
                    break;

                default:
                    break;
            }

        }

        private void btn_join_click(object sender, EventArgs e)
        {
            foreach (bool item in m_isInfoFilledOutCorrectly)
            {
                if (item == false)
                {
                    return;
                }
            }
            
            UsersAccounts.UserData  m_userData = new UsersAccounts.UserData
            {
                m_userName = m_tempUsername,
                m_emailAddress = m_tempEmail
            };
            m_userData.OneTimeSetUserID(5);
            m_userData.SetPassword(m_tempPassword);
            formMain.UsersAccounts.AddUser(m_userData);
            formMain.ChangeToPage(FormMain.Pages.HomePage);
            this.Hide();
        }

        private void chkTermsConditions_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;
            if(checkBox.Checked == true)
            {
                m_isInfoFilledOutCorrectly[5] = true;
            }
            else
            {
                m_isInfoFilledOutCorrectly[5] = false;
            }
        }
    }
}
