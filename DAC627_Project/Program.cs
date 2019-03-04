using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAC627_Project.Enums;

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

            database.startConnection();

            //database.addUser("Tach", "email@email.com", "Email", UserType.Reviewer);
            //database.addAsset("Car", 1, AssetStatus.Planning, AssetTag.Sound, "Audacity", "1.3");
            //database.addProject("Game engine", ProjectType.Software, "Simple 2D game engine", 2, ProjectTag.Software, ProjectStatus.Planning);

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

            //database.changeAssetVersion("Algorithms", "2.1");
            //database.changeAssetVersion(1, "1.0");

            //database.changeAssetSoftware("Algorithms", "Gimp");
            //database.changeAssetSoftware(1, "Texteditor");

            //database.changeAssetStatus("Algorithms", AssetStatus.Planning);
            //database.changeAssetStatus(1, AssetStatus.In_Development);

            //database.changeAssetTag("Algorithms", AssetTag.Sound);
            //database.changeAssetTag(1, AssetTag.Text);

            //Console.WriteLine(database.GetUser(1));
            Console.WriteLine(database.GetUser("DieterF"));

            //database.showAllUsers();
            //database.showAllProjects();
            //database.showAllAssets();

            database.closeConnection();
        }
    }
}
