
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC627_Project.Classes
{
    class UserRating
    {
        private int id;
        private int reviewerID;
        private int assetID;
        private int stars;
        private string comment;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int ReviewerID
        {
            get { return reviewerID; }
            set { reviewerID = value; }
        }

        public int AssetID
        {
            get { return assetID; }
            set { assetID = value; }
        }

        public int Stars
        {
            get { return stars; }
            set { stars = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }


        public UserRating(int id, int reviewerID, int assetID, int stars, string comment)
        {
            this.id = id;
            this.reviewerID = reviewerID;
            this.assetID = assetID;
            this.stars = stars;
            this.comment = comment;
        }

        public override string ToString()
        {
            return id + ", " + reviewerID + ", " + assetID + ", " + stars + ", " + comment;
        }
    }
}
