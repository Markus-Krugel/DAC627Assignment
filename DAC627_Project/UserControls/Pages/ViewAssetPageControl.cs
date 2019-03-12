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
        int? _userAssetID;

        public ViewAssetPageControl(FormMain form, int? userAssetID)
        {
            formMain = form;
            _userAssetID = userAssetID;

            DataBaseAccess dataBase = new DataBaseAccess();
            dataBase.StartConnection();
            _userAsset = dataBase.getAsset((int)userAssetID);
            dataBase.CloseConnection();

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
            formMain.curSelectedAssetID = _userAsset.GetID();
            formMain.ChangeToPage(FormMain.Pages.EditAssetPage);
        }
    }
}
