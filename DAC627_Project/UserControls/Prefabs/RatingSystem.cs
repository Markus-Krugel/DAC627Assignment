using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAC627_Project.UserControls.Prefabs
{
    public partial class RatingSystem : UserControl
    {
        private List<PictureBox> stars = new List<PictureBox>();
        public int _rating = 1;
        public bool _canSetRating = true;

        public RatingSystem()
        {
            InitializeComponent();
            stars.Add(picStar1);
            stars.Add(picStar2);
            stars.Add(picStar3);
            stars.Add(picStar4);
            stars.Add(picStar5);
        }

        private void PicStar1_Click(object sender, EventArgs e)
        {
            StarChange(1);
        }

        private void picStar2_Click(object sender, EventArgs e)
        {
            StarChange(2);
        }

        private void picStar3_Click(object sender, EventArgs e)
        {
            StarChange(3);
        }

        private void picStar4_Click(object sender, EventArgs e)
        {
            StarChange(4);
        }


        private void picStar5_Click(object sender, EventArgs e)
        {
            StarChange(5);
        }

        void StarChange(int amountOfStars)
        {
            _rating = amountOfStars;
            if (_canSetRating)
            {
                UpdateStarsGraphics(amountOfStars);
            }
        }

        public void UpdateStarsGraphics(int amountOfStars)
        {
            for (int i = 0; i < stars.Count; i++)
            {
                if (amountOfStars <= i)
                {
                    stars[i].Image = DAC627_Project.Properties.Resources.StarEmpty;
                }
                else if (amountOfStars >= i)
                {
                    stars[i].Image = DAC627_Project.Properties.Resources.StarFull;
                }
            }
        }
    }
}
