using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAC627_Project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public bool RemoveGrayText(TextBox textBox, string testingValue)
        {
            if (textBox.Text == testingValue && textBox.ForeColor == Color.Gray)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckEmpty(TextBox textBox, string orginalValue)
        {
            if (textBox.Text == "")
            {
                textBox.Text = orginalValue;
                textBox.ForeColor = Color.Gray;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
