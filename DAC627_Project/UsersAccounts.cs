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
        private UserData? _currentUser = null;

        //struct
        public struct UserData
        {
            //Backend Managment Data
            private int? _userID;

            //Login Information
            public string userName;
            public string emailAddress;
            private string _password;

            //Other Information
            public string name;
            public string profilePicturePath;

            //Functions
            public void OneTimeSetUserID(int? userID)
            {
                if (_userID == null)
                {
                    _userID = userID;
                }
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
                int szEncryptionKey = _userID.Value;
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

        public void SetCurrentUser(UserData? currentUser)
        {
            _currentUser = currentUser;
        }

        public UserData? GetCurrentUser()
        {
            return _currentUser;
        }

        public void AddUser(UserData _userData)
        {
            _allUsers.Add(_userData);
        }

        public UserData? RetrieveUserData(string UsernameOrEmail)
        {
            foreach (UserData user in _allUsers)
            {
                if (user.userName == UsernameOrEmail || user.emailAddress == UsernameOrEmail)
                {
                    return user;
                }
            }
            return null;
        }



    }
}
