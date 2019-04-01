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
    public partial class EditAssetPageControl : UserControl
    {
        FormMain formMain;
        private UserAsset _userAsset = new UserAsset(null);
        private UserAsset _curUserAsset = null;
        private int? _userAssetID = null;
        private string _thumbNailPic = null;

        public EditAssetPageControl(FormMain form, int? userAssetID)
        {
            _userAssetID = userAssetID;
            DataBaseAccess dataBase = new DataBaseAccess();
            dataBase.StartConnection();
            _curUserAsset = dataBase.getAsset((int)userAssetID);
            dataBase.CloseConnection();
            InitializeComponent();
            pictureGallery1.InitializePictureGallery((int)_curUserAsset.GetAuthor().GetUserID(), (int)_userAssetID);

            formMain = form;
            if (formMain.UsersAccounts.GetCurrentUser() != null)
            {
                if(_curUserAsset == null || userAssetID == null)
                {
                    MessageBox.Show("Error: Asset Not Found");
                }
                else
                {
                    txtTitle.Text = _curUserAsset.GetAssetTitle();
                    cboAssetType.SelectedIndex = (int)_curUserAsset.GetAssetType();
                    txtSoftwareUsed.Text = _curUserAsset.GetSoftwareUsed();
                    cboPegi.SelectedIndex = (int)_curUserAsset.GetPegiRating();
                    cboAssetStatus.SelectedIndex = (int)_curUserAsset.GetAssetStatus() - 1;
                    txtNotes.Text = _curUserAsset.GetNotes();
                    pictureGallery1.AddPicturesToGallery(_curUserAsset.GetPicturesPath());
                    picThumbnail.ImageLocation = _curUserAsset.GetThumbNail();

                    _userAsset.SetAssetTitle(_curUserAsset.GetAssetTitle());
                    _userAsset.SetAssetStatus(_curUserAsset.GetAssetStatus());
                    _userAsset.SetAssetType(_curUserAsset.GetAssetType());
                    _userAsset.SetSoftwareUsed(_curUserAsset.GetSoftwareUsed());
                    _userAsset.SetPegiRating(_curUserAsset.GetPegiRating());
                    _userAsset.SetNotes(_curUserAsset.GetNotes());
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
                _userAsset.SetAssetTitle(txtTitle.Text);
            }
            else if (((TextBox)sender) == txtSoftwareUsed)
            {
                _userAsset.SetSoftwareUsed(txtSoftwareUsed.Text);
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
            else if (((ComboBox)sender) == cboAssetStatus)
            {
                _userAsset.SetAssetStatus((AssetStatus)cboAssetStatus.SelectedIndex + 1);
            }
        }

        private void btnConfirmChanges_Click(object sender, EventArgs e)
        {
            bool errorDetected = false;
            if (txtTitle.Text == string.Empty || txtTitle.Text == "Title")
            {
                lblErrorTitle.Show();
                errorDetected = true;
            }
            if (cboAssetType.SelectedIndex < 0)
            {
                lblErrorAssetType.Show();
                errorDetected = true;
            }
            if (txtSoftwareUsed.Text == string.Empty || txtSoftwareUsed.Text == "Software Used")
            {
                lblErrorSoftwareUsed.Show();
                errorDetected = true;
            }
            if (cboPegi.SelectedIndex < 0)
            {
                lblErrorPegi.Show();
                errorDetected = true;
            }
            if (cboAssetStatus.SelectedIndex < 0)
            {
                lblErrorAssetStatus.Show();
                errorDetected = true;
            }

            if (errorDetected == false)
            {
                DataBaseAccess dataBase = new DataBaseAccess();
                dataBase.StartConnection();
                if (_curUserAsset.GetAssetTitle() != _userAsset.GetAssetTitle())
                    dataBase.ChangeAssetName((int)_userAssetID, _userAsset.GetAssetTitle());

                if (_curUserAsset.GetAssetType() != _userAsset.GetAssetType())
                    dataBase.ChangeAssetType((int)_userAssetID, _userAsset.GetAssetType());

                if (_curUserAsset.GetSoftwareUsed() != _userAsset.GetSoftwareUsed())
                    dataBase.ChangeAssetSoftware((int)_userAssetID, _userAsset.GetSoftwareUsed());

                if (_curUserAsset.GetAssetStatus() != _userAsset.GetAssetStatus())
                    dataBase.ChangeAssetStatus((int)_userAssetID, _userAsset.GetAssetStatus());

                if (_curUserAsset.GetNotes() != _userAsset.GetNotes())
                    dataBase.ChangeAssetNotes((int)_userAssetID, _userAsset.GetNotes());

                if (_thumbNailPic != null)
                    dataBase.ChangeAssetThumbnail((int)_userAssetID, _thumbNailPic);

                List<string> tempPictureHolder = pictureGallery1.GetPicturesPathFromGallery();
                _curUserAsset.SetPicturesPath(tempPictureHolder);
                if(tempPictureHolder.Count >= 1)
                dataBase.ChangeAssetGalleryOne((int)_userAssetID ,tempPictureHolder[0]);
                if (tempPictureHolder.Count >= 2)
                    dataBase.ChangeAssetGalleryTwo((int)_userAssetID, tempPictureHolder[1]);
                if (tempPictureHolder.Count >= 3)
                    dataBase.ChangeAssetGalleryThree((int)_userAssetID, tempPictureHolder[2]);
                if (tempPictureHolder.Count >= 4)
                    dataBase.ChangeAssetGalleryFour((int)_userAssetID, tempPictureHolder[3]);
                if (tempPictureHolder.Count >= 5)
                    dataBase.ChangeAssetGalleryFive((int)_userAssetID, tempPictureHolder[4]);

                dataBase.CloseConnection();


                formMain.curSelectedAssetID = _userAssetID;
                formMain.ChangeToPage(FormMain.Pages.ViewAssetPage);
            }
        }

        private void btnUploadThumbnail_Click(object sender, EventArgs e)
        {
            string _uploadedPic = HelperTools.LoadFromFile("Choose Image", "PNG File (*.png)|*.png|JPEG File (*.jpg)|*.jpg");
            _uploadedPic = HelperTools.AddFileToStorage(_uploadedPic, (int)_curUserAsset.GetAuthor().GetUserID(), _userAssetID);
            _thumbNailPic = _uploadedPic;
            picThumbnail.ImageLocation = _thumbNailPic;

        }

        private void lblNotes_Click(object sender, EventArgs e)
        {

        }

        private void picThumbnail_Click(object sender, EventArgs e)
        {

        }
    }
}
