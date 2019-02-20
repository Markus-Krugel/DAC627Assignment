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
    public partial class MyAssetsPageControl : UserControl
    {
        Form formMain;
       
       
        Point defaultLocation = new Point(48, 104);
        const int amountPerRow = 5;
        const int distancePerAssetButtonX = 248;
        const int distancePerAssetButtonY = 280;

        public MyAssetsPageControl(Form form)
        {
            InitializeComponent();
            formMain = form;
            HelperTools.CreateTabs(5, this);
        }

        
    }
}
