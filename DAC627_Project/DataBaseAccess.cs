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
            try
            {
                connection = new OleDbConnection();
                connection.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ../../Database/Database.accdb;
                Persist Security Info = False;";
                connection.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void closeConnection()
        {
            connection.Close();
        }

        #region add commands
        public void addUser(string password, string email, string username, string type, string status = "Offline")
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [User] (Status, [Password], Email, Username, Type ) VALUES " +
                                    "('" + status + "','" + password + "','" + email + "','" + username + "','" + type + "')";

                command.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        public void addProject(string name, string type, string description, int creator, string tag, string status)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Project ( Projectname, Type, Description, Creator, Tag, Status ) VALUES " +
                                    "('" + name + "','" + type + "','" + description + "','" + creator + "','" + tag + "','" + status + "')";

                command.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        public void addAsset(string name, int creator, string version, string status, string tag)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Asset ( Assetname, Creator, [Software Version], Status, Tag ) VALUES " +
                                    "('" + name + "'," + creator + ",'" + version + "','" + status + "','" + tag + "')";

                command.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }
        #endregion

        #region change values
        #region change user values
        public void changeUsername(string oldValue, string newValue)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE [User] SET Username = '" + newValue + "' WHERE Username = '" + oldValue + "'";

                command.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        public void changeUsername(int id, string newValue)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE [User] SET Username = '" + newValue + "' WHERE ID = " + id + "";

                command.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        public void changeEmail(string username, string newValue)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE [User] SET Email = '" + newValue + "' WHERE Username = '" + username + "'";

                command.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        public void changeEmail(int id, string newValue)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE [User] SET Email = '" + newValue + "' WHERE ID = " + id + "";

                command.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        public void changeType(string username, string newValue)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE [User] SET Type = '" + newValue + "' WHERE Username = '" + username + "'";

                command.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        public void changeType(int id, string newValue)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE [User] SET Type = '" + newValue + "' WHERE ID = " + id + "";

                command.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        public void changeUserStatus(string username, string newValue)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE [User] SET Status = '" + newValue + "' WHERE Username = '" + username + "'";

                command.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        public void changeUserStatus(int id, string newValue)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE [User] SET Status = '" + newValue + "' WHERE ID = " + id + "";

                command.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        public void changePassword(string username, string newValue)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE [User] SET [Password] = '" + newValue + "' WHERE Username = '" + username + "'";

                command.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }

        public void changePassword(int id, string newValue)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE [User] SET [Password] = '" + newValue + "' WHERE ID = " + id + "";

                command.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
        }
        #endregion

        #region change project values
        #endregion

        #region change asset values
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
