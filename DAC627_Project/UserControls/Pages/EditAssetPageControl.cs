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

        public EditAssetPageControl(FormMain form, ref UserAsset userAsset)
        {
            _curUserAsset = userAsset;
            InitializeComponent();
            formMain = form;
            if (formMain.UsersAccounts.GetCurrentUser() != null)
            {
                if(_curUserAsset == null)
                {
                    MessageBox.Show("Error: Asset Not Found");
                }
                else
                {
                    txtTitle.Text = _curUserAsset.GetAssetTitle();
                    cboAssetType.SelectedIndex = (int)_curUserAsset.GetAssetType();
                    txtSoftwareUsed.Text = _curUserAsset.GetSoftwareUsed();
                    cboPegi.SelectedIndex = (int)_curUserAsset.GetPegiRating();
                    txtAssetStatus.Text = _curUserAsset.GetAssetStatus();
                    txtNotes.Text = _curUserAsset.GetNotes();
                    _userAsset.SetAssetTitle(_curUserAsset.GetAssetTitle());
                    _userAsset.SetAssetType(_curUserAsset.GetAssetType());
                    _userAsset.SetSoftwareUsed(_curUserAsset.GetSoftwareUsed());
                    _userAsset.SetPegiRating(_curUserAsset.GetPegiRating());
                    _userAsset.SetAssetStatus(_curUserAsset.GetAssetStatus());
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
                _userAsset.SetAssetType((UserAsset.AssetType)cboAssetType.SelectedIndex);
            }
            else if (((ComboBox)sender) == cboPegi)
            {
                _userAsset.SetPegiRating((UserAsset.PegiRating)cboAssetType.SelectedIndex);
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

            if (errorDetected == false)
            {
                _curUserAsset.SetAssetTitle(_userAsset.GetAssetTitle());
                _curUserAsset.SetAssetType(_userAsset.GetAssetType());
                _curUserAsset.SetSoftwareUsed(_userAsset.GetSoftwareUsed());
                _curUserAsset.SetPegiRating(_userAsset.GetPegiRating());
                _curUserAsset.SetAssetStatus(_userAsset.GetAssetStatus());
                _curUserAsset.SetNotes(_userAsset.GetNotes());
                formMain.curSelectedAsset = _curUserAsset;
                formMain.ChangeToPage(FormMain.Pages.ViewAssetPage);
            }
        }
    }
}
