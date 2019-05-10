using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAC627_Project
{
    public partial class FormMain : Form
    {
        public UserControl currentPage;
        public UsersAccounts UsersAccounts = new UsersAccounts();
        public int? curSelectedAssetID  = null;
        public int? curSelectedUserProjectID = null;

        int pageHistoryPos = 0;
        List<PageHistory> pageHistoryList = new List<PageHistory>();

        //Add to this as more information needs to be inputted into userControls
        public struct PageHistory
        {
            public Pages pageType;
            public int? id;
            public string message;
 
        }


        public FormMain()
        {
            InitializeComponent();

            //use this in order to display the user control of your choice...
            ChangeToPage(Pages.LoginPage);
            //string yeet = HelperTools.LoadFromFile();
            //string foo = HelperTools.AddFileToStorage(yeet, 0, 1);

            //HelperTools.CopyFile(@"../../", @"C:\Users\mininod\Downloads\TestFolder", "test.txt");
        }

        private void picHomeButton_Click(object sender, EventArgs e)
        {
            ChangeToPage(FormMain.Pages.HomePage);
        }

        private void picHomeButton_MouseEnter(object sender, EventArgs e)
        {
            Btn_DeafultMouseEnter();
        }

        private void picHomeButton_MouseLeave(object sender, EventArgs e)
        {
            Btn_DeafultMouseLeave();
        }

        //**All global functions or variables should go here**


        public bool RemoveGrayText(TextBox textBox)
        {
            //Test if the text box has the default text, the colour for your default name text boxes should ALWAYS be Color.Grey to ensure this works.
            if (textBox.Text == textBox.AccessibleName && textBox.ForeColor == Color.Gray) 
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckEmpty(TextBox textBox)
        {
            //If the user did not type anything, then return text to orginal value and colours 
            if (textBox.Text == "")
            {
                textBox.Text = textBox.AccessibleName;
                textBox.ForeColor = Color.Gray;
                return true;
            }
            else
            {
                return false;
            }
        }

        //This is what every button will do when a mouse enters it 
        public void Btn_DeafultMouseEnter()
        {
            this.Cursor = Cursors.Hand;
        }
        
        //This is what every button will do when a mouse leaves it 
        public void Btn_DeafultMouseLeave()
        {
            this.Cursor = Cursors.Default;
        }


        //Pages
        public enum Pages
        {
            AccountPage,
            CreateAccountPage,
            HomePage,
            LoginPage,
            MyAssetsPage,
            UploadAssetPage,
            UploadProjectPage,
            EditAssetPage,
            EditProjectPage,
            TestPage,
            ViewAssetPage,
            ViewProjectPage,
            MessagingPage
        }

        public void ChangeToPage(Pages _page, string message = null)
        {
            UsersAccounts.UserData curUser = UsersAccounts.GetCurrentUser();

            if (curUser != null)
            {
                if (curUser.GetProfilePicPath() != "")
                    picProfile.ImageLocation = curUser.GetProfilePicPath();

                picProfile.Show();
            }
            else
            {
                picProfile.Hide();
            }

            if (currentPage != null)
            {
                currentPage.Controls.Clear();
                currentPage.Dispose();
                this.Controls.Remove(currentPage);
            }


            PageHistory newPageHistory;

            switch (_page)
            {
                case Pages.AccountPage:
                    currentPage = new AccountPageControl(this);
                    newPageHistory.pageType = Pages.AccountPage;
                    newPageHistory.id = null;
                    newPageHistory.message = null;
                    break;
                case Pages.CreateAccountPage:
                    currentPage = new CreateAccountPageControl(this);
                    newPageHistory.pageType = Pages.CreateAccountPage;
                    newPageHistory.id = null;
                    newPageHistory.message = null;
                    break;
                case Pages.HomePage:
                    currentPage = new HomePageControl(this);
                    newPageHistory.pageType = Pages.HomePage;
                    newPageHistory.id = null;
                    newPageHistory.message = null;
                    break;
                case Pages.LoginPage:
                    currentPage = new LoginPageControl(this);
                    newPageHistory.pageType = Pages.LoginPage;
                    newPageHistory.id = null;
                    newPageHistory.message = null;
                    break;
                case Pages.MyAssetsPage:
                    currentPage = new MyAssetsPageControl(this, message);
                    newPageHistory.pageType = Pages.MyAssetsPage;
                    newPageHistory.id = null;
                    newPageHistory.message = message;
                    break;
                case Pages.UploadAssetPage:
                    currentPage = new UploadAssetPageControl(this);
                    newPageHistory.pageType = Pages.UploadAssetPage;
                    newPageHistory.id = null;
                    newPageHistory.message = null;
                    break;
                case Pages.UploadProjectPage:
                    currentPage = new UploadProjectPageControl(this);
                    newPageHistory.pageType = Pages.UploadProjectPage;
                    newPageHistory.id = null;
                    newPageHistory.message = null;
                    break;
                case Pages.EditAssetPage:
                    currentPage = new EditAssetPageControl(this, curSelectedAssetID);
                    newPageHistory.pageType = Pages.EditAssetPage;
                    newPageHistory.id = curSelectedAssetID;
                    newPageHistory.message = null;
                    break;
                case Pages.EditProjectPage:
                    currentPage = new EditProjectPageControl(this, curSelectedUserProjectID);
                    newPageHistory.pageType = Pages.EditProjectPage;
                    newPageHistory.id = curSelectedAssetID;
                    newPageHistory.message = null;
                    break;
                case Pages.TestPage:
                    currentPage = new TestPageControl(this);
                    newPageHistory.pageType = Pages.TestPage;
                    newPageHistory.id = null;
                    newPageHistory.message = null;
                    break;
                case Pages.ViewAssetPage:
                    currentPage = new ViewAssetPageControl(this, curSelectedAssetID);
                    newPageHistory.pageType = Pages.ViewAssetPage;
                    newPageHistory.id = curSelectedAssetID;
                    newPageHistory.message = null;
                    break;
                case Pages.ViewProjectPage:
                    currentPage = new ViewProjectPageControl(this, curSelectedUserProjectID);
                    newPageHistory.pageType = Pages.ViewProjectPage;
                    newPageHistory.id = null;
                    newPageHistory.message = null;
                    break;
                case Pages.MessagingPage:
                    currentPage = new MessagingPageControl(this);
                    newPageHistory.pageType = Pages.AccountPage;
                    newPageHistory.id = null;
                    newPageHistory.message = null;
                    break;
                default:
                    return;
            }
            pageHistoryList.Add(newPageHistory);
            pageHistoryPos++;
            currentPage.Dock = DockStyle.Fill;
            Controls.Add(currentPage);
        }

        private void picProfile_Click(object sender, EventArgs e)
        {
            ChangeToPage(Pages.AccountPage);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (pageHistoryPos > 1)
            {
                curSelectedUserProjectID = pageHistoryList[pageHistoryPos - 2].id;
                ChangeToPage(pageHistoryList[pageHistoryPos - 2].pageType, pageHistoryList[pageHistoryList.Count - 1].message);
                pageHistoryPos -= 2;
            }
        }
    }
}
