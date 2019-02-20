using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC627_Project
{
    public class UserProject
    {
        private List<UserAssets> _connectedAssets;
        private UsersAccounts.UserData _author;
        private string _projectName;

        public List<UserAssets> GetConnectedAssets()
        {
            return _connectedAssets;
        }

        public UsersAccounts.UserData GetAuthor()
        {
            return _author;
        }

        public string GetProjectName()
        {
            return _projectName;
        }
    }
}
