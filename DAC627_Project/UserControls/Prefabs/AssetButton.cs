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
        UserAsset _userAsset = null;
        UserProject _userProject = null;

        public AssetButton(FormMain formMain, UserAsset userAsset)
        {
            _userAsset = userAsset;
            InitializeComponent();
            _formMain = formMain;
        }

        public AssetButton(FormMain formMain, UserProject userProject)
        {
            _userProject = userProject;
            InitializeComponent();
            _formMain = formMain;
        }

        public void SetName(string name)
        {
            lblName.Text = name;
        }

        private void picAsset_Click(object sender, EventArgs e)
        {
            if (_userAsset != null)
            {
                _formMain.curSelectedAsset = _userAsset;
                _formMain.ChangeToPage(FormMain.Pages.ViewAssetPage);
            }
            else if (_userProject != null)
            {
                _formMain.curSelectedUserProject = _userProject;
            }
        }
    }
}
