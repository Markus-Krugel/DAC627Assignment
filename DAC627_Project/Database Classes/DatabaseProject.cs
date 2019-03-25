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

        private DatabaseUser owner;

        public DatabaseUser Owner
        {
            get { return owner; }
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

        private string tags;

        public string Tags
        {
            get { return tags; }
            set { tags = value; }
        }

        private string thumbnail;

        public string Thumbnail
        {
            get { return thumbnail; }
            set { thumbnail = value; }
        }


        public DatabaseProject(int id, string projectname, string description, DatabaseUser owner, ProjectType type, 
            ProjectStatus status, string tags, string thumbnail)
        {
            ID = id;
            Projectname = projectname;
            Description = description;
            this.owner = owner;
            Type = type;
            Status = status;
            Tags = tags;
        }

        /// <summary>
        /// Returns ID, projectname, description, name of owner, type, status and tag
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return id + ", " + Projectname + ", " + Description + ", " + owner.Username + ", " + Type + ", " + Status+ ", "+Tags;
        }

        // Just for test purpose
        public string ToStringWithoutOwner()
        {
            return id + ", " + Projectname + ", " + Description + ", " + Type + ", " + Status + ", " + Tags;
        }
    }
}
