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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            //use this in order to display the user control of your choice...
            UserControl foo = new HomePageControl(this);
            foo.Dock = DockStyle.Fill;
            Controls.Add(foo);
        }


        //**All global functions or variables should go here**

        
        public bool RemoveGrayText(TextBox textBox)
        {
            //Test if the text box has the default text, the colour for your default name text boxes should ALWAYS be Color.Grey to ensure this works.
            if (textBox.Text == textBox.AccessibleName && textBox.ForeColor == Color.Gray) 
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

        public bool CheckEmpty(TextBox textBox)
        {
            //If the user did not type anything, then return text to orginal value and colours 
            if (textBox.Text == "")
            {
                textBox.Text = textBox.AccessibleName;
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
