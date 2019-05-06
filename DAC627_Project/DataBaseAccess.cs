using DAC627_Project.Classes;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int amountOfConnectionTrys = 0;
            while (amountOfConnectionTrys < 10)
            {
                try
                {
                    connection = new OleDbConnection();
                    connection.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ../../Database/Database.accdb;
                    Persist Security Info = False;";
                    connection.Open();
                    return;
                }
                catch (Exception e)
                {
                    amountOfConnectionTrys++;
                    Console.WriteLine(e.Message);
                }
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
        /// <returns>Returns if the command was executed correctly</returns>
        private bool ExecuteCommand(string commandText)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = commandText;

                command.ExecuteNonQuery();

                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        #region search commands

        public List<UserProject> SearchProject(String name = null, ProjectType typeSearch = ProjectType.Null,
            ProjectTag tagSearch = ProjectTag.Null, ProjectStatus statusSearch = ProjectStatus.Null)
        {
            try
            {
                List<UserProject> result = new List<UserProject>();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                string commandtext = "SELECT Project.* FROM[Project] ";

                if (name != null || typeSearch != ProjectType.Null || tagSearch != ProjectTag.Null || statusSearch != ProjectStatus.Null)
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
                        commandtext += "UCase(Tags) like UCase('%" + tagSearch + "%')";
                        added = true;
                    }
                    else if (tagSearch != ProjectTag.Null)
                        commandtext += "AND UCase(Tags) like UCase('%" + tagSearch + "%')";
                    if (statusSearch != ProjectStatus.Null && !added)
                        commandtext += "Status = '" + statusSearch + "' ";
                    else if (statusSearch != ProjectStatus.Null)
                        commandtext += "AND Status = '" + statusSearch + "' ";
                }

                command.CommandText = commandtext;

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = int.Parse(reader["ID"].ToString());
                    string projectname = reader["Projectname"].ToString();
                    ProjectType type;
                    ProjectStatus status;

                    type = (ProjectType)Enum.Parse(typeof(ProjectType), reader["Type"].ToString());
                    string tags = reader["Tags"].ToString();
                    string description = reader["Description"].ToString();
                    int ownerID = int.Parse(reader["Owner"].ToString());
                    status = (ProjectStatus)Enum.Parse(typeof(ProjectStatus), reader["Status"].ToString());
                    string thumbnail = reader["Thumbnail"].ToString();

                    UsersAccounts.UserData owner = GetUser(ownerID);

                    result.Add(new UserProject(id, projectname, description, owner, type, status, tags, thumbnail));
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

        public List<UserAsset> SearchAsset(String name = null, string tags = null, AssetType typeSearch = AssetType._Null,
            AssetStatus statusSearch = AssetStatus.Null, PegiRating pegi = PegiRating._Null)
        {
            try
            {
                List<UserAsset> result = new List<UserAsset>();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                string commandtext = "SELECT Asset.* FROM[Asset] ";

                if (name != null || typeSearch != AssetType._Null || statusSearch != AssetStatus.Null || pegi != 0)
                {
                    commandtext += "WHERE ";
                    bool added = false;


                    if (name != null)
                    {
                        commandtext += "UCase(Assetname) like UCase('%" + name + "%') ";
                        added = true;
                    }
                    if (typeSearch != AssetType._Null && !added)
                    {
                        commandtext += "Type = '" + typeSearch + "' ";
                        added = true;
                    }
                    else if (typeSearch != AssetType._Null)
                        commandtext += "AND Type = '" + typeSearch + "' ";
                    if (statusSearch != AssetStatus.Null && !added)
                    {
                        commandtext += "Status = '" + statusSearch + "' ";
                        added = true;
                    }
                    else if (statusSearch != AssetStatus.Null)
                        commandtext += "AND Status = '" + statusSearch + "' ";
                    if (pegi != 0 && !added)
                    {
                        commandtext += "PegiRating = '" + pegi + "' ";
                        added = true;
                    }
                    else if (pegi != PegiRating._Null)
                        commandtext += "AND PegiRating = '" + pegi + "' ";
                    if (pegi != PegiRating._Null && !added)
                        commandtext += "UCase(Tags) like UCase('%" + tags + "%') ";
                    else if (pegi != 0)
                        commandtext += "AND UCase(Tags) like UCase('%" + tags + "%') ";
                }

                command.CommandText = commandtext;

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = 1;
                    string assetname = "";
                    string notes = "";
                    AssetType type = AssetType._2DArt;
                    AssetStatus status = AssetStatus.Completed;
                    String software = "";
                    PegiRating pegiRating = PegiRating._3;
                    string path = "";
                    string thumbnail = "";
                    string galleryOne = "";
                    string galleryTwo = "";
                    string galleryThree = "";
                    string galleryFour = "";
                    string galleryFive = "";

                    id = (int)reader["ID"];
                    assetname = reader["Assetname"].ToString();
                    notes = reader["Notes"].ToString();
                    status = (AssetStatus)Enum.Parse(typeof(AssetStatus), reader["Status"].ToString());
                    type = (AssetType)Enum.Parse(typeof(AssetType), reader["Type"].ToString());
                    software = reader["Software"].ToString();
                    pegiRating = (PegiRating)Enum.Parse(typeof(PegiRating), reader["PegiRating"].ToString());
                    tags = reader["Tags"].ToString();
                    path = reader["AssetPath"].ToString();
                    thumbnail = reader["ThumbnailPath"].ToString();
                    galleryOne = reader["GalleryOne"].ToString();
                    galleryTwo = reader["GalleryTwo"].ToString();
                    galleryThree = reader["GalleryThree"].ToString();
                    galleryFour = reader["GalleryFour"].ToString();
                    galleryFive = reader["GalleryFive"].ToString();
                    int creatorID = int.Parse(reader["Creator"].ToString());

                    UsersAccounts.UserData creator = GetUser(creatorID);

                    result.Add(new UserAsset(id, assetname, notes, creator, type, status, software, path, pegiRating, tags,
                    thumbnail, galleryOne, galleryTwo, galleryThree, galleryFour, galleryFive));
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
        /// <param name="profilePicture">The path to the profile picture</param>
        /// <returns>Returns the ID of the added User</returns>
        public int AddUser(string password, string email, string username, UserType type, string fullName,
            UserStatus status = UserStatus.Offline, string profilePicture = "")
        {
            string commandText = "INSERT INTO [User] (Status, [Password], Email, Username, Type, ProfilePicture, FullName ) VALUES " +
                                "('" + status + "','" + password + "','" + email + "','" + username + "'," +
                                "'" + type + "','" + profilePicture + "','" + fullName + "')";

            bool executed = ExecuteCommand(commandText);

            int id = 0;

            if (executed)
            {
                OleDbCommand command2 = new OleDbCommand();
                command2.Connection = connection;
                command2.CommandText = "SELECT User.ID FROM[User] WHERE Username = '" + username + "'";

                OleDbDataReader reader = command2.ExecuteReader();

                while (reader.Read())
                    id = reader.GetInt32(0);

            }
            return id;
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
        /// <param name="thumbnail">The current status of the project</param>
        /// <returns>Returns the ID of the added Project</returns>
        public int AddProject(string name, ProjectType type, string description, int owner,
            ProjectTag tag, ProjectStatus status, string thumbnail = "")
        {
            string commandText = "INSERT INTO Project ( Projectname, Type, Description, Owner, Tags, Status, Thumbnail ) VALUES " +
                                    "('" + name + "','" + type + "','" + description + "','" + owner + "','" + tag + "','"
                                    + status + "','" + thumbnail + "')";

            bool executed = ExecuteCommand(commandText);

            int id = 0;

            if (executed)
            {
                OleDbCommand command2 = new OleDbCommand();
                command2.Connection = connection;
                command2.CommandText = "SELECT Project.ID FROM[Project] WHERE Projectname = '" + name + "'";

                OleDbDataReader reader = command2.ExecuteReader();

                while (reader.Read())
                    id = reader.GetInt32(0);

            }
            return id;
        }

        /// <summary>
        /// Adds an asset to the database
        /// </summary>
        /// <param name="name">The name of the asset</param>
        /// <param name="creator">The ID of the creator</param> 
        /// <param name="status">The current status of the asset</param>
        /// <param name="type">Type of asset</param>
        /// <param name="software">The software used to create the asset</param>
        /// <param name="notes">The notes of the asset</param>
        /// <param name="tags">The tags of the asset</param>
        /// <param name="assetPath">The path to the asset</param>
        /// <param name="thumbnail">The pathfile to the thumbnail picture</param>
        /// <param name="galleryOne">The path to the first gallery picture</param>
        /// <param name="galleryTwo">The path to the second gallery picture</param>
        /// <param name="galleryThree">The path to the third gallery picture</param>
        /// <param name="galleryFour">The path to the fourth gallery picture</param>
        /// <param name="galleryFive">The path to the fifth gallery picture</param>
        /// <returns>Returns the ID of the added Asset</returns>
        public int AddAsset(string name, int creator, AssetStatus status, AssetType type,
            string software, string notes, string tags, PegiRating pegi, string assetPath = "", string thumbnail = "",
            string galleryOne = "", string galleryTwo = "", string galleryThree = "", string galleryFour = "", string galleryFive = "")
        {
            string commandText = "INSERT INTO Asset ( Assetname, Creator, Notes, Status, Type, Software, Tags, PegiRating," +
                "AssetPath, ThumbnailPath, GalleryOne, GalleryTwo, GalleryThree, GalleryFour, GalleryFive ) VALUES " +
                                    "('" + name + "'," + creator + ",'" + notes + "','" + status + "','" + type + "', '" + software + "'" +
                                    ",'" + tags + "','" + pegi + "','" + assetPath + "','" + thumbnail + "','" + galleryOne + "" +
                                    "','" + galleryTwo + "','" + galleryThree + "','" + galleryFour + "','" + galleryFive + "')";

            bool executed = ExecuteCommand(commandText);

            int id = 0;

            if (executed)
            {
                OleDbCommand command2 = new OleDbCommand();
                command2.Connection = connection;
                command2.CommandText = "SELECT Asset.ID FROM[Asset] WHERE Assetname = '" + name + "'";

                OleDbDataReader reader = command2.ExecuteReader();

                while (reader.Read())
                    id = reader.GetInt32(0);

            }

            return id;
        }

        /// <summary>
        /// Adds a message to the database
        /// </summary>
        /// <param name="senderID">The ID of the sender</param>
        /// <param name="receiverID">The ID of the receiving user</param>
        /// <param name="message">The message text</param>
        /// <param name="sended">The date when the message was sended</param>
        /// <param name="type">The type of message</param>
        public void AddMessage(int senderID, int receiverID, string message, DateTime sended, MessageType type)
        {
            // Removes miliseconds as it causes data type mismatch
            DateTime time = new DateTime(sended.Year, sended.Month, sended.Day, sended.Hour, sended.Minute, sended.Second);

            string commandText = "INSERT INTO Messages ( Sender, Receiver, Message, Type, SendedDate) VALUES " +
                                    "('" + senderID + "','" + receiverID + "','" + message + "','" + type + "','" + time + "')";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Adds an user to a project
        /// </summary>
        /// <param name="projectID">The ID of the project</param>
        /// <param name="userID">The ID of the User</param>
        public void AddUserToProject(int projectID, int userID)
        {
            string command = "INSERT INTO UsersInProjects ( ProjectID, UserID ) VALUES" +
                "(" + projectID + ", " + userID + " )";

            ExecuteCommand(command);
        }

        /// <summary>
        /// Adds an asset to a project
        /// </summary>
        /// <param name="projectID">The ID of the project</param>
        /// <param name="assetID">The ID of the asset</param>
        public void AddAssetToProject(int projectID, int assetID)
        {
            string command = "INSERT INTO AssetsInProjects ( ProjectID, AssetID ) VALUES" +
                "(" + projectID + ", " + assetID + " )";

            ExecuteCommand(command);
        }

        /// <summary>
        /// Adds a rating to the database
        /// </summary>
        /// <param name="userID">The ID of the reviewer</param>
        /// <param name="assetID">The ID of the reviewed asset</param>
        /// <param name="stars">The amount of stars given to the asset</param>
        /// <param name="comment">Comment about the asset by the reviewer</param>
        public void AddRating(int userID, int assetID, int stars, string comment)
        {
            string commandText = "INSERT INTO Ratings ( Reviewer, Asset, Stars, Comment) VALUES " +
                                    "(" + userID + "," + assetID + "," + stars + ",'" + comment + "')";

            ExecuteCommand(commandText);
        }

        #endregion

        #region Delete Commands

        public void DeleteProject(int projectID)
        {
            string command = "DELETE FROM [Project] WHERE ID = " + projectID;

            ExecuteCommand(command);
        }

        public void DeleteUser(int userID)
        {
            string command = "DELETE FROM [Messages] WHERE Sender = " + userID +
                "or Receiver = " + userID;

            ExecuteCommand(command);

            command = "DELETE FROM [User] WHERE ID = " + userID;

            ExecuteCommand(command);
        }

        public void DeleteAsset(int assetID)
        {
            string command = "DELETE FROM [Asset] WHERE ID = " + assetID;

            ExecuteCommand(command);
        }

        public void DeleteMessage(int messageID)
        {
            string command = "DELETE FROM [Messages] WHERE ID = " + messageID;

            ExecuteCommand(command);
        }


        public void DeleteRating(int ratingID)
        {
            string command = "DELETE FROM [Ratings] WHERE ID = " + ratingID;

            ExecuteCommand(command);
        }

        #endregion

        #region Remove Commands

        /// <summary>
        /// Removes an asset from a project
        /// </summary>
        /// <param name="projectID">The ID of the project</param>
        /// <param name="assetID">The ID of the asset</param>
        public void RemoveAssetFromProject(int projectID, int assetID)
        {
            string command = "DELETE FROM [AssetsInProjects] WHERE ProjectID = " + projectID + " AND AssetID = " + assetID;

            ExecuteCommand(command);
        }

        /// <summary>
        /// Removes an user from a project
        /// </summary>
        /// <param name="projectID">The ID of the project</param>
        /// <param name="userID">The ID of the User</param>
        public void RemoveUserFromProject(int projectID, int userID)
        {
            string command = "DELETE FROM [UsersInProjects] WHERE ProjectID = " + projectID + " AND UserID = " + userID;

            ExecuteCommand(command);
        }

        #endregion

        #region Get commands

        /// <summary>
        /// Get a specific user
        /// </summary>
        /// <param name="username">The name of the user</param>
        /// <returns>The specified User</returns>
        public UsersAccounts.UserData GetUser(string username)
        {

            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT User.* FROM[User] WHERE Username = '" + username + "'";

            OleDbDataReader reader = command.ExecuteReader();

            string password = "";
            string email = "";
            int id = 0;
            UserStatus status = UserStatus.Offline;
            UserType type = UserType.Developer;
            string profile = "";
            string fullName = "";

            while (reader.Read())
            {
                id = int.Parse(reader["ID"].ToString());
                status = (UserStatus)Enum.Parse(typeof(UserStatus), reader["Status"].ToString());
                password = reader["Password"].ToString();
                email = reader["Email"].ToString();
                type = (UserType)Enum.Parse(typeof(UserType), reader["Type"].ToString());
                profile = reader["ProfilePicture"].ToString();
                fullName = reader["FullName"].ToString();
            }
            if (id == 0)
            {
                return null;
            }   
            return new UsersAccounts.UserData(id, username, password, email, type, status, profile, fullName);
        }

        /// <summary>
        /// Get a specific user
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <returns>The specified User</returns>
        public UsersAccounts.UserData GetUser(int id)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT User.* FROM[User] WHERE ID = " + id;

                OleDbDataReader reader = command.ExecuteReader();

                string username = "";
                string password = "";
                string email = "";
                UserStatus status = UserStatus.Offline;
                UserType type = UserType.Developer;
                string profile = "";
                string fullName = "";

                while (reader.Read())
                {
                    id = int.Parse(reader["ID"].ToString());
                    status = (UserStatus)Enum.Parse(typeof(UserStatus), reader["Status"].ToString());
                    password = reader["Password"].ToString();
                    email = reader["Email"].ToString();
                    type = (UserType)Enum.Parse(typeof(UserType), reader["Type"].ToString());
                    profile = reader["ProfilePicture"].ToString();
                    username = reader["Username"].ToString();
                    fullName = reader["FullName"].ToString();
                }

                return new UsersAccounts.UserData(id, username, password, email, type, status, profile, fullName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Get a specific project
        /// </summary>
        /// <param name="projectname">The name of the Project</param>
        /// <returns>The specified project</returns>
        public UserProject getProject(string projectname)
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
                string tags = "";
                string thumbnail = "";
                ProjectType type = ProjectType.Game;
                ProjectStatus status = ProjectStatus.Completed;

                while (reader.Read())
                {
                    id = int.Parse(reader["ID"].ToString());

                    type = (ProjectType)Enum.Parse(typeof(ProjectType), reader["Type"].ToString());
                    tags = reader["Tags"].ToString();
                    description = reader["Description"].ToString();
                    ownerID = int.Parse(reader["Owner"].ToString());
                    status = (ProjectStatus)Enum.Parse(typeof(ProjectStatus), reader["Status"].ToString());
                    thumbnail = reader["Thumbnail"].ToString();
                }

                UsersAccounts.UserData owner = GetUser(ownerID);

                return new UserProject(id, projectname, description, owner, type, status, tags, thumbnail);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return null;
        }

        /// <summary>
        /// Returns a specific project
        /// </summary>
        /// <param name="projectID">The ID of the project</param>
        /// <returns>The specific project</returns>
        public UserProject getProject(int projectID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Project.* FROM[Project] WHERE ID = " + projectID;

                OleDbDataReader reader = command.ExecuteReader();

                string projectname = "";
                string description = "";
                int ownerID = 0;
                string tags = "";
                string thumbnail = "";
                ProjectType type = ProjectType.Game;
                ProjectStatus status = ProjectStatus.Completed;
                ProjectTag tag = ProjectTag.Game;

                while (reader.Read())
                {
                    projectname = reader["Projectname"].ToString();

                    type = (ProjectType)Enum.Parse(typeof(ProjectType), reader["Type"].ToString());
                    tags = reader["Tags"].ToString();
                    description = reader["Description"].ToString();
                    ownerID = int.Parse(reader["Owner"].ToString());
                    status = (ProjectStatus)Enum.Parse(typeof(ProjectStatus), reader["Status"].ToString());
                    thumbnail = reader["Thumbnail"].ToString();
                }

                UsersAccounts.UserData owner = GetUser(ownerID);

                if (ownerID == 0)
                {
                    return null;
                }

                return new UserProject(projectID, projectname, description, owner, type, status, tags, thumbnail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return null;
        }

        /// <summary>
        /// Returns a specific asset
        /// </summary>
        /// <param name="assetname">The name of the asset</param>
        /// <returns>The specified asset</returns>
        public UserAsset getAsset(string assetname)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Asset.* FROM[Asset] ";

                OleDbDataReader reader = command.ExecuteReader();

                int assetID = 0;
                string notes = "";
                int creatorID = 1;
                AssetType type = AssetType._2DArt;
                AssetStatus status = AssetStatus.Completed;
                String software = "";
                PegiRating pegiRating = PegiRating._3;
                string tags = "";
                string path = "";
                string thumbnail = "";
                string galleryOne = "";
                string galleryTwo = "";
                string galleryThree = "";
                string galleryFour = "";
                string galleryFive = "";

                while (reader.Read())
                {
                    assetID = int.Parse(reader["ID"].ToString());
                    assetname = reader["Assetname"].ToString();
                    creatorID = int.Parse(reader["Creator"].ToString());
                    notes = reader["Notes"].ToString();
                    status = (AssetStatus)Enum.Parse(typeof(AssetStatus), reader["Status"].ToString());
                    type = (AssetType)Enum.Parse(typeof(AssetType), reader["Type"].ToString());
                    software = reader["Software"].ToString();
                    pegiRating = (PegiRating)Enum.Parse(typeof(PegiRating), reader["PegiRating"].ToString());
                    tags = reader["Tags"].ToString();
                    path = reader["AssetPath"].ToString();
                    thumbnail = reader["ThumbnailPath"].ToString();
                    galleryOne = reader["GalleryOne"].ToString();
                    galleryTwo = reader["GalleryTwo"].ToString();
                    galleryThree = reader["GalleryThree"].ToString();
                    galleryFour = reader["GalleryFour"].ToString();
                    galleryFive = reader["GalleryFive"].ToString();

                    Console.WriteLine();
                }

                UsersAccounts.UserData creator = GetUser(creatorID);

                return new UserAsset(assetID, assetname, notes, creator, type, status, software, path, pegiRating, tags,
                    thumbnail, galleryOne, galleryTwo, galleryThree, galleryFour, galleryFive);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return null;
        }

        /// <summary>
        /// Returns a specific asset
        /// </summary>
        /// <param name="assetID">The ID of the asset</param>
        /// <returns>The specified asset</returns>
        public UserAsset getAsset(int assetID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Asset.* FROM[Asset]  WHERE ID = " + assetID;

                OleDbDataReader reader = command.ExecuteReader();

                string assetname = "";
                string notes = "";
                int creatorID = 1;
                AssetType type = AssetType._2DArt;
                AssetStatus status = AssetStatus.Completed;
                String software = "";
                PegiRating pegiRating = PegiRating._3;
                string tags = "";
                string path = "";
                string thumbnail = "";
                string galleryOne = "";
                string galleryTwo = "";
                string galleryThree = "";
                string galleryFour = "";
                string galleryFive = "";

                while (reader.Read())
                {
                    assetname = reader["Assetname"].ToString();
                    creatorID = int.Parse(reader["Creator"].ToString());
                    notes = reader["Notes"].ToString();
                    status = (AssetStatus)Enum.Parse(typeof(AssetStatus), reader["Status"].ToString());
                    type = (AssetType)Enum.Parse(typeof(AssetType), reader["Type"].ToString());
                    software = reader["Software"].ToString();
                    pegiRating = (PegiRating)Enum.Parse(typeof(PegiRating), reader["PegiRating"].ToString());
                    tags = reader["Tags"].ToString();
                    path = reader["AssetPath"].ToString();
                    thumbnail = reader["ThumbnailPath"].ToString();
                    galleryOne = reader["GalleryOne"].ToString();
                    galleryTwo = reader["GalleryTwo"].ToString();
                    galleryThree = reader["GalleryThree"].ToString();
                    galleryFour = reader["GalleryFour"].ToString();
                    galleryFive = reader["GalleryFive"].ToString();

                    Console.WriteLine();
                }

                UsersAccounts.UserData creator = GetUser(creatorID);

                return new UserAsset(assetID, assetname, notes, creator, type, status, software, path, pegiRating, tags,
                    thumbnail, galleryOne, galleryTwo, galleryThree, galleryFour, galleryFive);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return null;
        }

        /// <summary>
        /// Get all messages sended by the user
        /// </summary>
        /// <param name="userID">The ID of the user</param>
        /// <returns>The list of the messages</returns>
        public List<UserMessage> GetSendedMessages(int userID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Messages.* FROM[Messages] WHERE Sender = " + userID;

                OleDbDataReader reader = command.ExecuteReader();

                List<UserMessage> messages = new List<UserMessage>();

                int receiverID = 0;
                string message = "";
                int messageID = 1;
                int senderID = 0;
                DateTime sended = DateTime.MinValue;
                MessageType type = MessageType.Invite;

                while (reader.Read())
                {
                    messageID = int.Parse(reader["ID"].ToString());
                    receiverID = int.Parse(reader["Receiver"].ToString());
                    senderID = int.Parse(reader["Sender"].ToString());
                    message = reader["Message"].ToString();
                    type = (MessageType)Enum.Parse(typeof(MessageType), reader["Type"].ToString());
                    sended = Convert.ToDateTime(reader["SendedDate"]);

                    messages.Add(new UserMessage(senderID, receiverID, message, sended, type));
                }

                return messages;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return null;
        }

        /// <summary>
        /// Get all messages for the user
        /// </summary>
        /// <param name="userID">The ID of the user</param>
        /// <returns>The list of the messages</returns>
        public List<UserMessage> GetReceivedMessages(int userID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Messages.* FROM[Messages] WHERE Receiver = " + userID;

                OleDbDataReader reader = command.ExecuteReader();

                List<UserMessage> messages = new List<UserMessage>();

                int receiverID = 0;
                int senderID = 0;
                string message = "";
                int messageID = 1;
                DateTime sended = DateTime.MinValue;
                MessageType type = MessageType.Invite;

                while (reader.Read())
                {
                    messageID = int.Parse(reader["ID"].ToString());
                    receiverID = int.Parse(reader["Receiver"].ToString());
                    senderID = int.Parse(reader["Sender"].ToString());
                    message = reader["Message"].ToString();
                    type = (MessageType)Enum.Parse(typeof(MessageType), reader["Type"].ToString());
                    sended = Convert.ToDateTime(reader["SendedDate"]);

                    messages.Add(new UserMessage(senderID, receiverID, message, sended, type));
                }

                return messages;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return null;
        }

        /// <summary>
        /// Returns the Assets created by the user
        /// </summary>
        /// <param name="userID">The ID of the User</param>
        /// <returns>A list of assets created by the user</returns>
        public List<UserAsset> getAssetsOfUser(int userID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Asset.* FROM[Asset] WHERE Creator = " + userID;

                OleDbDataReader reader = command.ExecuteReader();

                List<UserAsset> result = new List<UserAsset>();

                while (reader.Read())
                {
                    int assetID = 0;
                    string assetname = "";
                    string notes = "";
                    int creatorID = 1;
                    AssetType type = AssetType._2DArt;
                    AssetStatus status = AssetStatus.Completed;
                    String software = "";
                    PegiRating pegiRating = PegiRating._3;
                    string tags = "";
                    string path = "";
                    string thumbnail = "";
                    string galleryOne = "";
                    string galleryTwo = "";
                    string galleryThree = "";
                    string galleryFour = "";
                    string galleryFive = "";

                    assetID = int.Parse(reader["ID"].ToString());
                    assetname = reader["Assetname"].ToString();
                    creatorID = int.Parse(reader["Creator"].ToString());
                    notes = reader["Notes"].ToString();
                    status = (AssetStatus)Enum.Parse(typeof(AssetStatus), reader["Status"].ToString());
                    type = (AssetType)Enum.Parse(typeof(AssetType), reader["Type"].ToString());
                    software = reader["Software"].ToString();
                    pegiRating = (PegiRating)Enum.Parse(typeof(PegiRating), reader["PegiRating"].ToString());
                    tags = reader["Tags"].ToString();
                    path = reader["AssetPath"].ToString();
                    thumbnail = reader["ThumbnailPath"].ToString();
                    galleryOne = reader["GalleryOne"].ToString();
                    galleryTwo = reader["GalleryTwo"].ToString();
                    galleryThree = reader["GalleryThree"].ToString();
                    galleryFour = reader["GalleryFour"].ToString();
                    galleryFive = reader["GalleryFive"].ToString();

                    UsersAccounts.UserData creator = GetUser(creatorID);

                    result.Add(new UserAsset(assetID, assetname, notes, creator, type, status, software, path, pegiRating, tags,
                        thumbnail, galleryOne, galleryTwo, galleryThree, galleryFour, galleryFive));
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

        /// <summary>
        /// Returns the projects where the user is part of.
        /// </summary>
        /// <param name="userID">The ID of the user</param>
        /// <returns>Returns a list of projects where the user is part of.</returns>
        public List<UserProject> getProjectsOfUser(int userID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT Project.* FROM[Project] project" +
                    " Inner join [UsersInProjects] uip" +
                    " On uip.ProjectID = project.ID " +
                    " WHERE uip.UserID = " + userID;

                OleDbDataReader reader = command.ExecuteReader();

                List<UserProject> result = new List<UserProject>();

                while (reader.Read())
                {
                    int projectID = 0;
                    string projectname = "";
                    string description = "";
                    int ownerID = 1;
                    string tags = "";
                    string thumbnail = "";
                    ProjectType type = ProjectType.Game;
                    ProjectStatus status = ProjectStatus.Completed;

                    projectID = int.Parse(reader["ID"].ToString());
                    projectname = reader["Projectname"].ToString();
                    type = (ProjectType)Enum.Parse(typeof(ProjectType), reader["Type"].ToString());
                    tags = reader["Tags"].ToString();
                    description = reader["Description"].ToString();
                    ownerID = int.Parse(reader["Owner"].ToString());
                    status = (ProjectStatus)Enum.Parse(typeof(ProjectStatus), reader["Status"].ToString());
                    thumbnail = reader["Thumbnail"].ToString();

                    UsersAccounts.UserData owner = GetUser(ownerID);

                    result.Add(new UserProject(projectID, projectname, description, owner, type, status, tags, thumbnail));
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

        /// <summary>
        /// Returns all assets in a project
        /// </summary>
        /// <param name="projectID">The ID of the project</param>
        /// <returns>A list of assets in the project</returns>
        public List<UserAsset> getAssetsInProject(int projectID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT Asset.* FROM[Asset] asset " +
                    "Inner join [AssetsInProjects] aip " +
                    "On aip.AssetID = asset.ID " +
                    "WHERE aip.ProjectID = " + projectID;

                OleDbDataReader reader = command.ExecuteReader();

                List<UserAsset> result = new List<UserAsset>();

                while (reader.Read())
                {
                    int assetID = 0;
                    string assetname = "";
                    string notes = "";
                    int creatorID = 1;
                    AssetType type = AssetType._2DArt;
                    AssetStatus status = AssetStatus.Completed;
                    String software = "";
                    PegiRating pegiRating = PegiRating._3;
                    string tags = "";
                    string path = "";
                    string thumbnail = "";
                    string galleryOne = "";
                    string galleryTwo = "";
                    string galleryThree = "";
                    string galleryFour = "";
                    string galleryFive = "";

                    assetID = int.Parse(reader["ID"].ToString());
                    assetname = reader["Assetname"].ToString();
                    creatorID = int.Parse(reader["Creator"].ToString());
                    notes = reader["Notes"].ToString();
                    status = (AssetStatus)Enum.Parse(typeof(AssetStatus), reader["Status"].ToString());
                    type = (AssetType)Enum.Parse(typeof(AssetType), reader["Type"].ToString());
                    software = reader["Software"].ToString();
                    pegiRating = (PegiRating)Enum.Parse(typeof(PegiRating), reader["PegiRating"].ToString());
                    tags = reader["Tags"].ToString();
                    path = reader["AssetPath"].ToString();
                    thumbnail = reader["ThumbnailPath"].ToString();
                    galleryOne = reader["GalleryOne"].ToString();
                    galleryTwo = reader["GalleryTwo"].ToString();
                    galleryThree = reader["GalleryThree"].ToString();
                    galleryFour = reader["GalleryFour"].ToString();
                    galleryFive = reader["GalleryFive"].ToString();

                    UsersAccounts.UserData creator = GetUser(creatorID);

                    result.Add(new UserAsset(assetID, assetname, notes, creator, type, status, software, path, pegiRating, tags,
                        thumbnail, galleryOne, galleryTwo, galleryThree, galleryFour, galleryFive));
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

        /// <summary>
        /// Returns all users inside the project
        /// </summary>
        /// <param name="projectID">The ID of the Project</param>
        /// <returns>A list of users in the project</returns>
        public List<UsersAccounts.UserData> getUsersInProject(int projectID)
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

                List<UsersAccounts.UserData> result = new List<UsersAccounts.UserData>();

                while (reader.Read())
                {
                    string password = "";
                    string email = "";
                    int id = 1;
                    UserStatus status = UserStatus.Offline;
                    UserType type = UserType.Developer;
                    string username = "";
                    string profile = "";
                    string fullName = "";

                    id = int.Parse(reader["ID"].ToString());
                    status = (UserStatus)Enum.Parse(typeof(UserStatus), reader["Status"].ToString());
                    password = reader["Password"].ToString();
                    email = reader["Email"].ToString();
                    username = reader["Username"].ToString();
                    type = (UserType)Enum.Parse(typeof(UserType), reader["Type"].ToString());
                    profile = reader["ProfilePicture"].ToString();
                    fullName = reader["FullName"].ToString();

                    result.Add(new UsersAccounts.UserData(id, username, password, email, type, status, profile, fullName));
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

        /// <summary>
        /// Returns the projects owned by an user
        /// </summary>
        /// <param name="userID">The ID of the user</param>
        /// <returns>A list of projects owned by the user</returns>
        public List<UserProject> getOwnedProjectsOfUser(int userID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Project.* FROM[Project] WHERE Owner = " + userID;

                OleDbDataReader reader = command.ExecuteReader();

                List<UserProject> result = new List<UserProject>();

                while (reader.Read())
                {

                    int projectID = 0;
                    string projectname = "";
                    string description = "";
                    int ownerID = 1;
                    string tags = "";
                    string thumbnail = "";
                    ProjectType type = ProjectType.Game;
                    ProjectStatus status = ProjectStatus.Completed;
                    ProjectTag tag = ProjectTag.Game;

                    projectID = int.Parse(reader["ID"].ToString());
                    projectname = reader["Projectname"].ToString();
                    type = (ProjectType)Enum.Parse(typeof(ProjectType), reader["Type"].ToString());
                    tags = reader["Tags"].ToString();
                    description = reader["Description"].ToString();
                    ownerID = int.Parse(reader["Owner"].ToString());
                    status = (ProjectStatus)Enum.Parse(typeof(ProjectStatus), reader["Status"].ToString());
                    thumbnail = reader["Thumbnail"].ToString();

                    UsersAccounts.UserData owner = GetUser(ownerID);

                    result.Add(new UserProject(projectID, projectname, description, owner, type, status, tags, thumbnail));
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

        /// <summary>
        /// Returns the rating of an asset
        /// </summary>
        /// <param name="ratingID">The ID of the rating</param>
        /// <returns>The specified rating</returns>
        public UserRating GetRating(int ratingID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM[Ratings] " +
                   "WHERE ID = " + ratingID;

                OleDbDataReader reader = command.ExecuteReader();

                int id = 0;
                int reviewerID = 0;
                int assetID = 0;
                int stars = 0;
                string comment = "";

                while (reader.Read())
                {
                    id = int.Parse(reader["ID"].ToString());
                    reviewerID = int.Parse(reader["Reviewer"].ToString());
                    assetID = int.Parse(reader["Asset"].ToString());
                    stars = int.Parse(reader["Stars"].ToString());
                    comment = reader["Comment"].ToString();

                    Console.WriteLine();
                }

                return new UserRating(id, reviewerID, assetID, stars, comment);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return null;
        }

        /// <summary>
        /// Get all ratings of an asset
        /// </summary>
        /// <param name="assetID">The ID of the asset</param>
        /// <returns>All ratings of the asset</returns>
        public List<UserRating> GetRatingsOfAsset(int assetID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM[Ratings] " +
                   "WHERE Asset = " + assetID;

                OleDbDataReader reader = command.ExecuteReader();

                List<UserRating> result = new List<UserRating>();

                int id = 0;
                int reviewerID = 0;
                int stars = 0;
                string comment = "";

                while (reader.Read())
                {
                    id = int.Parse(reader["ID"].ToString());
                    reviewerID = int.Parse(reader["Reviewer"].ToString());
                    assetID = int.Parse(reader["Asset"].ToString());
                    stars = int.Parse(reader["Stars"].ToString());
                    comment = reader["Comment"].ToString();

                    Console.WriteLine();

                    result.Add(new UserRating(id, reviewerID, assetID, stars, comment));
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

        /// <summary>
        /// Returns all ratings by the user
        /// </summary>
        /// <param name="reviewerID">The ID of the reviewer</param>
        /// <returns>All ratings by the user</returns>
        public List<UserRating> GetRatingsOfUser(int reviewerID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM[Ratings] " +
                   "WHERE Reviewer = " + reviewerID;

                OleDbDataReader reader = command.ExecuteReader();

                List<UserRating> result = new List<UserRating>();

                int id = 0;
                int assetID = 0;
                int stars = 0;
                string comment = "";

                while (reader.Read())
                {
                    id = int.Parse(reader["ID"].ToString());
                    reviewerID = int.Parse(reader["Reviewer"].ToString());
                    assetID = int.Parse(reader["Asset"].ToString());
                    stars = int.Parse(reader["Stars"].ToString());
                    comment = reader["Comment"].ToString();

                    Console.WriteLine();

                    result.Add(new UserRating(id, reviewerID, assetID, stars, comment));
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

        /// <summary>
        /// Get the average star rating of an asset
        /// </summary>
        /// <param name="assetID">The ID of the Asset</param>
        /// <returns>The average star rating</returns>
        public float GetAverageStarRating(int assetID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Avg(Stars) AS AverageStars FROM Ratings " +
                    "WHERE Asset = " + assetID;

                OleDbDataReader reader = command.ExecuteReader();

                float stars = 0;

                while (reader.Read())
                {
                    stars = float.Parse(reader["AverageStars"].ToString());
                }

                return stars;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return 0;
        }

        /// <summary>
        /// Return the amount of ratings for the asset
        /// </summary>
        /// <param name="assetID">The ID of the asset</param>
        /// <returns></returns>
        public int GetAmountOfRatingsForAsset(int assetID)
        {
            return GetRatingsOfAsset(assetID).Count;
        }

        /// <summary>
        /// Returns if the user has already rated the asset
        /// </summary>
        /// <param name="userID">The user ID</param>
        /// <param name="assetID">The ID of the asset</param>
        /// <returns>If the user has rated already</returns>
        public bool UserRatedAsset(int userID, int assetID)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Ratings " +
                    "WHERE Asset = " + assetID + " AND Reviewer = "+ userID;

                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    return true;
                else
                    return false;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            return false;
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

        public void ChangeUserProfile(int id, string newValue)
        {
            string commandText = "UPDATE [User] SET [ProfilePicture] = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        public void ChangeUserFullName(int id, string newValue)
        {
            string commandText = "UPDATE [User] SET [FullName] = '" + newValue + "' WHERE ID = " + id + "";

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
        /// Changes the Tags of the project
        /// </summary>
        /// <param name="projectname">The name of the project</param>
        /// <param name="newValue">New tags of the project</param>
        public void ChangeProjectTags(string projectname, string newValue)
        {
            string commandText = "UPDATE [Project] SET Tags = '" + newValue + "' WHERE Projectname = '" + projectname + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the Tags of the project
        /// </summary>
        /// <param name="id">The ID of the project</param>
        /// <param name="newValue">New tags for the project</param>
        public void ChangeProjectTags(int id, string newValue)
        {
            string commandText = "UPDATE [Project] SET Tags = '" + newValue + "' WHERE ID = " + id + "";

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

        public void ChangeProjectThumbnail(int id, string newValue)
        {
            string commandText = "UPDATE [Project] SET Thumbnail = '" + newValue + "' WHERE ID = " + id + "";

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
        /// Changes the type of the asset
        /// </summary>
        /// <param name="assetname">The name of the asset</param>
        /// <param name="newValue">New type of the asset</param>
        public void ChangeAssetType(string assetname, AssetType newValue)
        {
            string commandText = "UPDATE [Asset] SET Type = '" + newValue + "' WHERE Assetname = '" + assetname + "'";

            ExecuteCommand(commandText);
        }

        /// <summary>
        /// Changes the type of the asset
        /// </summary>
        /// <param name="id">The ID of the asset</param>
        /// <param name="newValue">New type of the asset</param>
        public void ChangeAssetType(int id, AssetType newValue)
        {
            string commandText = "UPDATE [Asset] SET Type = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        public void ChangeAssetPegi(int id, PegiRating newValue)
        {
            string commandText = "UPDATE [Asset] SET PegiRating = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        public void ChangeAssetTags(int id, string newValue)
        {
            string commandText = "UPDATE [Asset] SET Tags = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        public void ChangeAssetPath(int id, string newValue)
        {
            string commandText = "UPDATE [Asset] SET AssetPath = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        public void ChangeAssetThumbnail(int id, string newValue)
        {
            string commandText = "UPDATE [Asset] SET ThumbnailPath = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        public void ChangeAssetGalleryOne(int id, string newValue)
        {
            string commandText = "UPDATE [Asset] SET GalleryOne = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        public void ChangeAssetGalleryTwo(int id, string newValue)
        {
            string commandText = "UPDATE [Asset] SET GalleryTwo = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        public void ChangeAssetGalleryThree(int id, string newValue)
        {
            string commandText = "UPDATE [Asset] SET GalleryThree = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        public void ChangeAssetGalleryFour(int id, string newValue)
        {
            string commandText = "UPDATE [Asset] SET GalleryFour = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        public void ChangeAssetGalleryFive(int id, string newValue)
        {
            string commandText = "UPDATE [Asset] SET GalleryFive = '" + newValue + "' WHERE ID = " + id + "";

            ExecuteCommand(commandText);
        }

        #region Change rating values

        public void ChangeRatingStars(int ratingID, int stars)
        {
            string commandText = "UPDATE [Ratings] SET Stars = " + stars + " WHERE ID = " + ratingID;

            ExecuteCommand(commandText);
        }

        public void ChangeRatingComment(int ratingID, string comment)
        {
            string commandText = "UPDATE [Ratings] SET Comment = '" + comment + "' WHERE ID = " + ratingID;

            ExecuteCommand(commandText);
        }

        #endregion

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
                    Console.Write(reader["ID"].ToString() + ", ");
                    Console.Write(reader["Status"].ToString() + ", ");
                    Console.Write(reader["Password"].ToString() + ", ");
                    Console.Write(reader["Email"].ToString() + ", ");
                    Console.Write(reader["Username"].ToString() + ", ");
                    Console.Write(reader["Type"].ToString() + ", ");
                    Console.Write(reader["ProfilePicture"].ToString());
                    Console.WriteLine(reader["FullName"].ToString());
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
                    Console.Write(reader["ID"].ToString() + ", ");
                    Console.Write(reader["Projectname"].ToString() + ", ");
                    Console.Write(reader["Type"].ToString() + ", ");
                    Console.Write(reader["Description"].ToString() + ", ");
                    Console.Write(reader["Owner"].ToString() + ", ");
                    Console.Write(reader["Tags"].ToString() + ", ");
                    Console.Write(reader["Status"].ToString() + ", ");
                    Console.Write(reader["Thumbnail"].ToString());
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
                    Console.Write(reader["ID"].ToString() + ", ");
                    Console.Write(reader["Assetname"].ToString() + ", ");
                    Console.Write(reader["Creator"].ToString() + ", ");
                    Console.Write(reader["Notes"].ToString() + ", ");
                    Console.Write(reader["Status"].ToString() + ", ");
                    Console.Write(reader["Type"].ToString() + ", ");
                    Console.Write(reader["Software"].ToString() + ", ");
                    Console.Write(reader["PegiRating"].ToString() + ", ");
                    Console.Write(reader["Tags"].ToString() + ", ");
                    Console.Write(reader["AssetPath"].ToString() + ", ");
                    Console.Write(reader["ThumbnailPath"].ToString() + ", ");
                    Console.Write(reader["GalleryOne"].ToString() + ", ");
                    Console.Write(reader["GalleryTwo"].ToString() + ", ");
                    Console.Write(reader["GalleryThree"].ToString() + ", ");
                    Console.Write(reader["GalleryFour"].ToString() + ", ");
                    Console.Write(reader["GalleryFive"].ToString());
                    Console.WriteLine();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        public void ShowAllMessages()
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT Messages.* FROM[Messages] ";

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.Write(reader["ID"].ToString() + ", ");
                    Console.Write(reader["Receiver"].ToString() + ", ");
                    Console.Write(reader["Sender"].ToString() + ", ");
                    Console.Write(reader["Message"].ToString() + ", ");
                    Console.Write(reader["SendedDate"].ToString() + ", ");
                    Console.Write(reader["Type"].ToString() + ", ");

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


//        /// <summary>
//        /// Executes the given command
//        /// </summary>
//        /// <param name="commandText">The command to execute</param>
//        /// <returns>Returns if the command was executed correctly</returns>
//        private bool ExecuteCommand(string commandText)
//        {
//            try
//            {
//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;
//                command.CommandText = commandText;

//                command.ExecuteNonQuery();

//                return true;
//            }

//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//                return false;
//            }
//        }

//        #region search commands

//        public List<UserProject> SearchProject(String name = null, ProjectType typeSearch = ProjectType.Null, ProjectTag tagSearch = ProjectTag.Null, ProjectStatus statusSearch = ProjectStatus.Null)
//        {
//            try
//            {
//                List<UserProject> result = new List<UserProject>();

//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;

//                string commandtext = "SELECT Project.* FROM[Project] ";

//                if(name != null || typeSearch != ProjectType.Null || tagSearch != ProjectTag.Null || statusSearch != ProjectStatus.Null)
//                {
//                    commandtext += "WHERE ";
//                    bool added = false;


//                    if (name != null)
//                    {
//                        commandtext += "UCase(Projectname) like UCase('%" + name + "%') ";
//                        added = true;
//                    }
//                    if (typeSearch != ProjectType.Null && !added)
//                    {
//                        commandtext += "Type = '" + typeSearch + "' ";
//                        added = true;
//                    }
//                    else if (typeSearch != ProjectType.Null)
//                        commandtext += "AND Type = '" + typeSearch + "' ";
//                    if (tagSearch != ProjectTag.Null && !added)
//                    {
//                        commandtext += "Tag = '" + tagSearch + "' ";
//                        added = true;
//                    }
//                    else if(tagSearch != ProjectTag.Null)
//                        commandtext += "AND Tag = '" + tagSearch + "' ";
//                    if (statusSearch != ProjectStatus.Null && !added)
//                        commandtext += "Status = '" + statusSearch + "' ";
//                    else if(statusSearch != ProjectStatus.Null)
//                        commandtext += "AND Status = '" + statusSearch + "' ";
//                }

//                command.CommandText = commandtext;

//                OleDbDataReader reader = command.ExecuteReader();

//                while (reader.Read())
//                {
//                    int id = reader.GetInt32(0);
//                    string projectname = reader.GetString(1);
//                    ProjectType type;
//                    ProjectTag tag;
//                    ProjectStatus status;

//                    Enum.TryParse<ProjectType>(reader.GetString(2), out type);
//                    string description = reader.GetString(3);
//                    int ownerID = reader.GetInt32(4);
//                    Enum.TryParse<ProjectTag>(reader.GetString(5), out tag);
//                    Enum.TryParse<ProjectStatus>(reader.GetString(6), out status);

//                    UsersAccounts.UserData owner = GetUser(ownerID);

//                    result.Add(new UserProject(id, projectname, description, owner, type, status));
//                }

//                return result;
//            }


//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            Console.WriteLine();

//            return null;
//        }

//        public List<UserAsset> SearchAsset(String name = null, AssetType typeSearch = AssetType._NULL, AssetStatus statusSearch = AssetStatus.Null, int pegi = 0)
//        {
//            try
//            {
//                List<UserAsset> result = new List<UserAsset>();

//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;

//                string commandtext = "SELECT Asset.* FROM[Asset] ";

//                if (name != null || typeSearch != AssetType._NULL || statusSearch != AssetStatus.Null || pegi != 0)
//                {
//                    commandtext += "WHERE ";
//                    bool added = false;


//                    if (name != null)
//                    {
//                        commandtext += "UCase(Assetname) like UCase('%" + name + "%') ";
//                        added = true;
//                    }
//                    if (typeSearch != AssetType._NULL && !added)
//                    {
//                        commandtext += "Type = '" + typeSearch + "' ";
//                        added = true;
//                    }
//                    else if (typeSearch != AssetType._NULL)
//                        commandtext += "AND Type = '" + typeSearch + "' ";
//                    if (statusSearch != AssetStatus.Null && !added)
//                    {
//                        commandtext += "Status = '" + statusSearch + "' ";
//                        added = true;
//                    }
//                    else if (statusSearch != AssetStatus.Null)
//                        commandtext += "AND Status = '" + statusSearch + "' ";
//                    if (pegi != 0 && !added)
//                        commandtext += "PegiRating = " + pegi + " ";
//                    else if (pegi != 0)
//                        commandtext += "AND PegiRating = " + pegi + " ";
//                }

//                command.CommandText = commandtext;

//                OleDbDataReader reader = command.ExecuteReader();

//                while (reader.Read())
//                {
//                    int id = 1;
//                    string assetname = "";
//                    string notes = "";
//                    AssetType type = AssetType._2DArt;
//                    AssetStatus status = AssetStatus.Completed;
//                    String software = "";
//                    int pegiRating = 3;

//                    id = reader.GetInt32(0);
//                    assetname = reader.GetString(1);
//                    notes = reader.GetString(3);
//                    Enum.TryParse<AssetStatus>(reader.GetString(4), out status);
//                    Enum.TryParse<AssetType>(reader.GetString(5), out type);
//                    software = reader.GetString(7);
//                    pegiRating = reader.GetInt32(8);
//                    Console.WriteLine();

//                    result.Add(new UserAsset(id, assetname, notes, null, type, status, software));
//                }

//                return result;
//            }


//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            Console.WriteLine();

//            return null;
//        }

//        #endregion

//        #region Add commands

//        /// <summary>
//        /// Adds an user to the database
//        /// </summary>
//        /// <param name="password">The password for the user</param>
//        /// <param name="email">The email of the user</param>
//        /// <param name="username">Tbe username</param>
//        /// <param name="type">Type of user (see UserType class)</param>
//        /// <param name="status">The current status of the user (see UserStatus class)</param>
//        public int AddUser(string password, string email, string username, UserType type, UserStatus status = UserStatus.Offline)
//        {
//            string commandText = "INSERT INTO [User] (Status, [Password], Email, Username, Type ) VALUES " +
//                                "('" + status + "','" + password + "','" + email + "','" + username + "','" + type + "')";

//            bool executed = ExecuteCommand(commandText);

//            int id = 0;

//            if (executed)
//            {
//                OleDbCommand command2 = new OleDbCommand();
//                command2.Connection = connection;
//                command2.CommandText = "SELECT User.ID FROM[User] WHERE Username = '" + username + "'";

//                OleDbDataReader reader = command2.ExecuteReader();

//                while (reader.Read())
//                    id = reader.GetInt32(0);

//            }
//            return id;
//        }

//        /// <summary>
//        /// Adds an project to the database
//        /// </summary>
//        /// <param name="name">The name of the project</param>
//        /// <param name="type">The type of the project</param>
//        /// <param name="description">Description for the project</param>
//        /// <param name="owner">The ID of the project owner</param>
//        /// <param name="tag">Tag for the project</param>
//        /// <param name="status">The current status of the project</param>
//        public int AddProject(string name, ProjectType type, string description, int owner, ProjectTag tag, ProjectStatus status)
//        {
//            string commandText = "INSERT INTO Project ( Projectname, Type, Description, Owner, Tag, Status ) VALUES " +
//                                    "('" + name + "','" + type + "','" + description + "','" + owner + "','" + tag + "','" + status + "')";

//            bool executed = ExecuteCommand(commandText);

//            int id = 0;

//            if (executed)
//            {
//                OleDbCommand command2 = new OleDbCommand();
//                command2.Connection = connection;
//                command2.CommandText = "SELECT Project.ID FROM[Project] WHERE Projectname = '" + name + "'";

//                OleDbDataReader reader = command2.ExecuteReader();

//                while (reader.Read())
//                    id = reader.GetInt32(0);

//            }
//            return id;
//        }

//        /// <summary>
//        /// Adds an asset to the database
//        /// </summary>
//        /// <param name="name">The name of the asset</param>
//        /// <param name="creator">The ID of the creator</param> 
//        /// <param name="status">The current status of the asset</param>
//        /// <param name="tag">Tag for the asset</param>
//        /// <param name="software">The software used to create the asset</param>
//        /// <param name="notes">The notes of the asset</param>
//        public int AddAsset(string name, int creator, AssetStatus status, AssetType type, string software, string notes = "1.0")
//        {
//            string commandText = "INSERT INTO Asset ( Assetname, Creator, Notes, Status, Type, Software ) VALUES " +
//                                    "('" + name + "'," + creator + ",'" + notes + "','" + status + "','" + type + "', '"+ software +"')";

//            bool executed = ExecuteCommand(commandText);

//            int id = 0;

//            if (executed)
//            {
//                OleDbCommand command2 = new OleDbCommand();
//                command2.Connection = connection;
//                command2.CommandText = "SELECT Asset.ID FROM[Asset] WHERE Assetname = '" + name + "'";

//                OleDbDataReader reader = command2.ExecuteReader();

//                while (reader.Read())
//                    id = reader.GetInt32(0);

//            }

//            return id;
//        }

//        /// <summary>
//        /// Adds a message to the database
//        /// </summary>
//        /// <param name="senderID">The ID of the sender</param>
//        /// <param name="receiverID">The ID of the receiving user</param>
//        /// <param name="message">The message text</param>
//        /// <param name="sended">The date when the message was sended</param>
//        /// <param name="type">The type of message</param>
//        public void AddMessage(int senderID, int receiverID, string message, DateTime sended, MessageType type)
//        {
//            // Removes miliseconds as it causes data type mismatch
//            DateTime time = new DateTime(sended.Year, sended.Month, sended.Day, sended.Hour, sended.Minute, sended.Second);

//            string commandText = "INSERT INTO Messages ( Sender, Receiver, Message, Type, SendedDate) VALUES " +
//                                    "('" + senderID + "','" + receiverID + "','" + message + "','" + type + "','" + time + "')";

//            ExecuteCommand(commandText);
//        }

//        #endregion

//        #region get commands

//        /// <summary>
//        /// Get a specific user
//        /// </summary>
//        /// <param name="username">The name of the user</param>
//        /// <returns></returns>
//        public UsersAccounts.UserData GetUser(string username)
//        {

//            OleDbCommand command = new OleDbCommand();
//            command.Connection = connection;
//            command.CommandText = "SELECT User.* FROM[User] WHERE Username = '" + username+"'";

//            OleDbDataReader reader = command.ExecuteReader();

//             string password = "";
//             string email = "";
//             int id = 0;
//             UserStatus status = UserStatus.Offline;
//             UserType type = UserType.Developer;

//             while (reader.Read())
//             {
//                 id = reader.GetInt32(0);
//                 Enum.TryParse<UserStatus>(reader.GetString(1), out status);
//                 password = reader.GetString(2);
//                 email = reader.GetString(3);
//                 Enum.TryParse<UserType>(reader.GetString(5), out type);
//             }

//            if (id == 0)
//            {
//                return null;
//            }
//             return new UsersAccounts.UserData(id, username, email, password, status);
//        }

//        /// <summary>
//        /// Get a specific user
//        /// </summary>
//        /// <param name="id">The ID of the user</param>
//        /// <returns></returns>
//        public UsersAccounts.UserData GetUser(int id)
//        {
//            try
//            {
//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;
//                command.CommandText = "SELECT User.* FROM[User] WHERE ID = " + id;

//                OleDbDataReader reader = command.ExecuteReader();

//                string password = "";
//                string email = "";
//                string username = "";
//                UserStatus status = UserStatus.Offline;
//                UserType type = UserType.Developer;

//                while (reader.Read())
//                {
//                    Enum.TryParse<UserStatus>(reader.GetString(1), out status);
//                    password = reader.GetString(2);
//                    email = reader.GetString(3);
//                    username = reader.GetString(4);
//                    Enum.TryParse<UserType>(reader.GetString(5), out type);
//                }

//                return new UsersAccounts.UserData(id, username, email, password, status);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//                return null;
//            }
//        }

//        public UserProject getProject(string projectname)
//        {
//            try
//            {
//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;
//                command.CommandText = "SELECT Project.* FROM[Project]  WHERE Projectname = " + projectname;

//                OleDbDataReader reader = command.ExecuteReader();

//                int id = 1;
//                string description = "";
//                int ownerID = 1;
//                ProjectType type = ProjectType.Game;
//                ProjectStatus status = ProjectStatus.Completed;
//                ProjectTag tag = ProjectTag.Game;

//                while (reader.Read())
//                {
//                    id = reader.GetInt32(0);
//                    Enum.TryParse<ProjectType>(reader.GetString(2), out type);
//                    description = reader.GetString(3);
//                    ownerID = reader.GetInt32(4);
//                    Enum.TryParse<ProjectTag>(reader.GetString(5), out tag);
//                    Enum.TryParse<ProjectStatus>(reader.GetString(6), out status);
//                }

//                UsersAccounts.UserData owner = GetUser(ownerID);

//                return new UserProject(id, projectname, description, owner, type, status);
//            }

//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            Console.WriteLine();

//            return null;
//        }

//        public UserProject getProject(int projectID)
//        {
//            try
//            {
//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;
//                command.CommandText = "SELECT Project.* FROM[Project] WHERE ID = " + projectID;

//                OleDbDataReader reader = command.ExecuteReader();

//                string projectName = "";
//                string description = "";
//                int ownerID = 1;
//                ProjectType type = ProjectType.Game;
//                ProjectStatus status = ProjectStatus.Completed;
//                ProjectTag tag = ProjectTag.Game;

//                while (reader.Read())
//                {
//                    projectName = reader.GetString(1);
//                    Enum.TryParse<ProjectType>(reader.GetString(2), out type);
//                    description = reader.GetString(3);
//                    ownerID = reader.GetInt32(4);
//                    Enum.TryParse<ProjectTag>(reader.GetString(5), out tag);
//                    Enum.TryParse<ProjectStatus>(reader.GetString(6), out status);
//                }

//                UsersAccounts.UserData owner = GetUser(ownerID);

//                return new UserProject(projectID, projectName, description, owner, type, status);
//            }

//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            Console.WriteLine();

//            return null;
//        }

//        public UserAsset getAsset(string assetname)
//        {
//            try
//            {
//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;
//                command.CommandText = "SELECT Asset.* FROM[Asset] WHERE Assetname = " + assetname;

//                OleDbDataReader reader = command.ExecuteReader();

//                int id = 1;
//                string notes = "";
//                int creatorID = 1;
//                AssetType type = AssetType._2DArt;
//                AssetStatus status = AssetStatus.Completed;
//                String software = "";
//                int pegiRating = 3;

//                while (reader.Read())
//                {
//                    id = reader.GetInt32(0);
//                    creatorID = reader.GetInt32(2);
//                    notes = (reader.GetString(7));
//                    Enum.TryParse<AssetStatus>(reader.GetString(3), out status);
//                    Enum.TryParse<AssetType>(reader.GetString(4), out type);
//                    software = reader.GetString(5);
//                    pegiRating = reader.GetInt32(8);
//                    Console.WriteLine();                    
//                }

//                UsersAccounts.UserData creator = GetUser(creatorID);

//                return new UserAsset(id, assetname, notes, creator, type, status, software);
//            }

//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            Console.WriteLine();

//            return null;
//        }

//        public UserAsset getAsset(int assetID)
//        {
//            try
//            {
//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;
//                command.CommandText = "SELECT Asset.* FROM[Asset] WHERE ID = " + assetID;

//                OleDbDataReader reader = command.ExecuteReader();

//                string assetname = "";
//                string notes = "";
//                int creatorID = 1;
//                AssetType type = AssetType._2DArt;
//                AssetStatus status = AssetStatus.Completed;
//                String software = "";
//                int pegiRating = 3;

//                while (reader.Read())
//                {
//                    assetname = reader.GetString(1);
//                    creatorID = reader.GetInt32(2);
//                    notes = (reader.GetString(3));
//                    Enum.TryParse<AssetStatus>(reader.GetString(4), out status);
//                    Enum.TryParse<AssetType>(reader.GetString(5), out type);
//                    software = reader.GetString(7);
//                    pegiRating = reader.GetInt32(8);
//                    Console.WriteLine();
//                }

//                UsersAccounts.UserData creator = GetUser(creatorID);

//                return new UserAsset(assetID, assetname, notes, creator, type, status, software);
//            }

//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            Console.WriteLine();

//            return null;
//        }

//        public List<UserAsset> getAssetsOfUser(int userID)
//        {
//            try
//            {
//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;
//                command.CommandText = "SELECT Asset.* FROM[Asset] WHERE Creator = "+userID;

//                OleDbDataReader reader = command.ExecuteReader();

//                List<UserAsset> result = new List<UserAsset>();

//                while (reader.Read())
//                {
//                    int id = 1;
//                    string assetname = "";
//                    string notes = "";
//                    AssetType type = AssetType._2DArt;
//                    AssetStatus status = AssetStatus.Completed;
//                    String software = "";
//                    int pegiRating = 3;

//                    id = reader.GetInt32(0);
//                    assetname = reader.GetString(1);
//                    notes = reader.GetString(3);
//                    Enum.TryParse<AssetStatus>(reader.GetString(4), out status);
//                    Enum.TryParse<AssetType>(reader.GetString(5), out type);
//                    software = reader.GetString(7);
//                    pegiRating = reader.GetInt32(8);
//                    Console.WriteLine();

//                    result.Add(new UserAsset(id, assetname, notes, null, type, status, software));
//                }

//                return result;
//            }

//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            Console.WriteLine();

//            return null;
//        }

//        public List<UserProject> getProjectsOfUser(int userID)
//        {
//            try
//            {
//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;

//                command.CommandText = "SELECT Project.* FROM[Project] project" +
//                    " Inner join [UsersInProjects] uip" +
//                    " On uip.ProjectID = project.ID " +
//                    " WHERE uip.UserID = "+userID;

//                OleDbDataReader reader = command.ExecuteReader();

//                List<UserProject> result = new List<UserProject>();

//                while (reader.Read())
//                {
//                    int id = 1;
//                    string projectName = "";
//                    string description = "";
//                    ProjectType type = ProjectType.Game;
//                    ProjectStatus status = ProjectStatus.Completed;
//                    ProjectTag tag = ProjectTag.Game;

//                    id = reader.GetInt32(0);
//                    projectName = reader.GetString(1);
//                    Enum.TryParse<ProjectType>(reader.GetString(2), out type);
//                    description = reader.GetString(3);
//                    Enum.TryParse<ProjectTag>(reader.GetString(5), out tag);
//                    Enum.TryParse<ProjectStatus>(reader.GetString(6), out status);

//                    result.Add(new UserProject(id, projectName, description, null, type, status));
//                }

//                return result;
//            }

//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            Console.WriteLine();

//            return null;
//        }

//        public List<UserAsset> getAssetsInProject(int projectID)
//        {
//            try
//            {
//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;

//                command.CommandText = "SELECT Asset.* FROM[Asset] asset " +
//                    "Inner join [AssetsInProjects] aip " +
//                    "On aip.AssetID = asset.ID " +
//                    "WHERE aip.ProjectID = "+projectID;

//                OleDbDataReader reader = command.ExecuteReader();

//                List<UserAsset> result = new List<UserAsset>();

//                while (reader.Read())
//                {
//                    int id = 1;
//                    string assetname = "";
//                    string notes = "";
//                    AssetType type = AssetType._2DArt;
//                    AssetStatus status = AssetStatus.Completed;
//                    String software = "";
//                    int pegiRating = 3;

//                    id = reader.GetInt32(0);
//                    assetname = reader.GetString(1);
//                    notes = reader.GetString(3);
//                    Enum.TryParse<AssetStatus>(reader.GetString(4), out status);
//                    Enum.TryParse<AssetType>(reader.GetString(5), out type);
//                    software = reader.GetString(7);
//                    pegiRating = reader.GetInt32(8);
//                    Console.WriteLine();

//                    result.Add(new UserAsset(id, assetname, notes, null, type, status, software));
//                }

//                return result;
//            }

//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            Console.WriteLine();

//            return null;
//        }

//        public List<UsersAccounts.UserData> getUsersInProject(int projectID)
//        {
//            try
//            {
//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;

//                command.CommandText = "SELECT User.* FROM [User]" +
//                    " Inner join [UsersInProjects]" +
//                    " On [UsersInProjects].UserID = [User].ID " +
//                    " WHERE [UsersInProjects].ProjectID = " + projectID;

//                OleDbDataReader reader = command.ExecuteReader();

//                List<UsersAccounts.UserData> result = new List<UsersAccounts.UserData>();                

//                while (reader.Read())
//                {
//                    string password = "";
//                    string email = "";
//                    int id = 1;
//                    UserStatus status = UserStatus.Offline;
//                    UserType type = UserType.Developer;
//                    string username = "";

//                    id = reader.GetInt32(0);
//                    Enum.TryParse<UserStatus>(reader.GetString(1), out status);
//                    password = reader.GetString(2);
//                    email = reader.GetString(3);
//                    username = reader.GetString(4);
//                    Enum.TryParse<UserType>(reader.GetString(5), out type);

//                    result.Add(new UsersAccounts.UserData(id, username, email, password, status));
//                }  

//                return result;
//            }

//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            Console.WriteLine();

//            return null;
//        }

//        public List<UserProject> getOwnedProjectsOfUser(int userID)
//        {
//            try
//            {
//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;
//                command.CommandText = "SELECT Project.* FROM[Project] WHERE Owner = " + userID;

//                OleDbDataReader reader = command.ExecuteReader();

//                List<UserProject> result = new List<UserProject>();

//                while (reader.Read())
//                {

//                    int id = 1;
//                    string projectName = "";
//                    string description = "";
//                    ProjectType type = ProjectType.Game;
//                    ProjectStatus status = ProjectStatus.Completed;
//                    ProjectTag tag = ProjectTag.Game;

//                    projectName = reader.GetString(1);
//                    Enum.TryParse<ProjectType>(reader.GetString(2), out type);
//                    description = reader.GetString(3);
//                    Enum.TryParse<ProjectTag>(reader.GetString(5), out tag);
//                    Enum.TryParse<ProjectStatus>(reader.GetString(6), out status);

//                    result.Add(new UserProject(id, projectName, description, null, type, status));
//                }

//                return result;
//            }

//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            Console.WriteLine();

//            return null;
//        }

//        /// <summary>
//        /// Get all messages sended by the user
//        /// </summary>
//        /// <param name="userID">The ID of the user</param>
//        /// <returns>The list of the messages</returns>
//        public List<UserMessage> GetSentMessages(int userID)
//        {
//            try
//            {
//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;
//                command.CommandText = "SELECT Messages.* FROM[Messages] WHERE Sender = " + userID;

//                OleDbDataReader reader = command.ExecuteReader();

//                List<UserMessage> messages = new List<UserMessage>();

//                int receiverID = 0;
//                string message = "";
//                int messageID = 1;
//                int senderID = 0;
//                DateTime sended = DateTime.MinValue;
//                MessageType type = MessageType.Invite;

//                while (reader.Read())
//                {
//                    messageID = int.Parse(reader["ID"].ToString());
//                    receiverID = int.Parse(reader["Receiver"].ToString());
//                    senderID = int.Parse(reader["Sender"].ToString());
//                    message = reader["Message"].ToString();
//                    type = (MessageType)Enum.Parse(typeof(MessageType), reader["Type"].ToString());
//                    sended = Convert.ToDateTime(reader["SendedDate"]);

//                    messages.Add(new UserMessage(senderID, receiverID, message, sended, type));
//                }

//                return messages;
//            }

//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            return null;
//        }

//        /// <summary>
//        /// Get all messages for the user
//        /// </summary>
//        /// <param name="userID">The ID of the user</param>
//        /// <returns>The list of the messages</returns>
//        public List<UserMessage> GetReceivedMessages(int userID)
//        {
//            try
//            {
//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;
//                command.CommandText = "SELECT Messages.* FROM[Messages] WHERE Receiver = " + userID;

//                OleDbDataReader reader = command.ExecuteReader();

//                List<UserMessage> messages = new List<UserMessage>();

//                int receiverID = 0;
//                int senderID = 0;
//                string message = "";
//                int messageID = 1;
//                DateTime sended = DateTime.MinValue;
//                MessageType type = MessageType.Invite;

//                while (reader.Read())
//                {
//                    messageID = int.Parse(reader["ID"].ToString());
//                    receiverID = int.Parse(reader["Receiver"].ToString());
//                    senderID = int.Parse(reader["Sender"].ToString());
//                    message = reader["Message"].ToString();
//                    type = (MessageType)Enum.Parse(typeof(MessageType), reader["Type"].ToString());
//                    sended = Convert.ToDateTime(reader["SendedDate"]);

//                    messages.Add(new UserMessage(senderID, receiverID, message, sended, type));
//                }

//                return messages;
//            }

//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            return null;
//        }

//        #endregion

//        #region Change values

//        #region Change user values

//        /// <summary>
//        /// Change the username
//        /// </summary>
//        /// <param name="oldValue">Old username</param>
//        /// <param name="newValue">New username</param>
//        public void ChangeUserName(string oldValue, string newValue)
//        {
//            string commandText = "UPDATE [User] SET Username = '" + newValue + "' WHERE Username = '" + oldValue + "'";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Change the username
//        /// </summary>
//        /// <param name="id">The ID of the User</param>
//        /// <param name="newValue">New username</param>
//        public void ChangeUserName(int id, string newValue)
//        {
//            string commandText = "UPDATE [User] SET Username = '" + newValue + "' WHERE ID = " + id + "";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Change the email for an user
//        /// </summary>
//        /// <param name="username">The name of the user</param>
//        /// <param name="newValue">New Email of the user</param>
//        public void ChangeUserEmail(string username, string newValue)
//        {
//            string commandText = "UPDATE [User] SET Email = '" + newValue + "' WHERE Username = '" + username + "'";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Change the email for an user
//        /// </summary>
//        /// <param name="id">The ID of the user</param>
//        /// <param name="newValue">New Email of the user</param>
//        public void ChangeUserEmail(int id, string newValue)
//        {
//            string commandText = "UPDATE [User] SET Email = '" + newValue + "' WHERE ID = " + id + "";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Change the type of an user
//        /// </summary>
//        /// <param name="username">The name of the user</param>
//        /// <param name="newValue">New type for the user</param>
//        public void ChangeUserType(string username, UserType newValue)
//        {
//            string commandText = "UPDATE [User] SET Type = '" + newValue + "' WHERE Username = '" + username + "'";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Change the type of an user
//        /// </summary>
//        /// <param name="id">The ID of the user</param>
//        /// <param name="newValue">New type for the user</param>
//        public void ChangeUserType(int id, UserType newValue)
//        {
//            string commandText = "UPDATE [User] SET Type = '" + newValue + "' WHERE ID = " + id + "";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Change the current status of the user
//        /// </summary>
//        /// <param name="username">The name of the user</param>
//        /// <param name="newValue">New status of the user</param>
//        public void ChangeUserStatus(string username, UserStatus newValue)
//        {
//            string commandText = "UPDATE [User] SET Status = '" + newValue + "' WHERE Username = '" + username + "'";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Change the current status for the user
//        /// </summary>
//        /// <param name="id">The ID of the user</param>
//        /// <param name="newValue">New status of the user</param>
//        public void ChangeUserStatus(int id, UserStatus newValue)
//        {
//            string commandText = "UPDATE [User] SET Status = '" + newValue + "' WHERE ID = " + id + "";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Change the password of an user
//        /// </summary>
//        /// <param name="username">The name of the user</param>
//        /// <param name="newValue">New password of the user</param>
//        public void ChangeUserPassword(string username, string newValue)
//        {
//            string commandText = "UPDATE [User] SET [Password] = '" + newValue + "' WHERE Username = '" + username + "'";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Change the password of an user
//        /// </summary>
//        /// <param name="id">The ID of the user</param>
//        /// <param name="newValue">New Password of the user</param>
//        public void ChangeUserPassword(int id, string newValue)
//        {
//            string commandText = "UPDATE [User] SET [Password] = '" + newValue + "' WHERE ID = " + id + "";

//            ExecuteCommand(commandText);
//        }

//        #endregion

//        #region Change project values

//        /// <summary>
//        /// Changes the name of a project
//        /// </summary>
//        /// <param name="oldValue">The old project name</param>
//        /// <param name="newValue">New project name</param>
//        public void ChangeProjectName(string oldValue, string newValue)
//        {
//            string commandText = "UPDATE [Project] SET Projectname = '" + newValue + "' WHERE Projectname = '" + oldValue + "'";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the name of a project
//        /// </summary>
//        /// <param name="id">The ID of the project</param>
//        /// <param name="newValue">New project name</param>
//        public void ChangeProjectName(int id, string newValue)
//        {
//            string commandText = "UPDATE [Project] SET Projectname = '" + newValue + "' WHERE ID = " + id + "";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the type of the project
//        /// </summary>
//        /// <param name="projectname">The name of the project</param>
//        /// <param name="newValue">New type for the project</param>
//        public void ChangeProjectType(string projectname, ProjectType newValue)
//        {
//            string commandText = "UPDATE [Project] SET Type = '" + newValue + "' WHERE Projectname = '" + projectname + "'";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the type of the project
//        /// </summary>
//        /// <param name="id">The ID of the project</param>
//        /// <param name="newValue">New type for the project</param>
//        public void ChangeProjectType(int id, ProjectType newValue)
//        {
//            string commandText = "UPDATE [Project] SET Type = '" + newValue + "' WHERE ID = " + id + "";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the description of the project
//        /// </summary>
//        /// <param name="projectname">The name of the project</param>
//        /// <param name="newValue">New description of the project</param>
//        public void ChangeProjectDescription(string projectname, string newValue)
//        {
//            string commandText = "UPDATE [Project] SET Description = '" + newValue + "' WHERE Projectname = '" + projectname + "'";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the description of the project
//        /// </summary>
//        /// <param name="id">The ID of the project</param>
//        /// <param name="newValue">New description of the project</param>
//        public void ChangeProjectDescription(int id, string newValue)
//        {
//            string commandText = "UPDATE [Project] SET Description = '" + newValue + "' WHERE ID = " + id + "";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the owner of the project
//        /// </summary>
//        /// <param name="projectname">The name of the project</param>
//        /// <param name="newValue">The ID of the new owner</param>
//        public void ChangeProjectOwner(string projectname, int newValue)
//        {
//            string commandText = "UPDATE [Project] SET Owner = " + newValue + " WHERE Projectname = '" + projectname + "'";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the owner of the project
//        /// </summary>
//        /// <param name="id">The ID of the project</param>
//        /// <param name="newValue">The ID of the new owner</param>
//        public void ChangeProjectOwner(int id, int newValue)
//        {
//           string commandText = "UPDATE [Project] SET Owner = " + newValue + " WHERE ID = " + id + "";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the Tag of the project
//        /// </summary>
//        /// <param name="projectname">The name of the project</param>
//        /// <param name="newValue">New tag of the project</param>
//        public void ChangeProjectTag(string projectname, ProjectTag newValue)
//        {
//            string commandText = "UPDATE [Project] SET Tag = '" + newValue + "' WHERE Projectname = '" + projectname + "'";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the Tag of the project
//        /// </summary>
//        /// <param name="id">The ID of the project</param>
//        /// <param name="newValue">New tag for the project</param>
//        public void ChangeProjectTag(int id, int newValue)
//        {
//            string commandText = "UPDATE [Project] SET Tag = '" + newValue + "' WHERE ID = " + id + "";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the current status of the project
//        /// </summary>
//        /// <param name="projectname"></param>
//        /// <param name="newValue"></param>
//        public void ChangeProjectStatus(string projectname, ProjectStatus newValue)
//        {
//            string commandText = "UPDATE [Project] SET Status = '" + newValue + "' WHERE Projectname = '" + projectname + "'";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the current status of the project
//        /// </summary>
//        /// <param name="id">The ID of the project</param>
//        /// <param name="newValue">New status of the project</param>
//        public void ChangeProjectStatus(int id, ProjectStatus newValue)
//        {
//            string commandText = "UPDATE [Project] SET Status = '" + newValue + "' WHERE ID = " + id + "";

//            ExecuteCommand(commandText);
//        }


//        #endregion

//        #region Change asset values

//        /// <summary>
//        /// Changes the name of the asset
//        /// </summary>
//        /// <param name="oldValue">Old name of the asset</param>
//        /// <param name="newValue">New name of the asset</param>
//        public void ChangeAssetName(string oldValue, string newValue)
//        {
//            string commandText = "UPDATE [Asset] SET Assetname = '" + newValue + "' WHERE Assetname = '" + oldValue + "'";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the name of the asset
//        /// </summary>
//        /// <param name="id">The ID of the asset</param>
//        /// <param name="newValue">New name of the asset</param>
//        public void ChangeAssetName(int id, string newValue)
//        {
//            string commandText = "UPDATE [Asset] SET Assetname = '" + newValue + "' WHERE ID = " + id + "";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the creator of the asset (Logically only to deleted when the user is deleted)
//        /// </summary>
//        /// <param name="assetname">The name of the asset</param>
//        /// <param name="newValue">The ID of the new creator of the asset</param>
//        public void ChangeAssetCreator(string assetname, int newValue)
//        {
//            string commandText = "UPDATE [Asset] SET Creator = " + newValue + " WHERE Assetname = '" + assetname + "'";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the creator of the asset (Logically only to deleted when the user is deleted)
//        /// </summary>
//        /// <param name="id">The ID of the asset</param>
//        /// <param name="newValue">The ID of the new creator of the asset</param>
//        public void ChangeAssetCreator(int id, int newValue)
//        {
//            string commandText = "UPDATE [Asset] SET Creator = " + newValue + " WHERE ID = " + id + "";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the software used to create the asset
//        /// </summary>
//        /// <param name="assetname">The name of the asset</param>
//        /// <param name="newValue">New software used to create the asset</param>
//        public void ChangeAssetSoftware(string assetname, string newValue)
//        {
//            string commandText = "UPDATE [Asset] SET Software  = '" + newValue + "' WHERE Assetname = '" + assetname + "'";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the software used to create the asset
//        /// </summary>
//        /// <param name="id">The ID of the asset</param>
//        /// <param name="newValue">New software used to create the asset</param>
//        public void ChangeAssetSoftware(int id, string newValue)
//        {
//            string commandText = "UPDATE [Asset] SET Software = '" + newValue + "' WHERE ID = " + id + "";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the software notes
//        /// </summary>
//        /// <param name="assetname">The name of the asset</param>
//        /// <param name="newValue">New notes for the asset</param>
//        public void ChangeAssetNotes(string assetname, string newValue)
//        {
//            string commandText = "UPDATE [Asset] SET Notes = '" + newValue + "' WHERE Assetname = '" + assetname + "'";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the notes for the asset
//        /// </summary>
//        /// <param name="id">The ID of the asset</param>
//        /// <param name="newValue">New notes for the asset</param>
//        public void ChangeAssetNotes(int id, string newValue)
//        {
//            string commandText = "UPDATE [Asset] SET Notes = '" + newValue + "' WHERE ID = " + id + "";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the current status of the asset
//        /// </summary>
//        /// <param name="assetname">The name of the asset</param>
//        /// <param name="newValue">New status of the asset</param>
//        public void ChangeAssetStatus(string assetname, AssetStatus newValue)
//        {
//            string commandText = "UPDATE [Asset] SET Status = '" + newValue + "' WHERE Assetname = '" + assetname + "'";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the current status of the asset
//        /// </summary>
//        /// <param name="id">The ID of the asset</param>
//        /// <param name="newValue">New status of the asset</param>
//        public void ChangeAssetStatus(int id, AssetStatus newValue)
//        {
//            string commandText = "UPDATE [Asset] SET Status = '" + newValue + "' WHERE ID = " + id + "";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the tag of the asset
//        /// </summary>
//        /// <param name="assetname">The name of the asset</param>
//        /// <param name="newValue">New status of the asset</param>
//        public void ChangeAssetTag(string assetname, AssetType newValue)
//        {
//            string commandText = "UPDATE [Asset] SET Tag = '" + newValue + "' WHERE Assetname = '" + assetname + "'";

//            ExecuteCommand(commandText);
//        }

//        /// <summary>
//        /// Changes the tag of the asset
//        /// </summary>
//        /// <param name="id">The ID of the asset</param>
//        /// <param name="newValue">New tag of the asset</param>
//        public void ChangeAssetTag(int id, AssetType newValue)
//        {
//            string commandText = "UPDATE [Asset] SET Tag = '" + newValue + "' WHERE ID = " + id + "";

//            ExecuteCommand(commandText);
//        }

//        #endregion

//        #endregion

//        #region return tables 

//        /// <summary>
//        /// Shows a list of all users
//        /// </summary>
//        public void ShowAllUsers()
//        {
//            try
//            {
//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;
//                command.CommandText = "SELECT User.* FROM[User] ";

//                OleDbDataReader reader = command.ExecuteReader();
//                while (reader.Read())
//                {
//                    Console.Write(reader.GetInt32(0) + ", ");
//                    Console.Write(reader.GetString(1) + ", ");
//                    Console.Write(reader.GetString(2) + ", ");
//                    Console.Write(reader.GetString(3) + ", ");
//                    Console.Write(reader.GetString(4) + ", ");
//                    Console.Write(reader.GetString(5));
//                    Console.WriteLine();
//                }
//            }

//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            Console.WriteLine();
//        }

//        /// <summary>
//        /// Shows a list of all projects
//        /// </summary>
//        public void ShowAllProjects()
//        {
//            try
//            {
//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;
//                command.CommandText = "SELECT Project.* FROM[Project] ";

//                OleDbDataReader reader = command.ExecuteReader();
//                while (reader.Read())
//                {
//                    Console.Write(reader.GetInt32(0) + ", ");
//                    Console.Write(reader.GetString(1) + ", ");
//                    Console.Write(reader.GetString(2) + ", ");
//                    Console.Write(reader.GetString(3) + ", ");
//                    Console.Write(reader.GetValue(4).ToString() + ", ");
//                    Console.Write(reader.GetString(5) + ", ");
//                    Console.Write(reader.GetString(6));
//                    Console.WriteLine();
//                }
//            }

//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            Console.WriteLine();
//        }

//        /// <summary>
//        /// Shows a list of all assets
//        /// </summary>
//        public void ShowAllAssets()
//        {
//            try
//            {
//                OleDbCommand command = new OleDbCommand();
//                command.Connection = connection;
//                command.CommandText = "SELECT Asset.* FROM[Asset] ";

//                OleDbDataReader reader = command.ExecuteReader();
//                while (reader.Read())
//                {
//                    Console.Write(reader.GetInt32(0) + ", ");
//                    Console.Write(reader.GetString(1) + ", ");
//                    Console.Write(reader.GetValue(2) + ", ");
//                    Console.Write(reader.GetString(7) + ", ");
//                    Console.Write(reader.GetString(3) + ", ");
//                    Console.Write(reader.GetString(4) + ", ");
//                    Console.Write(reader.GetString(5) + ", ");
//                    Console.Write(reader.GetInt32(8));
//                    Console.WriteLine();
//                }
//            }

//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//            Console.WriteLine();
//        } 

//        #endregion
//    }
//}
