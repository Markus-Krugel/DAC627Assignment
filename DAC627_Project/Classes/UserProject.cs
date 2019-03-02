using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC627_Project
{
    public class UserProject
    {
        public enum ProjectType
        {
            Unity,
            UnrealEngine
        }

        private List<UserAsset> _connectedAssets = new List<UserAsset>();
        private UsersAccounts.UserData _author;
        private string _projectTitle;
        private ProjectType _projectType;
        private string _notes;

        public UserProject(UsersAccounts.UserData author)
        {
            _author = author;
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
    }
}
