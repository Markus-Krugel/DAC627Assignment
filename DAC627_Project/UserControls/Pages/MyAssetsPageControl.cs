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
        public MyAssetsPageControl(Form form)
        {
            InitializeComponent();
            formMain = form;
        }
    }
}
