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
    public partial class AssetButton : UserControl
    {

        FormMain _formMain;
        int? _userAssetOrProjectID = null;
        bool _isAsset = false;
        string _picturePath = null;

        public AssetButton(FormMain formMain, int? userAssetOrProjectID, bool isAsset)
        {
            _isAsset = isAsset;
            _userAssetOrProjectID = userAssetOrProjectID;
            InitializeComponent();
            _formMain = formMain;
        }

        public void SetName(string name)
        {
            lblName.Text = name;
        }

        public void SetPicturePath(string path)
        {
            _picturePath = path;
            picAsset.ImageLocation = _picturePath;
        }

        private void picAsset_Click(object sender, EventArgs e)
        {

            if (_isAsset)
            {
                _formMain.curSelectedAssetID = _userAssetOrProjectID;
                _formMain.ChangeToPage(FormMain.Pages.ViewAssetPage);
            }
            else if (!_isAsset)
            {
                _formMain.curSelectedUserProjectID = _userAssetOrProjectID;
                _formMain.ChangeToPage(FormMain.Pages.ViewProjectPage);
            }
        }
    }
}
