namespace DAC627_Project
{
    partial class UploadAssetPageControl
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
            this.lblErrorTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.chkTermsConditions = new System.Windows.Forms.CheckBox();
            this.lblErrorAssetStatus = new System.Windows.Forms.Label();
            this.lblErrorPegi = new System.Windows.Forms.Label();
            this.lblErrorSoftwareUsed = new System.Windows.Forms.Label();
            this.lblErrorAssetType = new System.Windows.Forms.Label();
            this.txtAssetStatus = new System.Windows.Forms.TextBox();
            this.txtSoftwareUsed = new System.Windows.Forms.TextBox();
            this.txtAssetType = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblPegi = new System.Windows.Forms.Label();
            this.lblAssetStatus = new System.Windows.Forms.Label();
            this.lblSoftwareUsed = new System.Windows.Forms.Label();
            this.lblAssetType = new System.Windows.Forms.Label();
            this.cboPegi = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnUploadAsset = new System.Windows.Forms.Button();
            this.btnChooseAsset = new System.Windows.Forms.Button();
            this.lblChooseAsset = new System.Windows.Forms.Label();
            this.lblErrorChooseAsset = new System.Windows.Forms.Label();
            this.cboUploadType = new System.Windows.Forms.ComboBox();
            this.lblUploadType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblErrorTitle
            // 
            this.lblErrorTitle.AutoSize = true;
            this.lblErrorTitle.ForeColor = System.Drawing.Color.Red;
            this.lblErrorTitle.Location = new System.Drawing.Point(616, 151);
            this.lblErrorTitle.Name = "lblErrorTitle";
            this.lblErrorTitle.Size = new System.Drawing.Size(102, 13);
            this.lblErrorTitle.TabIndex = 56;
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
            this.txtTitle.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(496, 128);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 18);
            this.lblTitle.TabIndex = 55;
            this.lblTitle.Text = "Title";
            // 
            // chkTermsConditions
            // 
            this.chkTermsConditions.AutoSize = true;
            this.chkTermsConditions.Location = new System.Drawing.Point(536, 592);
            this.chkTermsConditions.Name = "chkTermsConditions";
            this.chkTermsConditions.Size = new System.Drawing.Size(189, 17);
            this.chkTermsConditions.TabIndex = 8;
            this.chkTermsConditions.Text = "I agree to the terms and conditions";
            this.chkTermsConditions.UseVisualStyleBackColor = true;
            // 
            // lblErrorAssetStatus
            // 
            this.lblErrorAssetStatus.AutoSize = true;
            this.lblErrorAssetStatus.ForeColor = System.Drawing.Color.Red;
            this.lblErrorAssetStatus.Location = new System.Drawing.Point(616, 344);
            this.lblErrorAssetStatus.Name = "lblErrorAssetStatus";
            this.lblErrorAssetStatus.Size = new System.Drawing.Size(132, 13);
            this.lblErrorAssetStatus.TabIndex = 52;
            this.lblErrorAssetStatus.Text = "Error, asset status required";
            this.lblErrorAssetStatus.Visible = false;
            // 
            // lblErrorPegi
            // 
            this.lblErrorPegi.AutoSize = true;
            this.lblErrorPegi.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPegi.Location = new System.Drawing.Point(616, 296);
            this.lblErrorPegi.Name = "lblErrorPegi";
            this.lblErrorPegi.Size = new System.Drawing.Size(129, 13);
            this.lblErrorPegi.TabIndex = 51;
            this.lblErrorPegi.Text = "Error, you must select one";
            this.lblErrorPegi.Visible = false;
            // 
            // lblErrorSoftwareUsed
            // 
            this.lblErrorSoftwareUsed.AutoSize = true;
            this.lblErrorSoftwareUsed.ForeColor = System.Drawing.Color.Red;
            this.lblErrorSoftwareUsed.Location = new System.Drawing.Point(616, 248);
            this.lblErrorSoftwareUsed.Name = "lblErrorSoftwareUsed";
            this.lblErrorSoftwareUsed.Size = new System.Drawing.Size(453, 13);
            this.lblErrorSoftwareUsed.TabIndex = 50;
            this.lblErrorSoftwareUsed.Text = "Error, software used required - I don\'t know if you need an error here really but" +
    " if you do need it ";
            this.lblErrorSoftwareUsed.Visible = false;
            // 
            // lblErrorAssetType
            // 
            this.lblErrorAssetType.AutoSize = true;
            this.lblErrorAssetType.ForeColor = System.Drawing.Color.Red;
            this.lblErrorAssetType.Location = new System.Drawing.Point(616, 200);
            this.lblErrorAssetType.Name = "lblErrorAssetType";
            this.lblErrorAssetType.Size = new System.Drawing.Size(124, 13);
            this.lblErrorAssetType.TabIndex = 49;
            this.lblErrorAssetType.Text = "Error, asset type required";
            this.lblErrorAssetType.Visible = false;
            // 
            // txtAssetStatus
            // 
            this.txtAssetStatus.AccessibleName = "Asset Status";
            this.txtAssetStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssetStatus.ForeColor = System.Drawing.Color.Gray;
            this.txtAssetStatus.Location = new System.Drawing.Point(616, 320);
            this.txtAssetStatus.Name = "txtAssetStatus";
            this.txtAssetStatus.Size = new System.Drawing.Size(192, 20);
            this.txtAssetStatus.TabIndex = 5;
            this.txtAssetStatus.Tag = "";
            this.txtAssetStatus.Text = "Asset Status";
            this.txtAssetStatus.Enter += new System.EventHandler(this.txt_Enter);
            this.txtAssetStatus.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtSoftwareUsed
            // 
            this.txtSoftwareUsed.AccessibleName = "Software Used";
            this.txtSoftwareUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoftwareUsed.ForeColor = System.Drawing.Color.Gray;
            this.txtSoftwareUsed.Location = new System.Drawing.Point(616, 224);
            this.txtSoftwareUsed.Name = "txtSoftwareUsed";
            this.txtSoftwareUsed.Size = new System.Drawing.Size(192, 20);
            this.txtSoftwareUsed.TabIndex = 3;
            this.txtSoftwareUsed.Tag = "";
            this.txtSoftwareUsed.Text = "Software Used";
            this.txtSoftwareUsed.Enter += new System.EventHandler(this.txt_Enter);
            this.txtSoftwareUsed.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtAssetType
            // 
            this.txtAssetType.AccessibleName = "Asset Type";
            this.txtAssetType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssetType.ForeColor = System.Drawing.Color.Gray;
            this.txtAssetType.Location = new System.Drawing.Point(616, 176);
            this.txtAssetType.Name = "txtAssetType";
            this.txtAssetType.Size = new System.Drawing.Size(192, 20);
            this.txtAssetType.TabIndex = 2;
            this.txtAssetType.Tag = "";
            this.txtAssetType.Text = "Asset Type";
            this.txtAssetType.Enter += new System.EventHandler(this.txt_Enter);
            this.txtAssetType.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.Location = new System.Drawing.Point(480, 368);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(48, 18);
            this.lblConfirmPassword.TabIndex = 43;
            this.lblConfirmPassword.Text = "Notes";
            // 
            // lblPegi
            // 
            this.lblPegi.AutoSize = true;
            this.lblPegi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPegi.Location = new System.Drawing.Point(488, 272);
            this.lblPegi.Name = "lblPegi";
            this.lblPegi.Size = new System.Drawing.Size(43, 18);
            this.lblPegi.TabIndex = 42;
            this.lblPegi.Text = "PEGI";
            // 
            // lblAssetStatus
            // 
            this.lblAssetStatus.AutoSize = true;
            this.lblAssetStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssetStatus.Location = new System.Drawing.Point(464, 320);
            this.lblAssetStatus.Name = "lblAssetStatus";
            this.lblAssetStatus.Size = new System.Drawing.Size(91, 18);
            this.lblAssetStatus.TabIndex = 41;
            this.lblAssetStatus.Text = "Asset Status";
            // 
            // lblSoftwareUsed
            // 
            this.lblSoftwareUsed.AutoSize = true;
            this.lblSoftwareUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoftwareUsed.Location = new System.Drawing.Point(456, 224);
            this.lblSoftwareUsed.Name = "lblSoftwareUsed";
            this.lblSoftwareUsed.Size = new System.Drawing.Size(106, 18);
            this.lblSoftwareUsed.TabIndex = 40;
            this.lblSoftwareUsed.Text = "Software Used";
            // 
            // lblAssetType
            // 
            this.lblAssetType.AutoSize = true;
            this.lblAssetType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssetType.Location = new System.Drawing.Point(472, 176);
            this.lblAssetType.Name = "lblAssetType";
            this.lblAssetType.Size = new System.Drawing.Size(81, 18);
            this.lblAssetType.TabIndex = 39;
            this.lblAssetType.Text = "Asset Type";
            // 
            // cboPegi
            // 
            this.cboPegi.FormattingEnabled = true;
            this.cboPegi.Items.AddRange(new object[] {
            "3+",
            "7+",
            "12+",
            "16+",
            "18+"});
            this.cboPegi.Location = new System.Drawing.Point(616, 272);
            this.cboPegi.Name = "cboPegi";
            this.cboPegi.Size = new System.Drawing.Size(192, 21);
            this.cboPegi.TabIndex = 4;
            this.cboPegi.Text = "Select One";
            // 
            // txtNotes
            // 
            this.txtNotes.AccessibleName = "Notes";
            this.txtNotes.ForeColor = System.Drawing.Color.Gray;
            this.txtNotes.Location = new System.Drawing.Point(616, 368);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(192, 112);
            this.txtNotes.TabIndex = 6;
            this.txtNotes.Text = "Notes";
            this.txtNotes.Enter += new System.EventHandler(this.txt_Enter);
            this.txtNotes.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // btnUploadAsset
            // 
            this.btnUploadAsset.Location = new System.Drawing.Point(576, 624);
            this.btnUploadAsset.Name = "btnUploadAsset";
            this.btnUploadAsset.Size = new System.Drawing.Size(104, 24);
            this.btnUploadAsset.TabIndex = 9;
            this.btnUploadAsset.Text = "Upload Asset";
            this.btnUploadAsset.UseVisualStyleBackColor = true;
            // 
            // btnChooseAsset
            // 
            this.btnChooseAsset.Location = new System.Drawing.Point(616, 528);
            this.btnChooseAsset.Name = "btnChooseAsset";
            this.btnChooseAsset.Size = new System.Drawing.Size(96, 23);
            this.btnChooseAsset.TabIndex = 7;
            this.btnChooseAsset.Text = "Choose Asset";
            this.btnChooseAsset.UseVisualStyleBackColor = true;
            this.btnChooseAsset.Click += new System.EventHandler(this.btnChooseAsset_Click);
            // 
            // lblChooseAsset
            // 
            this.lblChooseAsset.AutoSize = true;
            this.lblChooseAsset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseAsset.Location = new System.Drawing.Point(456, 528);
            this.lblChooseAsset.Name = "lblChooseAsset";
            this.lblChooseAsset.Size = new System.Drawing.Size(102, 18);
            this.lblChooseAsset.TabIndex = 62;
            this.lblChooseAsset.Text = "Choose Asset";
            // 
            // lblErrorChooseAsset
            // 
            this.lblErrorChooseAsset.AutoSize = true;
            this.lblErrorChooseAsset.ForeColor = System.Drawing.Color.Red;
            this.lblErrorChooseAsset.Location = new System.Drawing.Point(616, 552);
            this.lblErrorChooseAsset.Name = "lblErrorChooseAsset";
            this.lblErrorChooseAsset.Size = new System.Drawing.Size(158, 13);
            this.lblErrorChooseAsset.TabIndex = 63;
            this.lblErrorChooseAsset.Text = "Error, you must choose an asset";
            this.lblErrorChooseAsset.Visible = false;
            // 
            // cboUploadType
            // 
            this.cboUploadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUploadType.Items.AddRange(new object[] {
            "Asset ",
            "Project"});
            this.cboUploadType.Location = new System.Drawing.Point(616, 80);
            this.cboUploadType.Name = "cboUploadType";
            this.cboUploadType.Size = new System.Drawing.Size(192, 21);
            this.cboUploadType.TabIndex = 0;
            this.cboUploadType.SelectedIndexChanged += new System.EventHandler(this.cboUploadType_SelectedIndexChanged);
            // 
            // lblUploadType
            // 
            this.lblUploadType.AutoSize = true;
            this.lblUploadType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUploadType.Location = new System.Drawing.Point(464, 80);
            this.lblUploadType.Name = "lblUploadType";
            this.lblUploadType.Size = new System.Drawing.Size(91, 18);
            this.lblUploadType.TabIndex = 65;
            this.lblUploadType.Text = "Upload Type";
            // 
            // UploadAssetPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUploadType);
            this.Controls.Add(this.cboUploadType);
            this.Controls.Add(this.lblErrorChooseAsset);
            this.Controls.Add(this.lblChooseAsset);
            this.Controls.Add(this.btnChooseAsset);
            this.Controls.Add(this.btnUploadAsset);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.cboPegi);
            this.Controls.Add(this.lblErrorTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.chkTermsConditions);
            this.Controls.Add(this.lblErrorAssetStatus);
            this.Controls.Add(this.lblErrorPegi);
            this.Controls.Add(this.lblErrorSoftwareUsed);
            this.Controls.Add(this.lblErrorAssetType);
            this.Controls.Add(this.txtAssetStatus);
            this.Controls.Add(this.txtSoftwareUsed);
            this.Controls.Add(this.txtAssetType);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblPegi);
            this.Controls.Add(this.lblAssetStatus);
            this.Controls.Add(this.lblSoftwareUsed);
            this.Controls.Add(this.lblAssetType);
            this.Name = "UploadAssetPageControl";
            this.Size = new System.Drawing.Size(1280, 720);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblErrorTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox chkTermsConditions;
        private System.Windows.Forms.Label lblErrorAssetStatus;
        private System.Windows.Forms.Label lblErrorPegi;
        private System.Windows.Forms.Label lblErrorSoftwareUsed;
        private System.Windows.Forms.Label lblErrorAssetType;
        private System.Windows.Forms.TextBox txtAssetStatus;
        private System.Windows.Forms.TextBox txtSoftwareUsed;
        private System.Windows.Forms.TextBox txtAssetType;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblPegi;
        private System.Windows.Forms.Label lblAssetStatus;
        private System.Windows.Forms.Label lblSoftwareUsed;
        private System.Windows.Forms.Label lblAssetType;
        private System.Windows.Forms.ComboBox cboPegi;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnUploadAsset;
        private System.Windows.Forms.Button btnChooseAsset;
        private System.Windows.Forms.Label lblChooseAsset;
        private System.Windows.Forms.Label lblErrorChooseAsset;
        private System.Windows.Forms.ComboBox cboUploadType;
        private System.Windows.Forms.Label lblUploadType;
    }
}
