using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAC627_Project
{
    public partial class ViewProjectPageControl : UserControl
    {
        FormMain formMain;
        UserProject _userProject;
        UsersAccounts.UserData _curUserData;
        int? _userProjectID;

        public ViewProjectPageControl(FormMain form, int? userProjectID)
        {
            InitializeComponent();

            formMain = form;

            _userProjectID = userProjectID;

            DataBaseAccess dataBase = new DataBaseAccess();
            dataBase.StartConnection();
            _userProject = dataBase.getProject((int)userProjectID);
            dataBase.CloseConnection();

            _curUserData = formMain.UsersAccounts.GetCurrentUser();
            InitializeComponent();

            if (formMain.UsersAccounts.GetCurrentUser() != null)
            {
                   if (_userProject == null)
                {
                    formMain.ChangeToPage(FormMain.Pages.HomePage);
                }
                else
                {
                    if (_curUserData.GetUserID() == _userProject.GetAuthor().GetUserID())
                    {
                        btnEdit.Show();
                    }
                }
            }

            lblTitleDisplay.Text = _userProject.GetProjectTitle();
            lblAssetTypeDisplay.Text = _userProject.GetProjectType().ToString();
            lblCreatorDisplay.Text = _userProject.GetAuthor().userName;
            lblDescriptionDisplay.Text = _userProject.GetNotes();
            picThumbNail.ImageLocation = _userProject.GetThumbNail();
            picThumbNail.Location = new Point(10, 10); // broken
            formMain.Refresh();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            formMain.curSelectedUserProjectID = _userProjectID;
            formMain.ChangeToPage(FormMain.Pages.EditProjectPage);
        }
    }
}
