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
            HelperTools.LoadFromFile("UploadFile", "PNG File (*.png)|*.png|JPEG File (*.jpg)|*.jpg|GIF File (*.gif)|*.gif|OBJ File (*.obj)|*.obj|FBX File (*.fbx)|*.fbx|WAVE file (*.wav)|*.wav|MP3 File (*.mp3)|*.mp3");
        }

        private void cboUploadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboUploadType.Text == "Project")
            {
                //Change Page to Project Page   
            }
        }
    }
}
