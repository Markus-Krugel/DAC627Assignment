using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC627_Project
{


    public class UsersAccounts
    {
        //Varibles
        private List<UserData> _allUsers = new List<UserData>();
        private UserData _currentUser = null;

        //struct
        public class UserData
        {
            //Backend Managment Data
            private int? _userID;

            //Login Information
            public string userName;
            public string emailAddress;
            public string _password;

            //Other Information
            public string fullName;
            private string _profilePicturePath;
            private UserStatus _userStatus;
            private UserType _userType;

            //User Projects and Assets
            private List<UserProject> _userProjects = new List<UserProject>();
            private List<UserAsset> _userAssets = new List<UserAsset>();

            //Constructor
            public UserData(int userID, string UserName, string password, string EmailAddress, UserType userType, UserStatus userStatus, string profilePicturePath = "", string name = "")
            {
                _userID = userID;
                userName = UserName;
                emailAddress = EmailAddress;
                _password = password;
                _userStatus = userStatus;
                _userType = userType;
                fullName = name;
                _profilePicturePath = profilePicturePath;
            }

            public UserData()
            {

            }

            //Functions
            public List<UserProject> GetUsersProjects()
            {
                return _userProjects;
            }

            public List<UserAsset> GetUserAssets()
            {
                return _userAssets;
            }

            public void AddUserProject(UserProject project)
            {
                _userProjects.Add(project);
            }

            public void AddUserAsset(UserAsset asset)
            {
                _userAssets.Add(asset);
            }

            public void OneTimeSetUserID(int? userID)
            {
                if (_userID == null)
                {
                    _userID = userID;
                }
            }

            public int? GetUserID()
            {
                return _userID;
            }

            public void SetPassword(string newPassword)
            {
                _password = EncryptDecrypt(newPassword);
            }

            public bool IsValidPassword(string testPassword)
            {
                Console.WriteLine(_password);
                if (_password == EncryptDecrypt(testPassword))
                {
                    return true;
                }
                return false;
            }

            public bool IsValidUsernameOrEmail(string UsernameOrEmail)
            {
                if (userName == UsernameOrEmail || emailAddress == UsernameOrEmail)
                {
                    return true;
                }
                return false;
            }

            private string EncryptDecrypt(string szPlainText)
            {
                int szEncryptionKey = 5;
                string szInputStringBuild = szPlainText;
                char[] szOutStringBuild = new char[szPlainText.Length];

                char Textch;
                for (int iCount = 0; iCount < szPlainText.Length; iCount++)
                {
                    Textch = szInputStringBuild[iCount];
                    Textch = (char)(Textch ^ szEncryptionKey);
                    szOutStringBuild[iCount] = Textch;
                }
                return new string(szOutStringBuild);
            }
        }

        public void SetCurrentUser(UserData currentUser)
        {
            _currentUser = currentUser;
        }

        public UserData GetCurrentUser()
        {
            return _currentUser;
        }

        public void AddUser(UserData _userData)
        {
            DataBaseAccess dataBase = new DataBaseAccess();
            dataBase.StartConnection();
            dataBase.AddUser( _userData._password ,_userData.emailAddress, _userData.userName, UserType.Developer, _userData.fullName);
            dataBase.CloseConnection();
        }

        public UserData RetrieveUserData(string UsernameOrEmail)
        {
            DataBaseAccess dataBase = new DataBaseAccess();
            dataBase.StartConnection();
            UserData userData = dataBase.GetUser(UsernameOrEmail);
            dataBase.CloseConnection();
                if (userData != null)
                {
                    return userData;
                }
            return null;
        }



    }
}
