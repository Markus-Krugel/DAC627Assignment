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
    public partial class PictureGallery : UserControl
    {
        List<string> _pictures = new List<string>();
        int _pictureInView = 0;

        public PictureGallery()
        {
            InitializeComponent(); 
            IsEditable(true);
            //Can anything fuckign work poleawr
            _pictures.Add("null");
        }

        public void IsEditable(bool input)
        {
            btnUpload.Visible = input;
            
        }


        private void btnUpload_Click(object sender, EventArgs e)
        {
           string _uploadedPic = HelperTools.LoadFromFile("Choose Image", "PNG File (*.png)|*.png|JPEG File (*.jpg)|*.jpg");
            if (_uploadedPic != string.Empty)
            {
                if(_pictures[_pictureInView] == "null")
                {
                    _pictures[_pictureInView] = _uploadedPic;
                    picImage.ImageLocation = _pictures[_pictureInView];
                }
                else
                {
                    _pictures.Add(_uploadedPic);
                    _pictureInView++;
                    picImage.ImageLocation = _pictures[_pictureInView];
                }
            }
            else
            {
                picImage.ImageLocation = _pictures[_pictureInView];
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            MoveGalleryLeft();
        }

        private void MoveGalleryLeft()
        {
            if (_pictures.Count != 0)
            {
                if (_pictureInView != 0)
                {
                    _pictureInView--;
                }
                else
                {
                    _pictureInView = _pictures.Count - 1;
                }

                picImage.ImageLocation = _pictures[_pictureInView];
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            MoveGalleryRight();
        }

        private void MoveGalleryRight()
        {
            if (_pictures.Count != 0)
            {
                if (_pictureInView != _pictures.Count - 1)
                {
                    _pictureInView++;
                }
                else
                {
                    _pictureInView = 0;
                }

                picImage.ImageLocation = _pictures[_pictureInView];
            }

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(_pictures.Count != 1)
            {
                _pictures.Remove(_pictures[_pictureInView]);
                MoveGalleryLeft();
            }
            else
            {
                _pictures[_pictureInView] = "null";
                picImage.Image = null;
            }
            
        }
    }
}
