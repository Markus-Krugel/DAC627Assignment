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

        public ViewAssetPageControl(FormMain form)
        {
            formMain = form;
            InitializeComponent();
            galPictureGallery.SetToLarge();
            galPictureGallery.IsEditable(false);
        }
    }
}
