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

        public FormMain()
        {
            InitializeComponent();

            //use this in order to display the user control of your choice...
            ChangeToPage(Pages.CreateAccountPage);
        }

        private void picHomeButton_Click(object sender, EventArgs e)
        {
            currentPage.Hide();
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
            LoginPage
        }

        public void ChangeToPage(Pages _page)
        {
            UserControl m_userControl = new UserControl();
           
            switch (_page)
            {
                case Pages.AccountPage:
                    m_userControl = new AccountPageControl(this);
                    break;
                case Pages.CreateAccountPage:
                    m_userControl = new CreateAccountPageControl(this);
                    break;
                case Pages.HomePage:
                    m_userControl = new HomePageControl(this);
                    break;
                case Pages.LoginPage:
                    m_userControl = new LoginPageControl(this);
                    break;
                default:
                    return;
            }
            currentPage = m_userControl;
            m_userControl.Dock = DockStyle.Fill;
            Controls.Add(m_userControl);
        }

       
    }
}
