using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DAC627_Project
{
    public partial class TestPageControl : UserControl
    {
        Form formMain;
        public TestPageControl(Form form)
        {
            InitializeComponent();
            formMain = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var filePath = string.Empty;

            //using (OpenFileDialog openFileDialog = new OpenFileDialog())
            //{
            //    openFileDialog.Title = "NAME ME BIATCH";
            //    openFileDialog.InitialDirectory = "c:\\";
            //    openFileDialog.Filter = "PNG files (*.png)|*.png|JPEG files (*.jpg)|*.jpg|All files (*.*)|*.*";
            //    openFileDialog.FilterIndex = 2;
            //    openFileDialog.RestoreDirectory = true;

            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        //ADD YOUR CODE HERE  

            //        //Get the path of specified file
            //        filePath = openFileDialog.FileName;

            //Set image here

                    string filepath = HelperTools.LoadFromFile();

                    pictureBox1.Image = Image.FromFile(filepath);
                    //  pictureBox1.Size = pictureBox1.Image.;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    //File path 
                    label1.Text = filepath;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Aaron you numnut...you need to find a file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //} 
           
        }
    }
}
