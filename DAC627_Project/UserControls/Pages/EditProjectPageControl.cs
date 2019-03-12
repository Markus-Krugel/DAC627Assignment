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
    public partial class EditProjectPageControl : UserControl
    {
        FormMain formMain;
        private UserProject _userProject = new UserProject(null);
        private UserProject _curUserProject = null;

        public EditProjectPageControl(FormMain form, int? curUserProjectID)
        {
            InitializeComponent();
            formMain = form;
            if (formMain.UsersAccounts.GetCurrentUser() != null)
            {
                DataBaseAccess dataBase = new DataBaseAccess();
                dataBase.StartConnection();
                _curUserProject = dataBase.getProject((int)curUserProjectID);
                dataBase.CloseConnection();

                if (curUserProjectID == null || _curUserProject == null)
                {
                    MessageBox.Show("Error: Asset Not Found");
                }
                else
                {
                    txtTitle.Text = _curUserProject.GetProjectTitle();
                    cboProjectType.SelectedIndex = (int)_curUserProject.GetProjectType();
                    txtNotes.Text = _curUserProject.GetNotes();
                }
            }
            else
            {
                MessageBox.Show("Error: No user logged in");
            }
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            formMain.RemoveGrayText((TextBox)sender);
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            formMain.CheckEmpty((TextBox)sender);
        }

        private void TextInput(object sender, EventArgs e)
        {
            if (((TextBox)sender) == txtTitle)
            {
                _userProject.SetProjectTitle(txtTitle.Text);
            }
            else if (((TextBox)sender) == txtNotes)
            {
                _userProject.SetNotes(txtNotes.Text);
            }
            txt_Leave(sender, e);
        }

        private void DropDownInput(object sender, EventArgs e)
        {
            if (((ComboBox)sender) == cboProjectType)
            {
                _userProject.SetProjectType((ProjectType)cboProjectType.SelectedIndex);
            }
        }

        private void btnConfirmChanges_Click(object sender, EventArgs e)
        {
            bool errorDetected = false;
            if (txtTitle.Text == string.Empty)
            {
                lblErrorTitle.Show();
                errorDetected = true;
            }
            if (cboProjectType.SelectedIndex < 0)
            {
                lblErrorProjectType.Show();
                errorDetected = true;
            }

            if (errorDetected == false)
            {
                _curUserProject.SetProjectTitle(_userProject.GetProjectTitle());
                _curUserProject.SetProjectType(_userProject.GetProjectType());
                _curUserProject.SetNotes(_userProject.GetNotes());

            }
        }
    }
}
