namespace DAC627_Project
{
    partial class UploadProjectPageControl
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
            this.lblUploadType = new System.Windows.Forms.Label();
            this.cboUploadType = new System.Windows.Forms.ComboBox();
            this.btnCreateProject = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblErrorTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.chkTermsConditions = new System.Windows.Forms.CheckBox();
            this.lblErrorAssetType = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblProjectType = new System.Windows.Forms.Label();
            this.cboProjectType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblUploadType
            // 
            this.lblUploadType.AutoSize = true;
            this.lblUploadType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUploadType.Location = new System.Drawing.Point(464, 80);
            this.lblUploadType.Name = "lblUploadType";
            this.lblUploadType.Size = new System.Drawing.Size(91, 18);
            this.lblUploadType.TabIndex = 89;
            this.lblUploadType.Text = "Upload Type";
            // 
            // cboUploadType
            // 
            this.cboUploadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUploadType.Items.AddRange(new object[] {
            "Asset",
            "Project"});
            this.cboUploadType.Location = new System.Drawing.Point(616, 80);
            this.cboUploadType.Name = "cboUploadType";
            this.cboUploadType.Size = new System.Drawing.Size(192, 21);
            this.cboUploadType.TabIndex = 0;
            this.cboUploadType.SelectedIndexChanged += new System.EventHandler(this.cboUploadType_SelectedIndexChanged);
            // 
            // btnCreateProject
            // 
            this.btnCreateProject.Location = new System.Drawing.Point(576, 480);
            this.btnCreateProject.Name = "btnCreateProject";
            this.btnCreateProject.Size = new System.Drawing.Size(104, 24);
            this.btnCreateProject.TabIndex = 6;
            this.btnCreateProject.Text = "Create Project";
            this.btnCreateProject.UseVisualStyleBackColor = true;
            this.btnCreateProject.Click += new System.EventHandler(this.btnUploadAsset_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.AccessibleName = "Notes";
            this.txtNotes.ForeColor = System.Drawing.Color.Gray;
            this.txtNotes.Location = new System.Drawing.Point(616, 224);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(192, 112);
            this.txtNotes.TabIndex = 3;
            this.txtNotes.Text = "Notes";
            this.txtNotes.Enter += new System.EventHandler(this.txt_Enter);
            this.txtNotes.Leave += new System.EventHandler(this.TextInput);
            // 
            // lblErrorTitle
            // 
            this.lblErrorTitle.AutoSize = true;
            this.lblErrorTitle.ForeColor = System.Drawing.Color.Red;
            this.lblErrorTitle.Location = new System.Drawing.Point(616, 151);
            this.lblErrorTitle.Name = "lblErrorTitle";
            this.lblErrorTitle.Size = new System.Drawing.Size(102, 13);
            this.lblErrorTitle.TabIndex = 86;
            this.lblErrorTitle.Text = "Error, name required";
            this.lblErrorTitle.Visible = false;
            // 
            // txtTitle
            // 
            this.txtTitle.AccessibleName = "Title";
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.Gray;
            this.txtTitle.Location = new System.Drawing.Point(616, 128);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(192, 20);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.Tag = "";
            this.txtTitle.Text = "Title";
            this.txtTitle.Enter += new System.EventHandler(this.txt_Enter);
            this.txtTitle.Leave += new System.EventHandler(this.TextInput);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(488, 128);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 18);
            this.lblTitle.TabIndex = 85;
            this.lblTitle.Text = "Title";
            // 
            // chkTermsConditions
            // 
            this.chkTermsConditions.AutoSize = true;
            this.chkTermsConditions.Location = new System.Drawing.Point(536, 448);
            this.chkTermsConditions.Name = "chkTermsConditions";
            this.chkTermsConditions.Size = new System.Drawing.Size(189, 17);
            this.chkTermsConditions.TabIndex = 5;
            this.chkTermsConditions.Text = "I agree to the terms and conditions";
            this.chkTermsConditions.UseVisualStyleBackColor = true;
            // 
            // lblErrorAssetType
            // 
            this.lblErrorAssetType.AutoSize = true;
            this.lblErrorAssetType.ForeColor = System.Drawing.Color.Red;
            this.lblErrorAssetType.Location = new System.Drawing.Point(616, 200);
            this.lblErrorAssetType.Name = "lblErrorAssetType";
            this.lblErrorAssetType.Size = new System.Drawing.Size(131, 13);
            this.lblErrorAssetType.TabIndex = 81;
            this.lblErrorAssetType.Text = "Error, project type required";
            this.lblErrorAssetType.Visible = false;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.Location = new System.Drawing.Point(480, 224);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(48, 18);
            this.lblConfirmPassword.TabIndex = 80;
            this.lblConfirmPassword.Text = "Notes";
            // 
            // lblProjectType
            // 
            this.lblProjectType.AutoSize = true;
            this.lblProjectType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectType.Location = new System.Drawing.Point(464, 176);
            this.lblProjectType.Name = "lblProjectType";
            this.lblProjectType.Size = new System.Drawing.Size(91, 18);
            this.lblProjectType.TabIndex = 76;
            this.lblProjectType.Text = "Project Type";
            // 
            // cboProjectType
            // 
            this.cboProjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProjectType.Items.AddRange(new object[] {
            "Unity Project",
            "Unreal Project"});
            this.cboProjectType.Location = new System.Drawing.Point(616, 176);
            this.cboProjectType.Name = "cboProjectType";
            this.cboProjectType.Size = new System.Drawing.Size(192, 21);
            this.cboProjectType.TabIndex = 2;
            this.cboProjectType.Leave += new System.EventHandler(this.DropDownInput);
            // 
            // UploadProjectPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboProjectType);
            this.Controls.Add(this.lblUploadType);
            this.Controls.Add(this.cboUploadType);
            this.Controls.Add(this.btnCreateProject);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblErrorTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.chkTermsConditions);
            this.Controls.Add(this.lblErrorAssetType);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblProjectType);
            this.Name = "UploadProjectPageControl";
            this.Size = new System.Drawing.Size(1280, 720);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUploadType;
        private System.Windows.Forms.ComboBox cboUploadType;
        private System.Windows.Forms.Button btnCreateProject;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblErrorTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox chkTermsConditions;
        private System.Windows.Forms.Label lblErrorAssetType;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblProjectType;
        private System.Windows.Forms.ComboBox cboProjectType;
    }
}
