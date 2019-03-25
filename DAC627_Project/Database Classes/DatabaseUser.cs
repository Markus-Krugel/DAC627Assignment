using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC627_Project.Enums;

namespace DAC627_Project.Database_Classes
{
    class DatabaseUser
    {
        private int id;

        public int ID
        {
            get { return id; }
            private set { id = value; }
        }

        private string username;

        public string Username
        {
            get { return username; }
            private set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            private set { password = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            private set { email = value; }
        }

        private UserType type;

        public UserType Type
        {
            get { return type; }
            private set { type = value; }
        }

        private UserStatus status;

        public UserStatus Status
        {
            get { return status; }
            private set { status = value; }
        }

        private string profilePath;

        public string ProfilePath
        {
            get { return profilePath; }
            private set { profilePath = value; }
        }

        private string fullName;

        public string FullName
        {
            get { return fullName; }
            private set { fullName = value; }
        }

        public DatabaseUser(int id, string username, string password, string email, UserType type, UserStatus status, 
            string profilePath, string fullName)
        {
            ID = id;
            Username = username;
            Password = password;
            Email = email;
            Type = type;
            Status = status;
            ProfilePath = profilePath;
            FullName = fullName;
        }

        public override string ToString()
        {
            return id + ", "+Username+ ", "+Password+", "+Email+", "+Type+", "+Status;
        }
    }
}
