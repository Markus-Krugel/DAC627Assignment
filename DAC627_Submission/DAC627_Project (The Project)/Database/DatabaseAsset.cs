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

        private int pegiRating;

        public int PegiRating
        {
            get { return pegiRating; }
            private set { pegiRating = value; }
        }


        public DatabaseAsset(int id, string assetname, string notes, DatabaseUser creator, AssetType type, AssetStatus status, string software, int pegiRating = 3)
        {
            ID = id;
            Assetname = assetname;
            Notes = notes;
            this.creator = creator;
            Type = type;
            Status = status;
            PegiRating = pegiRating;
            Software = software;
        }

        /// <summary>
        /// Returns ID, assetname, notes, name of creator, type, status, software and pegi rating
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return id + ", " + Assetname + ", " + Notes + ", " + creator.Username + ", " + Type + ", " + Status + ", " + Software + ", " + PegiRating;
        }

        // Just for test purpose
        public string ToStringWithoutCreator()
        {
            return id + ", " + Assetname + ", " + Notes + ", " + Type + ", " + Status + ", " + Software + ", " + PegiRating;
        }
    }
}
