using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            DataBaseAccess test = new DataBaseAccess();

            //test.addUser("Tach", "email@email.com", "Email", "Reviewer");
            //test.addAsset("Car", 1, "1.3", "Completed", "Text");
            //test.addProject("Game engine", "Software", "Simple 2D game engine", 2, "Software", "In Development");

            //test.changeUsername("test12345", "test");
            //test.changeUsername(2, "test12345");

            //test.changePassword(2, "test12345");
            //test.changePassword("test12345", "test");

            //test.changeEmail("MarkusK", "mk2@web.de");
            //test.changeEmail(1, "mk@web.de");

            //test.changeType("MarkusK", "Reviewer");
            //test.changeType(1, "Developer");

            //test.changeUserStatus("MarkusK", "Online");
            //test.changeUserStatus(1, "Offline");

            //test.showAllUsers();
            //test.showAllProjects();
            //test.showAllAssets();

            test.closeConnection();
        }
    }
}
