﻿using System;
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
        public void StartConnection()
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
        public void CloseConnection()
        {
            connection.Close();
        }


        /// <summary>
        /// Executes the given command
        /// </summary>
        /// <param name="commandText">The command to execute</param>
        private void ExecuteCommand(string commandText)
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

        #region search commands

        public List<DatabaseProject> SearchProject(String name = null, ProjectType typeSearch = ProjectType.Null, ProjectTag tagSearch = ProjectTag.Null, ProjectStatus statusSearch = ProjectStatus.Null)
        {
            try
            {
                List<DatabaseProject> result = new List<DatabaseProject>();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                string commandtext = "SELECT Project.* FROM[Project] ";

                if(name != null || typeSearch != ProjectType.Null || tagSearch != ProjectTag.Null || statusSearch != ProjectStatus.Null)
                {
                    commandtext += "WHERE ";
                    bool added = false;


                    if (name != null)
                    {
                        commandtext += "UCase(Projectname) like UCase('%" + name + "%') ";
                        added = true;
                    }
                    if (typeSearch != ProjectType.Null && !added)
                    {
                        commandtext += "Type = '" + typeSearch + "' ";
                        added = true;
                    }
                    else if (typeSearch != ProjectType.Null)
                        commandtext += "AND Type = '" + typeSearch + "' ";
                    if (tagSearch != ProjectTag.Null && !added)
                    {
                        commandtext += "Tag = '" + tagSearch + "' ";
                        added = true;
                    }
                    else if(tagSearch != ProjectTag.Null)
                        commandtext += "AND Tag = '" + tagSearch + "' ";
                    if (statusSearch != ProjectStatus.Null && !added)
                        commandtext += "Status = '" + statusSearch + "' ";
                    else if(statusSearch != ProjectStatus.Null)
                        commandtext += "AND Status = '" + statusSearch + "' ";
                }

                command.CommandText = commandtext;

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string projectname = reader.GetString(1);
                    ProjectType type;
                    ProjectTag tag;
                    ProjectStatus status;

                    Enum.TryParse<ProjectType>(reader.GetString(2), out type);
                    string description = reader.GetString(3);
                    int ownerID = reader.GetInt32(4);
                    Enum.TryParse<ProjectTag>(reader.GetString(5), out tag);
                    Enum.TryParse<ProjectStatus>(reader.GetString(6), out status);

                    DatabaseUser owner = GetUser(ownerID);

                    result.Add(new DatabaseProject(id, projectname, description, owner, type, status, tag));
                }

                return result;
            }
                       

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return null;
        }

        public List<DatabaseAsset> SearchAsset(String name = null, AssetType typeSearch = AssetType.Null, AssetStatus statusSearch = AssetStatus.Null, int pegi = 0)
        {
            try
            {
                List<DatabaseAsset> result = new List<DatabaseAsset>();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                string commandtext = "SELECT Asset.* FROM[Asset] ";

                if (name != null || typeSearch != AssetType.Null || statusSearch != AssetStatus.Null || pegi != 0)
                {
                    commandtext += "WHERE ";
                    bool added = false;


                    if (name != null)
                    {
                        commandtext += "UCase(Assetname) like UCase('%" + name + "%') ";
                        added = true;
                    }
                    if (typeSearch != AssetType.Null && !added)
                    {
                        commandtext += "Type = '" + typeSearch + "' ";
                        added = true;
                    }
                    else if (typeSearch != AssetType.Null)
                        commandtext += "AND Type = '" + typeSearch + "' ";
                    if (statusSearch != AssetStatus.Null && !added)
                    {
                        commandtext += "Status = '" + statusSearch + "' ";
                        added = true;
                    }
                    else if (statusSearch != AssetStatus.Null)
                        commandtext += "AND Status = '" + statusSearch + "' ";
                    if (pegi != 0 && !added)
                        commandtext += "PegiRating = " + pegi + " ";
                    else if (pegi != 0)
                        commandtext += "AND PegiRating = " + pegi + " ";
                }

                command.CommandText = commandtext;

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = 1;
                    string assetname = "";
                    string notes = "";
                    AssetType type = AssetType.Image;
                    AssetStatus status = AssetStatus.Completed;
                    String software = "";
                    int pegiRating = 3;

                    id = reader.GetInt32(0);
                    assetname = reader.GetString(1);
                    notes = reader.GetString(3);
                    Enum.TryParse<AssetStatus>(reader.GetString(4), out status);
                    Enum.TryParse<AssetType>(reader.GetString(5), out type);
                    software = reader.GetString(7);
                    pegiRating = reader.GetInt32(8);
                    Console.WriteLine();

                    result.Add(new DatabaseAsset(id, assetname, notes, null, type, status, software, pegiRating));
                }

                return result;
            }


            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return null;
        }

        #endregion

        #region Add commands

        /// <summary>
        /// Adds an user to the database
        /// </summary>
        /// <param name="password">The password for the user</param>
        /// <param name="email">The email of the user</param>
        /// <param name="username">Tbe username</param>
        /// <param name="type">Type of user (see UserType class)</param>
        /// <param name="status">The current status of the user (see UserStatus class)</param>
        public void AddUser(string password, string email, string username, UserType type, UserStatus status = UserStatus.Offline)
        {
            string commandText = "INSERT INTO [User] (Status, [Password], Email, Username, Type ) VALUES " +
                                "('" + status + "','" + password + "','" + email + "','" + username + "','" + type + "')";

            ExecuteCommand(commandText);
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
        public void AddProject(string name, ProjectType type, string description, int owner, ProjectTag tag, ProjectStatus status)
        {
            string commandText = "INSERT INTO Project ( Projectname, Type, Description, Owner, Tag, Status ) VALUES " +
                                    "('" + name + "','" + type + "','" + description + "','" + owner + "','" + tag + "','" + status + "')";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Adds an asset to the database
        /// </summary>
        /// <param name="name">The name of the asset</param>
        /// <param name="creator">The ID of the creator</param> 
        /// <param name="status">The current status of the asset</param>
        /// <param name="tag">Tag for the asset</param>
        /// <param name="software">The software used to create the asset</param>
        /// <param name="notes">The notes of the asset</param>
        public void AddAsset(string name, int creator, AssetStatus status, AssetType tag, string software, string notes = "1.0")
        {
            string commandText = "INSERT INTO Asset ( Assetname, Creator, Notes, Status, Tag, Software ) VALUES " +
                                    "('" + name + "'," + creator + ",'" + notes + "','" + status + "','" + tag + "', '"+ software +"')";

            ExecuteCommand(commandText);
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

                int id = 1;
                string description = "";
                int ownerID = 1;
                ProjectType type = ProjectType.Game;
                ProjectStatus status = ProjectStatus.Completed;
                ProjectTag tag = ProjectTag.Game;

                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    Enum.TryParse<ProjectType>(reader.GetString(2), out type);
                    description = reader.GetString(3);
                    ownerID = reader.GetInt32(4);
                    Enum.TryParse<ProjectTag>(reader.GetString(5), out tag);
                    Enum.TryParse<ProjectStatus>(reader.GetString(6), out status);
                }

                DatabaseUser owner = GetUser(ownerID);

                return new DatabaseProject(id, projectname, description, owner, type, status, tag);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return null;
        }

        public DatabaseProject getProject(int projectID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Project.* FROM[Project] ";

                OleDbDataReader reader = command.ExecuteReader();

                string projectName = "";
                string description = "";
                int ownerID = 1;
                ProjectType type = ProjectType.Game;
                ProjectStatus status = ProjectStatus.Completed;
                ProjectTag tag = ProjectTag.Game;

                while (reader.Read())
                {
                    projectName = reader.GetString(1);
                    Enum.TryParse<ProjectType>(reader.GetString(2), out type);
                    description = reader.GetString(3);
                    ownerID = reader.GetInt32(4);
                    Enum.TryParse<ProjectTag>(reader.GetString(5), out tag);
                    Enum.TryParse<ProjectStatus>(reader.GetString(6), out status);
                }

                DatabaseUser owner = GetUser(ownerID);

                return new DatabaseProject(projectID, projectName, description, owner, type, status, tag);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return null;
        }

        public DatabaseAsset getAsset(string assetname)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Asset.* FROM[Asset] ";

                OleDbDataReader reader = command.ExecuteReader();

                int id = 1;
                string notes = "";
                int creatorID = 1;
                AssetType type = AssetType.Image;
                AssetStatus status = AssetStatus.Completed;
                String software = "";
                int pegiRating = 3;

                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    creatorID = reader.GetInt32(2);
                    notes = (reader.GetString(7));
                    Enum.TryParse<AssetStatus>(reader.GetString(3), out status);
                    Enum.TryParse<AssetType>(reader.GetString(4), out type);
                    software = reader.GetString(5);
                    pegiRating = reader.GetInt32(8);
                    Console.WriteLine();                    
                }

                DatabaseUser creator = GetUser(creatorID);

                return new DatabaseAsset(id, assetname, notes, creator, type, status, software, pegiRating);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return null;
        }

        public DatabaseAsset getAsset(int assetID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Asset.* FROM[Asset] ";

                OleDbDataReader reader = command.ExecuteReader();

                string assetname = "";
                string notes = "";
                int creatorID = 1;
                AssetType type = AssetType.Image;
                AssetStatus status = AssetStatus.Completed;
                String software = "";
                int pegiRating = 3;

                while (reader.Read())
                {
                    assetname = reader.GetString(1);
                    creatorID = reader.GetInt32(2);
                    notes = (reader.GetString(7));
                    Enum.TryParse<AssetStatus>(reader.GetString(3), out status);
                    Enum.TryParse<AssetType>(reader.GetString(4), out type);
                    software = reader.GetString(5);
                    pegiRating = reader.GetInt32(8);
                    Console.WriteLine();
                }

                DatabaseUser creator = GetUser(creatorID);

                return new DatabaseAsset(assetID, assetname, notes, creator, type, status, software, pegiRating);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return null;
        }

        public List<DatabaseAsset> getAssetsOfUser(int userID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Asset.* FROM[Asset] WHERE Creator = "+userID;

                OleDbDataReader reader = command.ExecuteReader();

                List<DatabaseAsset> result = new List<DatabaseAsset>();

                while (reader.Read())
                {
                    int id = 1;
                    string assetname = "";
                    string notes = "";
                    AssetType type = AssetType.Image;
                    AssetStatus status = AssetStatus.Completed;
                    String software = "";
                    int pegiRating = 3;

                    id = reader.GetInt32(0);
                    assetname = reader.GetString(1);
                    notes = reader.GetString(3);
                    Enum.TryParse<AssetStatus>(reader.GetString(4), out status);
                    Enum.TryParse<AssetType>(reader.GetString(5), out type);
                    software = reader.GetString(7);
                    pegiRating = reader.GetInt32(8);
                    Console.WriteLine();

                    result.Add(new DatabaseAsset(id, assetname, notes, null, type, status, software, pegiRating));
                }

                return result;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return null;
        }

        public List<DatabaseProject> getProjectsOfUser(int userID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT Project.* FROM[Project] project" +
                    " Inner join [UsersInProjects] uip" +
                    " On uip.ProjectID = project.ID " +
                    " WHERE uip.UserID = "+userID;

                OleDbDataReader reader = command.ExecuteReader();

                List<DatabaseProject> result = new List<DatabaseProject>();

                while (reader.Read())
                {
                    int id = 1;
                    string projectName = "";
                    string description = "";
                    ProjectType type = ProjectType.Game;
                    ProjectStatus status = ProjectStatus.Completed;
                    ProjectTag tag = ProjectTag.Game;

                    id = reader.GetInt32(0);
                    projectName = reader.GetString(1);
                    Enum.TryParse<ProjectType>(reader.GetString(2), out type);
                    description = reader.GetString(3);
                    Enum.TryParse<ProjectTag>(reader.GetString(5), out tag);
                    Enum.TryParse<ProjectStatus>(reader.GetString(6), out status);

                    result.Add(new DatabaseProject(id, projectName, description, null, type, status, tag));
                }

                return result;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return null;
        }

        public List<DatabaseAsset> getAssetsInProject(int projectID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT Asset.* FROM[Asset] asset " +
                    "Inner join [AssetsInProjects] aip " +
                    "On aip.AssetID = asset.ID " +
                    "WHERE aip.ProjectID = "+projectID;

                OleDbDataReader reader = command.ExecuteReader();

                List<DatabaseAsset> result = new List<DatabaseAsset>();

                while (reader.Read())
                {
                    int id = 1;
                    string assetname = "";
                    string notes = "";
                    AssetType type = AssetType.Image;
                    AssetStatus status = AssetStatus.Completed;
                    String software = "";
                    int pegiRating = 3;

                    id = reader.GetInt32(0);
                    assetname = reader.GetString(1);
                    notes = reader.GetString(3);
                    Enum.TryParse<AssetStatus>(reader.GetString(4), out status);
                    Enum.TryParse<AssetType>(reader.GetString(5), out type);
                    software = reader.GetString(7);
                    pegiRating = reader.GetInt32(8);
                    Console.WriteLine();

                    result.Add(new DatabaseAsset(id, assetname, notes, null, type, status, software, pegiRating));
                }

                return result;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return null;
        }

        public List<DatabaseUser> getUsersInProject(int projectID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT User.* FROM [User]" +
                    " Inner join [UsersInProjects]" +
                    " On [UsersInProjects].UserID = [User].ID " +
                    " WHERE [UsersInProjects].ProjectID = " + projectID;

                OleDbDataReader reader = command.ExecuteReader();

                List<DatabaseUser> result = new List<DatabaseUser>();                

                while (reader.Read())
                {
                    string password = "";
                    string email = "";
                    int id = 1;
                    UserStatus status = UserStatus.Offline;
                    UserType type = UserType.Developer;
                    string username = "";

                    id = reader.GetInt32(0);
                    Enum.TryParse<UserStatus>(reader.GetString(1), out status);
                    password = reader.GetString(2);
                    email = reader.GetString(3);
                    username = reader.GetString(4);
                    Enum.TryParse<UserType>(reader.GetString(5), out type);

                    result.Add(new DatabaseUser(id, username, password, email, type, status));
                }  

                return result;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return null;
        }

        public List<DatabaseProject> getOwnedProjectsOfUser(int userID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Project.* FROM[Project] WHERE Owner = " + userID;

                OleDbDataReader reader = command.ExecuteReader();

                List<DatabaseProject> result = new List<DatabaseProject>();

                while (reader.Read())
                {

                    int id = 1;
                    string projectName = "";
                    string description = "";
                    ProjectType type = ProjectType.Game;
                    ProjectStatus status = ProjectStatus.Completed;
                    ProjectTag tag = ProjectTag.Game;

                    projectName = reader.GetString(1);
                    Enum.TryParse<ProjectType>(reader.GetString(2), out type);
                    description = reader.GetString(3);
                    Enum.TryParse<ProjectTag>(reader.GetString(5), out tag);
                    Enum.TryParse<ProjectStatus>(reader.GetString(6), out status);

                    result.Add(new DatabaseProject(id, projectName, description, null, type, status, tag));
                }

                return result;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return null;
        }

        #endregion

        #region Change values

        #region Change user values

        /// <summary>
        /// Change the username
        /// </summary>
        /// <param name="oldValue">Old username</param>
        /// <param name="newValue">New username</param>
        public void ChangeUserName(string oldValue, string newValue)
        {
            string commandText = "UPDATE [User] SET Username = '" + newValue + "' WHERE Username = '" + oldValue + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Change the username
        /// </summary>
        /// <param name="id">The ID of the User</param>
        /// <param name="newValue">New username</param>
        public void ChangeUserName(int id, string newValue)
        {
            string commandText = "UPDATE [User] SET Username = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }
        
        /// <summary>
        /// Change the email for an user
        /// </summary>
        /// <param name="username">The name of the user</param>
        /// <param name="newValue">New Email of the user</param>
        public void ChangeUserEmail(string username, string newValue)
        {
            string commandText = "UPDATE [User] SET Email = '" + newValue + "' WHERE Username = '" + username + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Change the email for an user
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <param name="newValue">New Email of the user</param>
        public void ChangeUserEmail(int id, string newValue)
        {
            string commandText = "UPDATE [User] SET Email = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Change the type of an user
        /// </summary>
        /// <param name="username">The name of the user</param>
        /// <param name="newValue">New type for the user</param>
        public void ChangeUserType(string username, UserType newValue)
        {
            string commandText = "UPDATE [User] SET Type = '" + newValue + "' WHERE Username = '" + username + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Change the type of an user
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <param name="newValue">New type for the user</param>
        public void ChangeUserType(int id, UserType newValue)
        {
            string commandText = "UPDATE [User] SET Type = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Change the current status of the user
        /// </summary>
        /// <param name="username">The name of the user</param>
        /// <param name="newValue">New status of the user</param>
        public void ChangeUserStatus(string username, UserStatus newValue)
        {
            string commandText = "UPDATE [User] SET Status = '" + newValue + "' WHERE Username = '" + username + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Change the current status for the user
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <param name="newValue">New status of the user</param>
        public void ChangeUserStatus(int id, UserStatus newValue)
        {
            string commandText = "UPDATE [User] SET Status = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }
        
        /// <summary>
        /// Change the password of an user
        /// </summary>
        /// <param name="username">The name of the user</param>
        /// <param name="newValue">New password of the user</param>
        public void ChangeUserPassword(string username, string newValue)
        {
            string commandText = "UPDATE [User] SET [Password] = '" + newValue + "' WHERE Username = '" + username + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Change the password of an user
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <param name="newValue">New Password of the user</param>
        public void ChangeUserPassword(int id, string newValue)
        {
            string commandText = "UPDATE [User] SET [Password] = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        #endregion

        #region Change project values

        /// <summary>
        /// Changes the name of a project
        /// </summary>
        /// <param name="oldValue">The old project name</param>
        /// <param name="newValue">New project name</param>
        public void ChangeProjectName(string oldValue, string newValue)
        {
            string commandText = "UPDATE [Project] SET Projectname = '" + newValue + "' WHERE Projectname = '" + oldValue + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the name of a project
        /// </summary>
        /// <param name="id">The ID of the project</param>
        /// <param name="newValue">New project name</param>
        public void ChangeProjectName(int id, string newValue)
        {
            string commandText = "UPDATE [Project] SET Projectname = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the type of the project
        /// </summary>
        /// <param name="projectname">The name of the project</param>
        /// <param name="newValue">New type for the project</param>
        public void ChangeProjectType(string projectname, ProjectType newValue)
        {
            string commandText = "UPDATE [Project] SET Type = '" + newValue + "' WHERE Projectname = '" + projectname + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the type of the project
        /// </summary>
        /// <param name="id">The ID of the project</param>
        /// <param name="newValue">New type for the project</param>
        public void ChangeProjectType(int id, ProjectType newValue)
        {
            string commandText = "UPDATE [Project] SET Type = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the description of the project
        /// </summary>
        /// <param name="projectname">The name of the project</param>
        /// <param name="newValue">New description of the project</param>
        public void ChangeProjectDescription(string projectname, string newValue)
        {
            string commandText = "UPDATE [Project] SET Description = '" + newValue + "' WHERE Projectname = '" + projectname + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the description of the project
        /// </summary>
        /// <param name="id">The ID of the project</param>
        /// <param name="newValue">New description of the project</param>
        public void ChangeProjectDescription(int id, string newValue)
        {
            string commandText = "UPDATE [Project] SET Description = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the owner of the project
        /// </summary>
        /// <param name="projectname">The name of the project</param>
        /// <param name="newValue">The ID of the new owner</param>
        public void ChangeProjectOwner(string projectname, int newValue)
        {
            string commandText = "UPDATE [Project] SET Owner = " + newValue + " WHERE Projectname = '" + projectname + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the owner of the project
        /// </summary>
        /// <param name="id">The ID of the project</param>
        /// <param name="newValue">The ID of the new owner</param>
        public void ChangeProjectOwner(int id, int newValue)
        {
           string commandText = "UPDATE [Project] SET Owner = " + newValue + " WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the Tag of the project
        /// </summary>
        /// <param name="projectname">The name of the project</param>
        /// <param name="newValue">New tag of the project</param>
        public void ChangeProjectTag(string projectname, ProjectTag newValue)
        {
            string commandText = "UPDATE [Project] SET Tag = '" + newValue + "' WHERE Projectname = '" + projectname + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the Tag of the project
        /// </summary>
        /// <param name="id">The ID of the project</param>
        /// <param name="newValue">New tag for the project</param>
        public void ChangeProjectTag(int id, int newValue)
        {
            string commandText = "UPDATE [Project] SET Tag = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the current status of the project
        /// </summary>
        /// <param name="projectname"></param>
        /// <param name="newValue"></param>
        public void ChangeProjectStatus(string projectname, ProjectStatus newValue)
        {
            string commandText = "UPDATE [Project] SET Status = '" + newValue + "' WHERE Projectname = '" + projectname + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the current status of the project
        /// </summary>
        /// <param name="id">The ID of the project</param>
        /// <param name="newValue">New status of the project</param>
        public void ChangeProjectStatus(int id, ProjectStatus newValue)
        {
            string commandText = "UPDATE [Project] SET Status = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }


        #endregion

        #region Change asset values

        /// <summary>
        /// Changes the name of the asset
        /// </summary>
        /// <param name="oldValue">Old name of the asset</param>
        /// <param name="newValue">New name of the asset</param>
        public void ChangeAssetName(string oldValue, string newValue)
        {
            string commandText = "UPDATE [Asset] SET Assetname = '" + newValue + "' WHERE Assetname = '" + oldValue + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the name of the asset
        /// </summary>
        /// <param name="id">The ID of the asset</param>
        /// <param name="newValue">New name of the asset</param>
        public void ChangeAssetName(int id, string newValue)
        {
            string commandText = "UPDATE [Asset] SET Assetname = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the creator of the asset (Logically only to deleted when the user is deleted)
        /// </summary>
        /// <param name="assetname">The name of the asset</param>
        /// <param name="newValue">The ID of the new creator of the asset</param>
        public void ChangeAssetCreator(string assetname, int newValue)
        {
            string commandText = "UPDATE [Asset] SET Creator = " + newValue + " WHERE Assetname = '" + assetname + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the creator of the asset (Logically only to deleted when the user is deleted)
        /// </summary>
        /// <param name="id">The ID of the asset</param>
        /// <param name="newValue">The ID of the new creator of the asset</param>
        public void ChangeAssetCreator(int id, int newValue)
        {
            string commandText = "UPDATE [Asset] SET Creator = " + newValue + " WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the software used to create the asset
        /// </summary>
        /// <param name="assetname">The name of the asset</param>
        /// <param name="newValue">New software used to create the asset</param>
        public void ChangeAssetSoftware(string assetname, string newValue)
        {
            string commandText = "UPDATE [Asset] SET Software  = '" + newValue + "' WHERE Assetname = '" + assetname + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the software used to create the asset
        /// </summary>
        /// <param name="id">The ID of the asset</param>
        /// <param name="newValue">New software used to create the asset</param>
        public void ChangeAssetSoftware(int id, string newValue)
        {
            string commandText = "UPDATE [Asset] SET Software = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the software notes
        /// </summary>
        /// <param name="assetname">The name of the asset</param>
        /// <param name="newValue">New notes for the asset</param>
        public void ChangeAssetNotes(string assetname, string newValue)
        {
            string commandText = "UPDATE [Asset] SET Notes = '" + newValue + "' WHERE Assetname = '" + assetname + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the notes for the asset
        /// </summary>
        /// <param name="id">The ID of the asset</param>
        /// <param name="newValue">New notes for the asset</param>
        public void ChangeAssetNotes(int id, string newValue)
        {
            string commandText = "UPDATE [Asset] SET Notes = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the current status of the asset
        /// </summary>
        /// <param name="assetname">The name of the asset</param>
        /// <param name="newValue">New status of the asset</param>
        public void ChangeAssetStatus(string assetname, AssetStatus newValue)
        {
            string commandText = "UPDATE [Asset] SET Status = '" + newValue + "' WHERE Assetname = '" + assetname + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the current status of the asset
        /// </summary>
        /// <param name="id">The ID of the asset</param>
        /// <param name="newValue">New status of the asset</param>
        public void ChangeAssetStatus(int id, AssetStatus newValue)
        {
            string commandText = "UPDATE [Asset] SET Status = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the tag of the asset
        /// </summary>
        /// <param name="assetname">The name of the asset</param>
        /// <param name="newValue">New status of the asset</param>
        public void ChangeAssetTag(string assetname, AssetType newValue)
        {
            string commandText = "UPDATE [Asset] SET Tag = '" + newValue + "' WHERE Assetname = '" + assetname + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the tag of the asset
        /// </summary>
        /// <param name="id">The ID of the asset</param>
        /// <param name="newValue">New tag of the asset</param>
        public void ChangeAssetTag(int id, AssetType newValue)
        {
            string commandText = "UPDATE [Asset] SET Tag = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        #endregion

        #endregion

        #region return tables 

        /// <summary>
        /// Shows a list of all users
        /// </summary>
        public void ShowAllUsers()
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
        public void ShowAllProjects()
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
        public void ShowAllAssets()
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
                    Console.Write(reader.GetString(5) + ", ");
                    Console.Write(reader.GetInt32(8));
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
