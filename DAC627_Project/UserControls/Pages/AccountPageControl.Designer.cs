namespace DAC627_Project
{
    partial class AccountPageControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.picAccountPageProfile = new System.Windows.Forms.PictureBox();
            this.btnViewMyAssets = new System.Windows.Forms.Button();
            this.btnUploadAsset = new System.Windows.Forms.Button();
            this.btnCreateProject = new System.Windows.Forms.Button();
            this.btnViewMyProjects = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnChangeProfilePic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picAccountPageProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(560, 200);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(45, 18);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(544, 152);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(80, 18);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "UserName";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(560, 244);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 18);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "Name";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(656, 152);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(192, 20);
            this.txtUserName.TabIndex = 8;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(656, 200);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(192, 20);
            this.txtEmail.TabIndex = 10;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(656, 242);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(192, 20);
            this.txtName.TabIndex = 14;
            // 
            // picAccountPageProfile
            // 
            this.picAccountPageProfile.Image = global::DAC627_Project.Properties.Resources.DefaultProfilePic;
            this.picAccountPageProfile.Location = new System.Drawing.Point(400, 152);
            this.picAccountPageProfile.Name = "picAccountPageProfile";
            this.picAccountPageProfile.Size = new System.Drawing.Size(120, 120);
            this.picAccountPageProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAccountPageProfile.TabIndex = 2;
            this.picAccountPageProfile.TabStop = false;
            // 
            // btnViewMyAssets
            // 
            this.btnViewMyAssets.Location = new System.Drawing.Point(639, 314);
            this.btnViewMyAssets.Name = "btnViewMyAssets";
            this.btnViewMyAssets.Size = new System.Drawing.Size(104, 23);
            this.btnViewMyAssets.TabIndex = 15;
            this.btnViewMyAssets.Text = "View My Assets";
            this.btnViewMyAssets.UseVisualStyleBackColor = true;
            this.btnViewMyAssets.Click += new System.EventHandler(this.btnViewMyAssets_Click);
            // 
            // btnUploadAsset
            // 
            this.btnUploadAsset.Location = new System.Drawing.Point(639, 353);
            this.btnUploadAsset.Name = "btnUploadAsset";
            this.btnUploadAsset.Size = new System.Drawing.Size(104, 23);
            this.btnUploadAsset.TabIndex = 16;
            this.btnUploadAsset.Text = "Upload A Asset";
            this.btnUploadAsset.UseVisualStyleBackColor = true;
            this.btnUploadAsset.Click += new System.EventHandler(this.btnUploadAsset_Click);
            // 
            // btnCreateProject
            // 
            this.btnCreateProject.Location = new System.Drawing.Point(767, 353);
            this.btnCreateProject.Name = "btnCreateProject";
            this.btnCreateProject.Size = new System.Drawing.Size(104, 23);
            this.btnCreateProject.TabIndex = 17;
            this.btnCreateProject.Text = "Create A Project";
            this.btnCreateProject.UseVisualStyleBackColor = true;
            this.btnCreateProject.Click += new System.EventHandler(this.btnCreateProject_Click);
            // 
            // btnViewMyProjects
            // 
            this.btnViewMyProjects.Location = new System.Drawing.Point(767, 314);
            this.btnViewMyProjects.Name = "btnViewMyProjects";
            this.btnViewMyProjects.Size = new System.Drawing.Size(104, 23);
            this.btnViewMyProjects.TabIndex = 18;
            this.btnViewMyProjects.Text = "View My Projects";
            this.btnViewMyProjects.UseVisualStyleBackColor = true;
            this.btnViewMyProjects.Click += new System.EventHandler(this.btnViewMyProjects_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(656, 392);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(198, 23);
            this.btnLogOut.TabIndex = 19;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(656, 285);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(192, 23);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "Edit User Information";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnChangeProfilePic
            // 
            this.btnChangeProfilePic.Location = new System.Drawing.Point(400, 278);
            this.btnChangeProfilePic.Name = "btnChangeProfilePic";
            this.btnChangeProfilePic.Size = new System.Drawing.Size(120, 23);
            this.btnChangeProfilePic.TabIndex = 21;
            this.btnChangeProfilePic.Text = "Upload Profile Picture";
            this.btnChangeProfilePic.UseVisualStyleBackColor = true;
            this.btnChangeProfilePic.Click += new System.EventHandler(this.btnChangeProfilePic_Click);
            // 
            // AccountPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnChangeProfilePic);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnViewMyProjects);
            this.Controls.Add(this.btnCreateProject);
            this.Controls.Add(this.btnUploadAsset);
            this.Controls.Add(this.btnViewMyAssets);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picAccountPageProfile);
            this.Name = "AccountPageControl";
            this.Size = new System.Drawing.Size(1280, 720);
            ((System.ComponentModel.ISupportInitialize)(this.picAccountPageProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picAccountPageProfile;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnViewMyAssets;
        private System.Windows.Forms.Button btnUploadAsset;
        private System.Windows.Forms.Button btnCreateProject;
        private System.Windows.Forms.Button btnViewMyProjects;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnChangeProfilePic;
    }
}
