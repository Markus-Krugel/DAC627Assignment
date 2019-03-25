using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAC627_Project.Enums;
using DAC627_Project.Database_Classes;

namespace DAC627_Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormMain());

            DataBaseAccess database = new DataBaseAccess();

            database.StartConnection();

            // Commands for adding

            //Console.WriteLine(database.AddUser("Tach", "email@email.com", "Email", UserType.Reviewer,"Dieter Email",
            //    UserStatus.Online, "profile"));
            //Console.WriteLine(database.AddAsset("Car", 1, AssetStatus.Planning, AssetType.Sound, "Audacity", "1.3","vehicle",
            //    PegiRating._3, "1", "1", "1", "1", "1", "1", "1"));
            //Console.WriteLine(database.AddProject("Game engine 2", ProjectType.Software, "Simple 2D game engine", 2, 
            //    ProjectTag.Software, ProjectStatus.Planning,"thumbnail"));




            // Commands for changing

            //database.changeUserName("test12345", "Test");
            //database.changeUserName(2, "test12345");

            //database.changeUserPassword(2, "test12345");
            //database.changeUserPassword("test12345", "Test");

            //database.changeUserEmail("MarkusK", "mk2@web.de");
            //database.changeUserEmail(1, "mk@web.de");

            //database.changeUserType("MarkusK", "Reviewer");
            //database.changeUserType(1, "Developer");

            //database.changeUserStatus("MarkusK", "Online");
            //database.changeUserStatus(1, "Offline");

            //database.changeProjectName("Sorting algorithms", "Test");
            //database.changeProjectName(1, "Sorting algorithms");

            //database.changeProjectStatus("Sorting algorithms", ProjectStatus.Planning);
            //database.changeProjectStatus(1, ProjectStatus.Completed);

            //database.changeProjectDescription("Sorting algorithms", "Test");
            //database.changeProjectDescription(1, "A list of common sorting algorithms");

            //database.changeProjectTag("Sorting algorithms", ProjectTag.Software);
            //database.changeProjectTag(1, ProjectTag.Research);

            //database.changeProjectOwner("Sorting algorithms", 4);
            //database.changeProjectOwner(1, 1);

            //database.changeProjectOwner("Sorting algorithms", 4);
            //database.changeProjectOwner(1, 1);

            //database.changeProjectType("Sorting algorithms", ProjectType.Software);
            //database.changeProjectType(1, ProjectType.Research);

            //database.changeAssetName("Algorithms", "Test");
            //database.changeAssetName(1, "Algorithms");

            //database.changeAssetCreator("Algorithms", 10);
            //database.changeAssetCreator(1, 1);

            //database.changeAssetNotes("Algorithms", "Test");
            //database.changeAssetNotes(1, "List of Algorithms");

            //database.changeAssetSoftware("Algorithms", "Gimp");
            //database.changeAssetSoftware(1, "Texteditor");

            //database.changeAssetStatus("Algorithms", AssetStatus.Planning);
            //database.changeAssetStatus(1, AssetStatus.In_Development);

            //database.ChangeAssetType("Algorithms", AssetType.Sound);
            //database.ChangeAssetType(1, AssetType.Text);



            // Commands for getting (List of) classes 

            //Console.WriteLine(database.GetUser(1).ToString());
            //Console.WriteLine(database.GetUser("DieterF").ToString());

            //Console.WriteLine(database.getProject(1).ToString());
            //Console.WriteLine(database.getProject("Jumper").ToString());

            //Console.WriteLine(database.getAsset(9).ToString());
            //Console.WriteLine(database.getAsset("Solent-Logo").ToString());

            // List<DatabaseAsset> assetsOfUser = database.getAssetsOfUser(3);
            // foreach (DatabaseAsset asset in assetsOfUser)
            //     Console.WriteLine(asset.ToStringShort());

            //List<DatabaseProject> projectsOfUser = database.getOwnedProjectsOfUser(1);
            //foreach (DatabaseProject project in projectsOfUser)
            //    Console.WriteLine(project.ToStringWithoutOwner());

            //List<DatabaseProject> projectsOfUser = database.getProjectsOfUser(1);
            //foreach (DatabaseProject project in projectsOfUser)
            //    Console.WriteLine(project.ToStringWithoutOwner());

            //List<DatabaseAsset> assetsInProject = database.getAssetsInProject(2);
            //foreach (DatabaseAsset asset in assetsInProject)
            //    Console.WriteLine(asset.ToStringShort());

            //List<DatabaseUser> usersInProject = database.getUsersInProject(2);
            //foreach (DatabaseUser user in usersInProject)
            //    Console.WriteLine(user);



            // Search commands

            //List<DatabaseProject> searchProjects = database.SearchProject();
            //List<DatabaseProject> searchProjects = database.SearchProject("sort");  
            //List<DatabaseProject> searchProjects = database.SearchProject(null, ProjectType.Software);
            //List<DatabaseProject> searchProjects = database.SearchProject(null, ProjectType.Null, ProjectTag.Software);
            //List<DatabaseProject> searchProjects = database.SearchProject(null,ProjectType.Null,ProjectTag.Null,ProjectStatus.In_Development);
            //List<DatabaseProject> searchProjects = database.SearchProject("System", ProjectType.Null, ProjectTag.Null, ProjectStatus.In_Development);
            //
            //foreach (DatabaseProject project in searchProjects)
            //    Console.WriteLine(project.ToStringWithoutOwner());

            //List<DatabaseAsset> searchAssets = database.SearchAsset();
            //List<DatabaseAsset> searchAssets = database.SearchAsset("Ogo");
            //List<DatabaseAsset> searchAssets = database.SearchAsset(null, AssetType.Text);
            //List<DatabaseAsset> searchAssets = database.SearchAsset(null, AssetType.Null, AssetStatus.Completed);
            //List<DatabaseAsset> searchAssets = database.SearchAsset(null, AssetType.Null, AssetStatus.Null, 7);
            //List<DatabaseAsset> searchAssets = database.SearchAsset(null, "vehicle", AssetType.Null, AssetStatus.Null, PegiRating._3);
            //
            //foreach (DatabaseAsset asset in searchAssets)
            //    Console.WriteLine(asset.ToStringShort());



            // Add to projects

            //database.AddAssetToProject(2, 1);
            //database.AddUserToProject(1, 2);



            // Remove from Projects

            //database.RemoveAssetFromProject(2, 1);
            //database.RemoveUserFromProject(1, 2);




            // Delete Commands

            //database.DeleteProject(1);
            //database.DeleteUser(1);
            //database.DeleteAsset(1);





            // Message Commands

            //database.AddMessage(1, 2, "Message", DateTime.Now, MessageType.Message);
            //List<DatabaseMessage> messages = database.GetReceivedMessages(1);
            //foreach(DatabaseMessage message in messages)
            //    Console.WriteLine(message);
            //messages = database.GetSendedMessages(1);
            //foreach (DatabaseMessage message in messages)
            //    Console.WriteLine(message);
            //database.DeleteMessage(13);
            //database.ShowAllMessages();




            // New Change Methods

            //database.ChangeUserFullName(1, "Markus Krugel");
            //database.ChangeUserProfile(1, "Profile here");
            database.ChangeProjectTags(1, "Test");
            database.ChangeProjectThumbnail(1, "Thumbnail");
            database.ChangeAssetPath(1, "Path");
            database.ChangeAssetPegi(1, PegiRating._16);
            database.ChangeAssetThumbnail(1, "Thumbnail");
            database.ChangeAssetTags(1, "Tags");
            database.ChangeAssetGalleryOne(1, "One");
            database.ChangeAssetGalleryTwo(1, "Two");
            database.ChangeAssetGalleryThree(1, "Three");
            database.ChangeAssetGalleryFour(1, "Four");
            database.ChangeAssetGalleryFive(1, "Five");




            // Shows list of all datas in the output window

            //database.ShowAllUsers();
            //database.ShowAllProjects();
            //database.ShowAllAssets();

            database.CloseConnection();
        }
    }
}
