using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC627_Project.Enums;
using DAC627_Project.Database_Classes;

namespace DAC627_Project
{
    class DataBaseAccess
    {
        private OleDbConnection connection;

        public DataBaseAccess()
        {
            
        }

        /// <summary>
        /// Start the connection to the database.
        /// </summary>
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

        /// <summary>
        /// Close the connection to the database.
        /// </summary>
        public void closeConnection()
        {
            connection.Close();
        }


        /// <summary>
        /// Executes the given command
        /// </summary>
        /// <param name="commandText">The command to execute</param>
        private void executeCommand(string commandText)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = commandText;

                command.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        #region add commands

        /// <summary>
        /// Adds an user to the database
        /// </summary>
        /// <param name="password">The password for the user</param>
        /// <param name="email">The email of the user</param>
        /// <param name="username">Tbe username</param>
        /// <param name="type">Type of user (see UserType class)</param>
        /// <param name="status">The current status of the user (see UserStatus class)</param>
        public void addUser(string password, string email, string username, UserType type, UserStatus status = UserStatus.Offline)
        {
            string commandText = "INSERT INTO [User] (Status, [Password], Email, Username, Type ) VALUES " +
                                "('" + status + "','" + password + "','" + email + "','" + username + "','" + type + "')";

            executeCommand(commandText);
        }

        /// <summary>
        /// Adds an project to the database
        /// </summary>
        /// <param name="name">The name of the project</param>
        /// <param name="type">The type of the project</param>
        /// <param name="description">Description for the project</param>
        /// <param name="owner">The ID of the project owner</param>
        /// <param name="tag">Tag for the project</param>
        /// <param name="status">The current status of the project</param>
        public void addProject(string name, ProjectType type, string description, int owner, ProjectTag tag, ProjectStatus status)
        {
            string commandText = "INSERT INTO Project ( Projectname, Type, Description, Owner, Tag, Status ) VALUES " +
                                    "('" + name + "','" + type + "','" + description + "','" + owner + "','" + tag + "','" + status + "')";

            executeCommand(commandText);
        }

        /// <summary>
        /// Adds an asset to the database
        /// </summary>
        /// <param name="name">The name of the asset</param>
        /// <param name="creator">The ID of the creator</param> 
        /// <param name="status">The current status of the asset</param>
        /// <param name="tag">Tag for the asset</param>
        /// <param name="software">The software used to create the asset</param>
        /// <param name="version">The version of the used software</param>
        public void addAsset(string name, int creator, AssetStatus status, AssetTag tag, string software, string version = "1.0")
        {
            string commandText = "INSERT INTO Asset ( Assetname, Creator, [Software Version], Status, Tag, Software ) VALUES " +
                                    "('" + name + "'," + creator + ",'" + version + "','" + status + "','" + tag + "', '"+ software +"')";

            executeCommand(commandText);
        }

        #endregion

        #region get commands

        /// <summary>
        /// Get a specific user
        /// </summary>
        /// <param name="username">The name of the user</param>
        /// <returns></returns>
        public DatabaseUser GetUser(string username)
        {
        
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT User.* FROM[User] WHERE Username = '" + username+"'";
        
            OleDbDataReader reader = command.ExecuteReader();

             string password = "";
             string email = "";
             int id = 1;
             UserStatus status = UserStatus.Offline;
             UserType type = UserType.Developer;

             while (reader.Read())
             {
                 id = reader.GetInt32(0);
                 Enum.TryParse<UserStatus>(reader.GetString(1), out status);
                 password = reader.GetString(2);
                 email = reader.GetString(3);
                 Enum.TryParse<UserType>(reader.GetString(5), out type);
             }

             return new DatabaseUser(id, username, password, email, type, status);
        }

        /// <summary>
        /// Get a specific user
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <returns></returns>
        public DatabaseUser GetUser(int id)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT User.* FROM[User] WHERE ID = " + id;

                OleDbDataReader reader = command.ExecuteReader();

                string password = "";
                string email = "";
                string username = "";
                UserStatus status = UserStatus.Offline;
                UserType type = UserType.Developer;

                while (reader.Read())
                {
                    Enum.TryParse<UserStatus>(reader.GetString(1), out status);
                    password = reader.GetString(2);
                    email = reader.GetString(3);
                    username = reader.GetString(4);
                    Enum.TryParse<UserType>(reader.GetString(5), out type);
                }

                return new DatabaseUser(id, username, password, email, type, status);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public DatabaseProject getProject(string projectname)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Project.* FROM[Project] ";

                OleDbDataReader reader = command.ExecuteReader();

                string description = "";
                int ownerID = 1;
                ProjectType type = ProjectType.Game;
                ProjectStatus status = ProjectStatus.Completed;
                ProjectTag tag = ProjectTag.Game;

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

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        #endregion

        #region change values

        #region change user values

        /// <summary>
        /// Change the username
        /// </summary>
        /// <param name="oldValue">Old username</param>
        /// <param name="newValue">New username</param>
        public void changeUserName(string oldValue, string newValue)
        {
            string commandText = "UPDATE [User] SET Username = '" + newValue + "' WHERE Username = '" + oldValue + "'";

            executeCommand(commandText);
        }

        /// <summary>
        /// Change the username
        /// </summary>
        /// <param name="id">The ID of the User</param>
        /// <param name="newValue">New username</param>
        public void changeUserName(int id, string newValue)
        {
            string commandText = "UPDATE [User] SET Username = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }
        
        /// <summary>
        /// Change the email for an user
        /// </summary>
        /// <param name="username">The name of the user</param>
        /// <param name="newValue">New Email of the user</param>
        public void changeUserEmail(string username, string newValue)
        {
            string commandText = "UPDATE [User] SET Email = '" + newValue + "' WHERE Username = '" + username + "'";

            executeCommand(commandText);
        }

        /// <summary>
        /// Change the email for an user
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <param name="newValue">New Email of the user</param>
        public void changeUserEmail(int id, string newValue)
        {
            string commandText = "UPDATE [User] SET Email = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        /// <summary>
        /// Change the type of an user
        /// </summary>
        /// <param name="username">The name of the user</param>
        /// <param name="newValue">New type for the user</param>
        public void changeUserType(string username, UserType newValue)
        {
            string commandText = "UPDATE [User] SET Type = '" + newValue + "' WHERE Username = '" + username + "'";

            executeCommand(commandText);
        }

        /// <summary>
        /// Change the type of an user
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <param name="newValue">New type for the user</param>
        public void changeUserType(int id, UserType newValue)
        {
            string commandText = "UPDATE [User] SET Type = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        /// <summary>
        /// Change the current status of the user
        /// </summary>
        /// <param name="username">The name of the user</param>
        /// <param name="newValue">New status of the user</param>
        public void changeUserStatus(string username, UserStatus newValue)
        {
            string commandText = "UPDATE [User] SET Status = '" + newValue + "' WHERE Username = '" + username + "'";

            executeCommand(commandText);
        }

        /// <summary>
        /// Change the current status for the user
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <param name="newValue">New status of the user</param>
        public void changeUserStatus(int id, UserStatus newValue)
        {
            string commandText = "UPDATE [User] SET Status = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }
        
        /// <summary>
        /// Change the password of an user
        /// </summary>
        /// <param name="username">The name of the user</param>
        /// <param name="newValue">New password of the user</param>
        public void changeUserPassword(string username, string newValue)
        {
            string commandText = "UPDATE [User] SET [Password] = '" + newValue + "' WHERE Username = '" + username + "'";

            executeCommand(commandText);
        }

        /// <summary>
        /// Change the password of an user
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <param name="newValue">New Password of the user</param>
        public void changeUserPassword(int id, string newValue)
        {
            string commandText = "UPDATE [User] SET [Password] = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        #endregion

        #region change project values

        /// <summary>
        /// Changes the name of a project
        /// </summary>
        /// <param name="oldValue">The old project name</param>
        /// <param name="newValue">New project name</param>
        public void changeProjectName(string oldValue, string newValue)
        {
            string commandText = "UPDATE [Project] SET Projectname = '" + newValue + "' WHERE Projectname = '" + oldValue + "'";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the name of a project
        /// </summary>
        /// <param name="id">The ID of the project</param>
        /// <param name="newValue">New project name</param>
        public void changeProjectName(int id, string newValue)
        {
            string commandText = "UPDATE [Project] SET Projectname = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the type of the project
        /// </summary>
        /// <param name="projectname">The name of the project</param>
        /// <param name="newValue">New type for the project</param>
        public void changeProjectType(string projectname, ProjectType newValue)
        {
            string commandText = "UPDATE [Project] SET Type = '" + newValue + "' WHERE Projectname = '" + projectname + "'";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the type of the project
        /// </summary>
        /// <param name="id">The ID of the project</param>
        /// <param name="newValue">New type for the project</param>
        public void changeProjectType(int id, ProjectType newValue)
        {
            string commandText = "UPDATE [Project] SET Type = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the description of the project
        /// </summary>
        /// <param name="projectname">The name of the project</param>
        /// <param name="newValue">New description of the project</param>
        public void changeProjectDescription(string projectname, string newValue)
        {
            string commandText = "UPDATE [Project] SET Description = '" + newValue + "' WHERE Projectname = '" + projectname + "'";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the description of the project
        /// </summary>
        /// <param name="id">The ID of the project</param>
        /// <param name="newValue">New description of the project</param>
        public void changeProjectDescription(int id, string newValue)
        {
            string commandText = "UPDATE [Project] SET Description = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the owner of the project
        /// </summary>
        /// <param name="projectname">The name of the project</param>
        /// <param name="newValue">The ID of the new owner</param>
        public void changeProjectOwner(string projectname, int newValue)
        {
            string commandText = "UPDATE [Project] SET Owner = " + newValue + " WHERE Projectname = '" + projectname + "'";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the owner of the project
        /// </summary>
        /// <param name="id">The ID of the project</param>
        /// <param name="newValue">The ID of the new owner</param>
        public void changeProjectOwner(int id, int newValue)
        {
           string commandText = "UPDATE [Project] SET Owner = " + newValue + " WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the Tag of the project
        /// </summary>
        /// <param name="projectname">The name of the project</param>
        /// <param name="newValue">New tag of the project</param>
        public void changeProjectTag(string projectname, ProjectTag newValue)
        {
            string commandText = "UPDATE [Project] SET Tag = '" + newValue + "' WHERE Projectname = '" + projectname + "'";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the Tag of the project
        /// </summary>
        /// <param name="id">The ID of the project</param>
        /// <param name="newValue">New tag for the project</param>
        public void changeProjectTag(int id, int newValue)
        {
            string commandText = "UPDATE [Project] SET Tag = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the current status of the project
        /// </summary>
        /// <param name="projectname"></param>
        /// <param name="newValue"></param>
        public void changeProjectStatus(string projectname, ProjectStatus newValue)
        {
            string commandText = "UPDATE [Project] SET Status = '" + newValue + "' WHERE Projectname = '" + projectname + "'";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the current status of the project
        /// </summary>
        /// <param name="id">The ID of the project</param>
        /// <param name="newValue">New status of the project</param>
        public void changeProjectStatus(int id, ProjectStatus newValue)
        {
            string commandText = "UPDATE [Project] SET Status = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }


        #endregion

        #region change asset values

        /// <summary>
        /// Changes the name of the asset
        /// </summary>
        /// <param name="oldValue">Old name of the asset</param>
        /// <param name="newValue">New name of the asset</param>
        public void changeAssetName(string oldValue, string newValue)
        {
            string commandText = "UPDATE [Asset] SET Assetname = '" + newValue + "' WHERE Assetname = '" + oldValue + "'";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the name of the asset
        /// </summary>
        /// <param name="id">The ID of the asset</param>
        /// <param name="newValue">New name of the asset</param>
        public void changeAssetName(int id, string newValue)
        {
            string commandText = "UPDATE [Asset] SET Assetname = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the creator of the asset (Logically only to deleted when the user is deleted)
        /// </summary>
        /// <param name="assetname">The name of the asset</param>
        /// <param name="newValue">The ID of the new creator of the asset</param>
        public void changeAssetCreator(string assetname, int newValue)
        {
            string commandText = "UPDATE [Asset] SET Creator = " + newValue + " WHERE Assetname = '" + assetname + "'";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the creator of the asset (Logically only to deleted when the user is deleted)
        /// </summary>
        /// <param name="id">The ID of the asset</param>
        /// <param name="newValue">The ID of the new creator of the asset</param>
        public void changeAssetCreator(int id, int newValue)
        {
            string commandText = "UPDATE [Asset] SET Creator = " + newValue + " WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the software used to create the asset
        /// </summary>
        /// <param name="assetname">The name of the asset</param>
        /// <param name="newValue">New software used to create the asset</param>
        public void changeAssetSoftware(string assetname, string newValue)
        {
            string commandText = "UPDATE [Asset] SET Software  = '" + newValue + "' WHERE Assetname = '" + assetname + "'";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the software used to create the asset
        /// </summary>
        /// <param name="id">The ID of the asset</param>
        /// <param name="newValue">New software used to create the asset</param>
        public void changeAssetSoftware(int id, string newValue)
        {
            string commandText = "UPDATE [Asset] SET Software = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the software version used for the asset
        /// </summary>
        /// <param name="assetname">The name of the asset</param>
        /// <param name="newValue">New software version used for the asset</param>
        public void changeAssetVersion(string assetname, string newValue)
        {
            string commandText = "UPDATE [Asset] SET [Software Version] = '" + newValue + "' WHERE Assetname = '" + assetname + "'";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the software version used for the asset
        /// </summary>
        /// <param name="id">The ID of the asset</param>
        /// <param name="newValue">New software version used for the asset</param>
        public void changeAssetVersion(int id, string newValue)
        {
            string commandText = "UPDATE [Asset] SET [Software Version] = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the current status of the asset
        /// </summary>
        /// <param name="assetname">The name of the asset</param>
        /// <param name="newValue">New status of the asset</param>
        public void changeAssetStatus(string assetname, AssetStatus newValue)
        {
            string commandText = "UPDATE [Asset] SET Status = '" + newValue + "' WHERE Assetname = '" + assetname + "'";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the current status of the asset
        /// </summary>
        /// <param name="id">The ID of the asset</param>
        /// <param name="newValue">New status of the asset</param>
        public void changeAssetStatus(int id, AssetStatus newValue)
        {
            string commandText = "UPDATE [Asset] SET Status = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the tag of the asset
        /// </summary>
        /// <param name="assetname">The name of the asset</param>
        /// <param name="newValue">New status of the asset</param>
        public void changeAssetTag(string assetname, AssetTag newValue)
        {
            string commandText = "UPDATE [Asset] SET Tag = '" + newValue + "' WHERE Assetname = '" + assetname + "'";

            executeCommand(commandText);
        }

        /// <summary>
        /// Changes the tag of the asset
        /// </summary>
        /// <param name="id">The ID of the asset</param>
        /// <param name="newValue">New tag of the asset</param>
        public void changeAssetTag(int id, AssetTag newValue)
        {
            string commandText = "UPDATE [Asset] SET Tag = '" + newValue + "' WHERE ID = " + id + "";

            executeCommand(commandText);
        }

        #endregion

        #endregion

        #region return tables 

        /// <summary>
        /// Shows a list of all users
        /// </summary>
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

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Shows a list of all projects
        /// </summary>
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

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Shows a list of all assets
        /// </summary>
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

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        } 

        #endregion
    }
}
