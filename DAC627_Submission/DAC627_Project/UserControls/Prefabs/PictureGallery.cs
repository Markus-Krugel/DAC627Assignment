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
        int _userID;
        int _assetID;

        public PictureGallery()
        {
            InitializeComponent();
            IsEditable(true);
            //Can anything fuckign work poleawr

            _pictures.Add("null");
            //  SetToLarge();
        }

        public void InitializePictureGallery(int userID, int assetID)
        {
            _userID = userID;
            _assetID = assetID;
        }

        public void IsEditable(bool input)
        {
            btnUpload.Visible = input;
            btnDelete.Visible = input;
        }

        public void SetToLarge()
        {
            this.Size = new Size(500, 460);

            picImage.Size = new Size(400, 400);
            picImage.Location = new Point(48, 0);

            btnLeft.Size = new Size(24, 24);
            btnLeft.Location = new Point(16, 200);

            btnRight.Size = new Size(24, 24);
            btnRight.Location = new Point(464, 200);

            btnDelete.Size = new Size(75, 24);
            btnDelete.Location = new Point(64, 408);

            btnUpload.Size = new Size(75, 24);
            btnUpload.Location = new Point(360, 408);


        }

        public void SetToSmall()
        {
            this.Size = new Size(250, 230);

            picImage.Size = new Size(200, 200);
            picImage.Location = new Point(24, 0);

            btnLeft.Size = new Size(24, 24);
            btnLeft.Location = new Point(0, 104);

            btnRight.Size = new Size(24, 24);
            btnRight.Location = new Point(224, 104);

            btnDelete.Size = new Size(75, 24);
            btnDelete.Location = new Point(24, 200);

            btnUpload.Size = new Size(75, 24);
            btnUpload.Location = new Point(152, 200);
        }


        private void btnUpload_Click(object sender, EventArgs e)
        {
           
            string _uploadedPic = HelperTools.LoadFromFile("Choose Image", "PNG File (*.png)|*.png|JPEG File (*.jpg)|*.jpg");
            _uploadedPic = HelperTools.AddFileToStorage(_uploadedPic, _userID, _assetID);
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

        public List<string> GetPicturesPathFromGallery()
        {
            return _pictures;
        }

        public void AddPicturesToGallery(List<string> picturePaths)
        {
            for (int i = 0; i < picturePaths.Count; i++)
            {
                if(_pictures.Count > i && _pictures[i] == "null" && picturePaths[i] != string.Empty)
                {
                    _pictures[i] = picturePaths[i];
                }
                else if (picturePaths[i] != string.Empty)
                {
                    _pictures.Add(picturePaths[i]);
                }
            }
            if (picturePaths.Count > 0)
            {
                MoveGalleryRight();
            }
        }
    }
}
