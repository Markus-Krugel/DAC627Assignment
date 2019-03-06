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
    public partial class ViewAssetPageControl : UserControl
    {
        FormMain formMain;
        UserAsset _userAsset = null;
        UsersAccounts.UserData _curUserData;

        public ViewAssetPageControl(FormMain form, ref UserAsset userAsset)
        {
            formMain = form;
            _userAsset = userAsset;
            _curUserData = formMain.UsersAccounts.GetCurrentUser();
            InitializeComponent();

            if (_userAsset == null)
            {
                formMain.ChangeToPage(FormMain.Pages.HomePage);
            }
            else
            {
                for (int i = 0; i < _curUserData.GetUserAssets().Count; i++)
                {
                    if (_curUserData.GetUserAssets()[i] == _userAsset)
                    {
                        btnEdit.Show();
                    }
                }
            }

            galPictureGallery.SetToLarge();
            galPictureGallery.IsEditable(false);
            lblTitleEdit.Text = _userAsset.GetAssetTitle();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            formMain.curSelectedAsset = _userAsset;
            formMain.ChangeToPage(FormMain.Pages.EditAssetPage);
        }
    }
}
