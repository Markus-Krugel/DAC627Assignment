using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAC627_Project.UserControls
{
    class UserAssets
    {
        private string _assetName;
        private UsersAccounts.UserData _author;
        private List<string> _picturesPath;
        private string _assetPath;

        public string GetAssetName()
        {
            return _assetName;
        }

        public UsersAccounts.UserData GetAuthor()
        {
            return _author;
        }

        public List<string> GetPicturesPath()
        {
            return _picturesPath;
        }

        public string AssetPath()
        {
            return _assetPath;
        }
    }
}
