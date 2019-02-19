using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC627_Project.Enums;

namespace DAC627_Project
{
    class DataBaseAccess
    {
        private OleDbConnection connection;

        public DataBaseAccess()
        {
            startConnection();
        }

        public void startConnection()
        {
            try
            {
                connection = new OleDbConnection();
                connection.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ../../Database/Database.accdb;
                Persist Security Info = False;";
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void closeConnection()
        {
            connection.Close();
        }

        private void executeCommand(string commandText)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = commandText;

                command.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        #region add commands

        public void addUser(string password, string email, string username, UserType type, UserStatus status = UserStatus.Offline)
        {
            string commandText = "INSERT INTO [User] (Status, [Password], Email, Username, Type ) VALUES " +
                                "('" + status + "','" + password + "','" + email + "','" + username + "','" + type + "')";

            executeCommand(commandText);
        }

        public void addProject(string name, ProjectType type, string description, int owner, ProjectTag tag, ProjectStatus status)
        {
            string commandText = "INSERT INTO Project ( Projectname, Type, Description, Owner, Tag, Status ) VALUES " +
                                    "('" + name + "','" + type + "','" + description + "','" + owner + "','" + tag + "','" + status + "')";

            executeCommand(commandText);
        }

        public void addAsset(string name, int creator, string version, AssetStatus status, AssetTag tag, string software)
        {
            string commandText = "INSERT INTO Asset ( Assetname, Creator, [Software Version], Status, Tag, Software ) VALUES " +
                                    "('" + name + "'," + creator + ",'" + version + "','" + status + "','" + tag + "', '"+ software +"')";

            executeCommand(commandText);
        }

        #endregion

        #region get commands

        public int getUserID(string username)
        {
            string commandText = "SELECT User.ID FROM[User] WHERE Username = '" + username;
        }

        #endregion
        
        #region change values

        #region change user values

        public void changeUserName(string oldValue, string newValue)
        {
            string commandText = "UPDATE [User] SET Username = '" + newValue + "' WHERE Username = '" + oldValue + "'";

            executeCommand(commandText);
        }

        public void changeUserName(int id, string newValue)
        {
            string commandText = "UPDATE [User] SET Username = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        public void changeUserEmail(string username, string newValue)
        {
            string commandText = "UPDATE [User] SET Email = '" + newValue + "' WHERE Username = '" + username + "'";

            executeCommand(commandText);
        }

        public void changeUserEmail(int id, string newValue)
        {
            string commandText = "UPDATE [User] SET Email = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        public void changeUserType(string username, UserType newValue)
        {
            string commandText = "UPDATE [User] SET Type = '" + newValue + "' WHERE Username = '" + username + "'";

            executeCommand(commandText);
        }

        public void changeUserType(int id, UserType newValue)
        {
            string commandText = "UPDATE [User] SET Type = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        public void changeUserStatus(string username, UserStatus newValue)
        {
            string commandText = "UPDATE [User] SET Status = '" + newValue + "' WHERE Username = '" + username + "'";

            executeCommand(commandText);
        }

        public void changeUserStatus(int id, UserStatus newValue)
        {
            string commandText = "UPDATE [User] SET Status = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        public void changeUserPassword(string username, string newValue)
        {
            string commandText = "UPDATE [User] SET [Password] = '" + newValue + "' WHERE Username = '" + username + "'";

            executeCommand(commandText);
        }

        public void changeUserPassword(int id, string newValue)
        {
            string commandText = "UPDATE [User] SET [Password] = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        #endregion

        #region change project values

        public void changeProjectName(string oldValue, string newValue)
        {
            string commandText = "UPDATE [Project] SET Projectname = '" + newValue + "' WHERE Projectname = '" + oldValue + "'";

            executeCommand(commandText);
        }

        public void changeProjectName(int id, string newValue)
        {
            string commandText = "UPDATE [Project] SET Projectname = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        public void changeProjectType(string oldValue, ProjectType newValue)
        {
            string commandText = "UPDATE [Project] SET Type = '" + newValue + "' WHERE Projectname = '" + oldValue + "'";

            executeCommand(commandText);
        }

        public void changeProjectType(int id, ProjectType newValue)
        {
            string commandText = "UPDATE [Project] SET Type = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        public void changeProjectDescription(string oldValue, string newValue)
        {
            string commandText = "UPDATE [Project] SET Description = '" + newValue + "' WHERE Projectname = '" + oldValue + "'";

            executeCommand(commandText);
        }

        public void changeProjectDescription(int id, string newValue)
        {
            string commandText = "UPDATE [Project] SET Description = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        public void changeProjectOwner(string oldValue, int newValue)
        {
            string commandText = "UPDATE [Project] SET Owner = " + newValue + " WHERE Projectname = '" + oldValue + "'";

            executeCommand(commandText);
        }

        public void changeProjectOwner(int id, int newValue)
        {
           string commandText = "UPDATE [Project] SET Owner = " + newValue + " WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        public void changeProjectTag(int id, int newValue)
        {
            string commandText = "UPDATE [Project] SET Tag = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        public void changeProjectTag(string oldValue, ProjectTag newValue)
        {
            string commandText = "UPDATE [Project] SET Tag = '" + newValue + "' WHERE Projectname = '" + oldValue + "'";

            executeCommand(commandText);
        }

        public void changeProjectStatus(int id, ProjectStatus newValue)
        {
            string commandText = "UPDATE [Project] SET Status = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        public void changeProjectStatus(string oldValue, ProjectStatus newValue)
        {
            string commandText = "UPDATE [Project] SET Status = '" + newValue + "' WHERE Projectname = '" + oldValue + "'";

            executeCommand(commandText);
        }

        #endregion

        #region change asset values

        public void changeAssetName(string oldValue, string newValue)
        {
            string commandText = "UPDATE [Asset] SET Assetname = '" + newValue + "' WHERE Assetname = '" + oldValue + "'";

            executeCommand(commandText);
        }

        public void changeAssetName(int id, string newValue)
        {
            string commandText = "UPDATE [Asset] SET Assetname = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        public void changeAssetCreator(string oldValue, int newValue)
        {
            string commandText = "UPDATE [Asset] SET Creator = " + newValue + " WHERE Assetname = '" + oldValue + "'";

            executeCommand(commandText);
        }

        public void changeAssetCreator(int id, int newValue)
        {
            string commandText = "UPDATE [Asset] SET Creator = " + newValue + " WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        public void changeAssetSoftware(string oldValue, string newValue)
        {
            string commandText = "UPDATE [Asset] SET Software  = '" + newValue + "' WHERE Assetname = '" + oldValue + "'";

            executeCommand(commandText);
        }

        public void changeAssetSoftware(int id, string newValue)
        {
            string commandText = "UPDATE [Asset] SET Software = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        public void changeAssetVersion(string oldValue, string newValue)
        {
            string commandText = "UPDATE [Asset] SET [Software Version] = '" + newValue + "' WHERE Assetname = '" + oldValue + "'";

            executeCommand(commandText);
        }

        public void changeAssetVersion(int id, string newValue)
        {
            string commandText = "UPDATE [Asset] SET [Software Version] = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        public void changeAssetStatus(string oldValue, AssetStatus newValue)
        {
            string commandText = "UPDATE [Asset] SET Status = '" + newValue + "' WHERE Assetname = '" + oldValue + "'";

            executeCommand(commandText);
        }

        public void changeAssetStatus(int id, AssetStatus newValue)
        {
            string commandText = "UPDATE [Asset] SET Status = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        public void changeAssetTag(string oldValue, AssetTag newValue)
        {
            string commandText = "UPDATE [Asset] SET Tag = '" + newValue + "' WHERE Assetname = '" + oldValue + "'";

            executeCommand(commandText);
        }

        public void changeAssetTag(int id, AssetTag newValue)
        {
            string commandText = "UPDATE [Asset] SET Tag = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        #endregion

        #endregion

        #region return tables 

        public void showAllUsers()
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT User.* FROM[User] ";

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(reader.GetInt32(0) + ", ");
                    Console.Write(reader.GetString(1) + ", ");
                    Console.Write(reader.GetString(2) + ", ");
                    Console.Write(reader.GetString(3) + ", ");
                    Console.Write(reader.GetString(4) + ", ");
                    Console.Write(reader.GetString(5));
                    Console.WriteLine();
                }
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        public void showAllProjects()
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Project.* FROM[Project] ";

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(reader.GetInt32(0) + ", ");
                    Console.Write(reader.GetString(1) + ", ");
                    Console.Write(reader.GetString(2) + ", ");
                    Console.Write(reader.GetString(3) + ", ");
                    Console.Write(reader.GetValue(4).ToString() + ", ");
                    Console.Write(reader.GetString(5) + ", ");
                    Console.Write(reader.GetString(6));
                    Console.WriteLine();
                }
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        public void showAllAssets()
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Asset.* FROM[Asset] ";

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(reader.GetInt32(0) + ", ");
                    Console.Write(reader.GetString(1) + ", ");
                    Console.Write(reader.GetValue(2) + ", ");
                    Console.Write(reader.GetString(7) + ", ");
                    Console.Write(reader.GetString(3) + ", ");
                    Console.Write(reader.GetString(4) + ", ");
                    Console.Write(reader.GetString(5));
                    Console.WriteLine();
                }
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        } 

        #endregion
    }
}
