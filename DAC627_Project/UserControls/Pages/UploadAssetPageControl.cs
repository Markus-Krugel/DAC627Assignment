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

        public UploadAssetPageControl(FormMain form)
        {
            InitializeComponent();
            formMain = form;
            cboUploadType.SelectedIndex = 0;
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

                HelperTools.LoadFromFile("Upload Asset", filter);
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
    }
}
