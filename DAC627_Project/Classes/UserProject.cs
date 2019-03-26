using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC627_Project
{
    public class UserProject
    {
        private List<UserAsset> _connectedAssets = new List<UserAsset>();
        private UsersAccounts.UserData _author;
        private string _projectTitle;
        private ProjectType _projectType;
        private string _notes;
        private int _id;
        private ProjectStatus _projectStatus;
        private string _tags;
        private string _thumbnailPath;

        public UserProject(UsersAccounts.UserData author)
        {
            _author = author;
        }

        public UserProject(int id, string projectname, string notes, UsersAccounts.UserData author, ProjectType projectType, ProjectStatus projectStatus, string tags, string thumbnailPath)
        {
            _author = author;
            _id = id;
            _projectTitle = projectname;
            _notes = notes;
            _projectType = projectType;
            _projectStatus = projectStatus;
            _tags = tags;
            _thumbnailPath = thumbnailPath;
        }

        //Sets
        public void SetProjectTitle(string projectTitle)
        {
            _projectTitle = projectTitle;
        }

        public void SetProjectType(ProjectType projectType)
        {
            _projectType = projectType;
        }

        public void SetNotes(string notes)
        {
            _notes = notes;
        }

        //Gets
        public List<UserAsset> GetConnectedAssets()
        {
            return _connectedAssets;
        }

        public UsersAccounts.UserData GetAuthor()
        {
            return _author;
        }

        public string GetProjectTitle()
        {
            return _projectTitle;
        }

        public ProjectType GetProjectType()
        {
            return _projectType;
        }

        public string GetNotes()
        {
            return _notes;
        }

        public int GetID()
        {
            return _id;
        }
    }
}
