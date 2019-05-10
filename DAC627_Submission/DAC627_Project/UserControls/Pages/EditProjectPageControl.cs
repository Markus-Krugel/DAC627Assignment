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
        private int? _curUserProjectID;
        private string _thumbNailPic = null;

        public EditProjectPageControl(FormMain form, int? curUserProjectID)
        {
            InitializeComponent();
            formMain = form;
            _curUserProjectID = curUserProjectID;

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
                    picThumbnail.ImageLocation = _curUserProject.GetThumbNail();

                    _userProject.SetProjectTitle(_curUserProject.GetProjectTitle());
                    _userProject.SetProjectType(_curUserProject.GetProjectType());
                    _userProject.SetNotes(_curUserProject.GetNotes());
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
            _userProject.SetProjectType((ProjectType)cboProjectType.SelectedIndex);
        }

        private void btnConfirmChanges_Click(object sender, EventArgs e)
        {
            bool errorDetected = false;
            if (txtTitle.Text == string.Empty || txtTitle.Text == "Title")
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

                DataBaseAccess dataBase = new DataBaseAccess();
                dataBase.StartConnection();
                if (_curUserProject.GetProjectTitle() != _userProject.GetProjectTitle())
                    dataBase.ChangeProjectName((int)_curUserProjectID, _userProject.GetProjectTitle());

                if (_curUserProject.GetProjectType() != _userProject.GetProjectType())
                    dataBase.ChangeProjectType((int)_curUserProjectID, _userProject.GetProjectType());

                if (_curUserProject.GetNotes() != _userProject.GetNotes())
                    dataBase.ChangeProjectDescription((int)_curUserProjectID, _userProject.GetNotes());

                if (_thumbNailPic != null)
                    dataBase.ChangeProjectThumbnail((int)_curUserProjectID, _thumbNailPic);

                dataBase.CloseConnection();

                formMain.curSelectedUserProjectID = _curUserProjectID;
                formMain.ChangeToPage(FormMain.Pages.ViewProjectPage);
            }
        }

        private void btnUploadThumbnail_Click(object sender, EventArgs e)
        {
            string _uploadedPic = HelperTools.LoadFromFile("Choose Image", "PNG File (*.png)|*.png|JPEG File (*.jpg)|*.jpg");
            _uploadedPic = HelperTools.AddFileToStorage(_uploadedPic, (int)_curUserProject.GetAuthor().GetUserID(), _curUserProjectID);
            _thumbNailPic = _uploadedPic;
            picThumbnail.ImageLocation = _thumbNailPic;
        }
    }
}
