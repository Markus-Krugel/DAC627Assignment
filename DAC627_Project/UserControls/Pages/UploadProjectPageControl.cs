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
    public partial class UploadProjectPageControl : UserControl
    {
        FormMain formMain;
        UserProject _userProject;

        public UploadProjectPageControl(FormMain form)
        {
            InitializeComponent();
            cboUploadType.SelectedIndex = 1;
            formMain = form;
            if (formMain.UsersAccounts.GetCurrentUser() != null)
            {
                _userProject = new UserProject(formMain.UsersAccounts.GetCurrentUser());
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

        private void btnChooseAsset_Click(object sender, EventArgs e)
        {
            if(cboProjectType.Text != string.Empty)
            {
                HelperTools.LoadFromFile("Upload Project", "ZIP File (*.zip)|*.zip");
            }
        }

        private void cboUploadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUploadType.Text == "Asset")
            {
                formMain.currentPage.Hide();
                formMain.ChangeToPage(FormMain.Pages.UploadAssetPage);
            }
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

        private void btnUploadAsset_Click(object sender, EventArgs e)
        {
            bool errorDetected = false;
            if (txtTitle.Text == string.Empty)
            {
                lblErrorTitle.Show();
                errorDetected = true;
            }
            if (cboProjectType.SelectedIndex < 0)
            {
                lblErrorAssetType.Show();
                errorDetected = true;
            }

            if (errorDetected == false)
            {
                //formMain.curSelectedUserProject = _userProject;
                DataBaseAccess dataBase = new DataBaseAccess();
                dataBase.StartConnection();
                dataBase.AddProject(_userProject.GetProjectTitle(), _userProject.GetProjectType(), _userProject.GetNotes(), (int)formMain.UsersAccounts.GetCurrentUser().GetUserID(), ProjectTag.Game, ProjectStatus.In_Development);
                dataBase.CloseConnection();

                Hide();
                formMain.ChangeToPage(FormMain.Pages.EditProjectPage);
            }
        }
    }
}
