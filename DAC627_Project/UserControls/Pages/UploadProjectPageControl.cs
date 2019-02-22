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
        public UploadProjectPageControl(FormMain form)
        {
            InitializeComponent();
            cboUploadType.SelectedIndex = 1;
            formMain = form;
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
    }
}
