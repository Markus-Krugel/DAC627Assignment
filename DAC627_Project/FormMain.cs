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

        public FormMain()
        {
            InitializeComponent();

            //use this in order to display the user control of your choice...
            ChangeToPage(Pages.LoginPage);
        }

        private void picHomeButton_Click(object sender, EventArgs e)
        {
            ChangeToPage(FormMain.Pages.HomePage);
            if (UsersAccounts.GetCurrentUser() != null)
            {
                picProfile.Show();
            }
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
        }

        public void ChangeToPage(Pages _page)
        {
            if (currentPage != null)
            {
                currentPage.Controls.Clear();
                currentPage.Dispose();
                this.Controls.Remove(currentPage);
            }


            switch (_page)
            {
                case Pages.AccountPage:
                    currentPage = new AccountPageControl(this);
                    break;
                case Pages.CreateAccountPage:
                    currentPage = new CreateAccountPageControl(this);
                    break;
                case Pages.HomePage:
                    currentPage = new HomePageControl(this);
                    break;
                case Pages.LoginPage:
                    currentPage = new LoginPageControl(this);
                    break;
                case Pages.MyAssetsPage:
                    currentPage = new MyAssetsPageControl(this);
                    break;
                case Pages.UploadAssetPage:
                    currentPage = new UploadAssetPageControl(this);
                    break;
                case Pages.UploadProjectPage:
                    currentPage = new UploadProjectPageControl(this);
                    break;
                case Pages.EditAssetPage:
                    currentPage = new EditAssetPageControl(this, curSelectedAssetID);
                    break;
                case Pages.EditProjectPage:
                    currentPage = new EditProjectPageControl(this, curSelectedUserProjectID);
                    break;
                case Pages.TestPage:
                    currentPage = new TestPageControl(this);
                    break;
                case Pages.ViewAssetPage:
                    currentPage = new ViewAssetPageControl(this, curSelectedAssetID);
                    break;
                case Pages.ViewProjectPage:
                    currentPage = new ViewProjectPageControl(this);
                    break;
                default:
                    return;
            }
            currentPage.Dock = DockStyle.Fill;
            Controls.Add(currentPage);
        }

        private void picProfile_Click(object sender, EventArgs e)
        {
            ChangeToPage(Pages.AccountPage);
        }
    }
}
