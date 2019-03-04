using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC627_Project.Enums;

namespace DAC627_Project.Database_Classes
{
    class DatabaseProject
    {
        private int id;

        public int ID
        {
            get { return id; }
            private set { id = value; }
        }

        private string projectname;

        public string Projectname
        {
            get { return projectname; }
            private set { projectname = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            private set { description = value; }
        }

        private int ownerID;

        public int OwnerID
        {
            get { return ownerID; }
            private set { ownerID = value; }
        }

        private ProjectType type;

        public ProjectType Type
        {
            get { return type; }
            private set { type = value; }
        }

        private ProjectStatus status;

        public ProjectStatus Status
        {
            get { return status; }
            private set { status = value; }
        }

        private ProjectTag tag;

        public ProjectTag Tag
        {
            get { return tag; }
            set { tag = value; }
        }


        public DatabaseProject(int id, string projectname, string description, int ownerID, ProjectType type, ProjectStatus status, ProjectTag tag)
        {
            ID = id;
            Projectname = projectname;
            Description = description;
            OwnerID = ownerID;
            Type = type;
            Status = status;
            Tag = tag;
        }

        public override string ToString()
        {
            return id + ", " + Projectname + ", " + Description + ", " + OwnerID + ", " + Type + ", " + Status+ ", "+Tag;
        }
    }
}
