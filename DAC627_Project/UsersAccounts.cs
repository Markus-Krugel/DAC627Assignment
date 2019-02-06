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
        private List<UserData> m_allUsers = new List<UserData>();
        private UserData? m_currentUser = null;

        //struct
        public struct UserData
        {
            //Backend Managment Data
            private int? m_userID;

            //Login Information
            public string m_userName;
            public string m_emailAddress;
            private string m_password;

            //Private Data
            public string m_address;
            public string m_profilePicture;

            //Functions
            public void OneTimeSetUserID(int? userId)
            {
                if (m_userID == null)
                {
                    m_userID = userId;
                }
            }

            public void SetPassword(string newPassword)
            {
                m_password = EncryptDecrypt(newPassword);
            }

            public bool IsValidPassword(string testPassword)
            {
                Console.WriteLine(m_password);
                if (m_password == EncryptDecrypt(testPassword))
                {
                    return true;
                }
                return false;
            }

            public bool IsValidUsernameOrEmail(string UsernameOrEmail)
            {
                if (m_userName == UsernameOrEmail || m_emailAddress == UsernameOrEmail)
                {
                    return true;
                }
                return false;
            }

            private string EncryptDecrypt(string szPlainText)
            {
                int szEncryptionKey = m_userID.Value;
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
            m_currentUser = currentUser;
        }

        public UserData? GetCurrentUser()
        {
            return m_currentUser;
        }

        public void AddUser(UserData _userData)
        {
            m_allUsers.Add(_userData);
        }

        public UserData? RetrieveUserData(string UsernameOrEmail)
        {
            foreach (UserData user in m_allUsers)
            {
                if (user.m_userName == UsernameOrEmail || user.m_emailAddress == UsernameOrEmail)
                {
                    return user;
                }
            }
            return null;
        }



    }
}
