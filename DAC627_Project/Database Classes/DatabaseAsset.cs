using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC627_Project.Enums;


namespace DAC627_Project.Database_Classes
{
    class DatabaseAsset
    {
        private int id;

        public int ID
        {
            get { return id; }
            private set { id = value; }
        }

        private string assetname;

        public string Assetname
        {
            get { return assetname; }
            private set { assetname = value; }
        }

        private string notes;

        public string Notes
        {
            get { return notes; }
            private set { notes = value; }
        }

        private DatabaseUser creator;

        public DatabaseUser Creator
        {
            get { return creator; }
        }

        private AssetType type;

        public AssetType Type
        {
            get { return type; }
            private set { type = value; }
        }

        private AssetStatus status;

        public AssetStatus Status
        {
            get { return status; }
            private set { status = value; }
        }

        private string software;

        public string Software
        {
            get { return software; }
            private set { software = value; }
        }

        private PegiRating pegiRating;

        public PegiRating PegiRating
        {
            get { return pegiRating; }
            private set { pegiRating = value; }
        }

        private string tags;

        public string Tags
        {
            get { return tags; }
            set { tags = value; }
        }

        private string assetPath;

        public string AssetPath
        {
            get { return assetPath; }
            set { assetPath = value; }
        }

        private string thumbnail;

        public string Thumbnail
        {
            get { return thumbnail; }
            set { thumbnail = value; }
        }

        private string galleryOne;

        public string GalleryOne
        {
            get { return galleryOne; }
            set { galleryOne = value; }
        }

        private string galleryTwo;

        public string GalleryTwo
        {
            get { return galleryTwo; }
            set { galleryTwo = value; }
        }

        private string galleryThree;

        public string GalleryThree
        {
            get { return galleryThree; }
            set { galleryThree = value; }
        }

        private string galleryFour;

        public string GalleryFour
        {
            get { return galleryFour; }
            set { galleryFour = value; }
        }

        private string galleryFive;

        public string GalleryFive
        {
            get { return galleryFive; }
            set { galleryFive = value; }
        }

        public DatabaseAsset(int id, string assetname, string notes, DatabaseUser creator, AssetType type, AssetStatus status,
            string software, string pathfile, PegiRating pegiRating = PegiRating._3,string tags = "", string thumbnail = "", 
            string galleryOne = "", string galleryTwo = "", string galleryThree = "", string galleryFour = "", string galleryFive = "")
        {
            ID = id;
            Assetname = assetname;
            Notes = notes;
            this.creator = creator;
            Type = type;
            Status = status;
            PegiRating = pegiRating;
            Software = software;
            Tags = tags;
            AssetPath = pathfile;
            Thumbnail = thumbnail;
            GalleryOne = galleryOne;
            GalleryTwo = galleryTwo;
            GalleryThree = galleryThree;
            GalleryFour = galleryFour;
            GalleryFive = galleryFive;
        }

        /// <summary>
        /// Returns ID, assetname, notes, name of creator, type, status, software, pegi rating and path to the file
        /// </summary>
        /// <returns>Returns string summary of the Class</returns>
        public override string ToString()
        {
            return id + ", " + Assetname + ", " + Notes + ", " + creator.Username + ", " + Type + "," +
                " " + Status + ", " + Software + ", " + PegiRating+ ", "+AssetPath;
        }

        // Just for test purpose
        public string ToStringShort()
        {
            return id + ", " + Assetname + ", " + Notes + ", " + Type + ", " + Status + ", " + Software + ", " + PegiRating;
        }
    }
}
