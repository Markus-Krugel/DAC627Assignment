namespace DAC627_Project
{
    partial class HomePageControl
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtSearchAsset = new System.Windows.Forms.TextBox();
            this.txtSearchProject = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnLogin.Location = new System.Drawing.Point(1085, 32);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(77, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btn_logIn_click);
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(1168, 32);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(77, 23);
            this.btnJoin.TabIndex = 3;
            this.btnJoin.Text = "Join";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btn_CreateAnAccount_click);
            // 
            // txtPassword
            // 
            this.txtPassword.AccessibleName = "Password";
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtPassword.Location = new System.Drawing.Point(887, 32);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(192, 21);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "Password";
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // txtUserName
            // 
            this.txtUserName.AccessibleName = "Username";
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.Color.Gray;
            this.txtUserName.Location = new System.Drawing.Point(689, 32);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(192, 20);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Text = "Username";
            this.txtUserName.Enter += new System.EventHandler(this.txt_Enter);
            this.txtUserName.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtSearchAsset
            // 
            this.txtSearchAsset.AccessibleName = "Search Assets";
            this.txtSearchAsset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchAsset.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchAsset.Location = new System.Drawing.Point(280, 112);
            this.txtSearchAsset.Name = "txtSearchAsset";
            this.txtSearchAsset.Size = new System.Drawing.Size(192, 20);
            this.txtSearchAsset.TabIndex = 5;
            this.txtSearchAsset.Text = "Search Assets";
            this.txtSearchAsset.Enter += new System.EventHandler(this.txt_Enter);
            this.txtSearchAsset.Leave += new System.EventHandler(this.txt_Leave);
            this.txtSearchAsset.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtSearchAsset_PreviewKeyDown);
            // 
            // txtSearchProject
            // 
            this.txtSearchProject.AccessibleName = "Search Projects";
            this.txtSearchProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchProject.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchProject.Location = new System.Drawing.Point(832, 112);
            this.txtSearchProject.Name = "txtSearchProject";
            this.txtSearchProject.Size = new System.Drawing.Size(192, 20);
            this.txtSearchProject.TabIndex = 6;
            this.txtSearchProject.Text = "Search Projects";
            this.txtSearchProject.Enter += new System.EventHandler(this.txt_Enter);
            this.txtSearchProject.Leave += new System.EventHandler(this.txt_Leave);
            this.txtSearchProject.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtSearchProject_PreviewKeyDown);
            // 
            // HomePageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSearchProject);
            this.Controls.Add(this.txtSearchAsset);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.btnLogin);
            this.Name = "HomePageControl";
            this.Size = new System.Drawing.Size(1280, 720);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtSearchAsset;
        private System.Windows.Forms.TextBox txtSearchProject;
    }
}
