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
    public partial class UploadAssetPageControl : UserControl
    {
        FormMain formMain;
        private UserAsset _userAsset;
        bool _assetUploaded = false;

        public UploadAssetPageControl(FormMain form)
        {
            InitializeComponent();
            formMain = form;
            cboUploadType.SelectedIndex = 0;
            if (formMain.UsersAccounts.GetCurrentUser() != null)
            {
                _userAsset = new UserAsset((UsersAccounts.UserData)formMain.UsersAccounts.GetCurrentUser());
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
            if(cboAssetType.Text != string.Empty)
            {
                string filter = string.Empty;

                switch (cboAssetType.SelectedIndex)
                {
                    case 0:
                    case 1:
                        filter = "PNG File (*.png) | *.png | JPEG File (*.jpg) | *.jpg";
                        break;
                    case 2:
                        filter = "GIF File (*.gif) | *.gif";
                        break;
                    case 3:
                    case 4:
                        filter = "FBX File (*.fbx)|*.fbx|OBJ File (*.obj)|*.obj|Maya File (*.mb)|*.mb|Maya File (*.ma)|*.ma|3ds Max File (*.max)|*.max|Cinema 4D File (*.c4d)|*.c4d";
                        break;
                    case 5:
                        filter = "WAVE file (*.wav)|*.wav|MP3 File (*.mp3)|*.mp3";
                        break;
                }

                _userAsset.SetAssetPath(HelperTools.LoadFromFile("Upload Asset", filter));
                _assetUploaded = true;
            }
            else
            {
                MessageBox.Show("cboAssetType = null");
            }
        }

        private void cboUploadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboUploadType.Text == "Project")
            {
                formMain.currentPage.Hide();
                formMain.ChangeToPage(FormMain.Pages.UploadProjectPage);
            }
        }


        private void TextInput(object sender, EventArgs e)
        {
            if (((TextBox)sender) == txtTitle)
            {
                _userAsset.SetAssetTitle(txtTitle.Text);
            }
            else if (((TextBox)sender) == txtSoftwareUsed)
            {
                _userAsset.SetSoftwareUsed(txtSoftwareUsed.Text);
            }
            else if (((TextBox)sender) == txtAssetStatus)
            {
                _userAsset.SetAssetStatus(txtAssetStatus.Text);
            }
            else if (((TextBox)sender) == txtNotes)
            {
                _userAsset.SetNotes(txtNotes.Text);
            }
            txt_Leave(sender, e);
        }

        private void DropDownInput(object sender, EventArgs e)
        {
            if (((ComboBox)sender) == cboAssetType)
            {
                _userAsset.SetAssetType((AssetType)cboAssetType.SelectedIndex);
            }
            else if (((ComboBox)sender) == cboPegi)
            {         
                _userAsset.SetPegiRating((PegiRating)cboAssetType.SelectedIndex);
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
            if (cboAssetType.SelectedIndex < 0)
            {
                lblErrorAssetType.Show();
                errorDetected = true;
            }
            if (txtSoftwareUsed.Text == string.Empty)
            {
                lblErrorSoftwareUsed.Show();
                errorDetected = true;
            }
            if (cboPegi.SelectedIndex < 0)
            {
                lblErrorPegi.Show();
                errorDetected = true;
            }
            if (txtAssetStatus.Text == string.Empty)
            {
                lblErrorAssetStatus.Show();
                errorDetected = true;
            }
            if (_assetUploaded == false)
            {
                lblErrorAssetStatus.Show();
                errorDetected = true;
            }

            if (errorDetected == false)
            {
                DataBaseAccess dataBase = new DataBaseAccess();
                dataBase.StartConnection();
                dataBase.AddAsset(_userAsset.GetAssetTitle(), (int)formMain.UsersAccounts.GetCurrentUser().GetUserID(), AssetStatus.Planning, _userAsset.GetAssetType(), _userAsset.GetSoftwareUsed(), _userAsset.GetNotes());
                formMain.curSelectedAssetID = dataBase.getAsset(_userAsset.GetAssetTitle()).GetID();
                dataBase.CloseConnection();
                formMain.ChangeToPage(FormMain.Pages.EditAssetPage);
            }
        }
    }
}
