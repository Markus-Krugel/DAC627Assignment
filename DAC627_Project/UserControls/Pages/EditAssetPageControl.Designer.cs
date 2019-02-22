namespace DAC627_Project
{
    partial class EditAssetPageControl
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
            this.btnUploadThumbnail = new System.Windows.Forms.Button();
            this.btnUploadGallery = new System.Windows.Forms.Button();
            this.cboAssetType = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.cboPegi = new System.Windows.Forms.ComboBox();
            this.lblErrorTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblErrorAssetStatus = new System.Windows.Forms.Label();
            this.lblErrorPegi = new System.Windows.Forms.Label();
            this.lblErrorSoftwareUsed = new System.Windows.Forms.Label();
            this.lblErrorAssetType = new System.Windows.Forms.Label();
            this.txtAssetStatus = new System.Windows.Forms.TextBox();
            this.txtSoftwareUsed = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblPegi = new System.Windows.Forms.Label();
            this.lblAssetStatus = new System.Windows.Forms.Label();
            this.lblSoftwareUsed = new System.Windows.Forms.Label();
            this.lblAssetType = new System.Windows.Forms.Label();
            this.btnConfirmChanges = new System.Windows.Forms.Button();
            this.picGallery = new System.Windows.Forms.PictureBox();
            this.picThumbnail = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGallery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUploadThumbnail
            // 
            this.btnUploadThumbnail.Location = new System.Drawing.Point(264, 376);
            this.btnUploadThumbnail.Name = "btnUploadThumbnail";
            this.btnUploadThumbnail.Size = new System.Drawing.Size(168, 23);
            this.btnUploadThumbnail.TabIndex = 1;
            this.btnUploadThumbnail.Text = "Upload Thumbnail";
            this.btnUploadThumbnail.UseVisualStyleBackColor = true;
            // 
            // btnUploadGallery
            // 
            this.btnUploadGallery.Location = new System.Drawing.Point(264, 536);
            this.btnUploadGallery.Name = "btnUploadGallery";
            this.btnUploadGallery.Size = new System.Drawing.Size(168, 23);
            this.btnUploadGallery.TabIndex = 2;
            this.btnUploadGallery.Text = "Upload Gallery";
            this.btnUploadGallery.UseVisualStyleBackColor = true;
            // 
            // cboAssetType
            // 
            this.cboAssetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAssetType.Items.AddRange(new object[] {
            "2D Art (*.png or *.jpg)",
            "Concept Art (*.png or *.jpg)",
            "2D Animation (*.gif)",
            "3D Model (*.fbx, *.obj, *.mb, *.ma, *.max, *.c4d)",
            "3D Animation (*.fbx, *.obj, *.mb, *.ma, *.max, *.c4d)",
            "Audio (*.wav, *.mp3)"});
            this.cboAssetType.Location = new System.Drawing.Point(792, 184);
            this.cboAssetType.Name = "cboAssetType";
            this.cboAssetType.Size = new System.Drawing.Size(192, 21);
            this.cboAssetType.TabIndex = 58;
            // 
            // txtNotes
            // 
            this.txtNotes.AccessibleName = "Notes";
            this.txtNotes.ForeColor = System.Drawing.Color.Gray;
            this.txtNotes.Location = new System.Drawing.Point(792, 376);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(192, 112);
            this.txtNotes.TabIndex = 62;
            this.txtNotes.Text = "Notes";
            this.txtNotes.Enter += new System.EventHandler(this.txt_Enter);
            this.txtNotes.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // cboPegi
            // 
            this.cboPegi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPegi.FormattingEnabled = true;
            this.cboPegi.Items.AddRange(new object[] {
            "3+",
            "7+",
            "12+",
            "16+",
            "18+"});
            this.cboPegi.Location = new System.Drawing.Point(792, 280);
            this.cboPegi.Name = "cboPegi";
            this.cboPegi.Size = new System.Drawing.Size(192, 21);
            this.cboPegi.TabIndex = 60;
            // 
            // lblErrorTitle
            // 
            this.lblErrorTitle.AutoSize = true;
            this.lblErrorTitle.ForeColor = System.Drawing.Color.Red;
            this.lblErrorTitle.Location = new System.Drawing.Point(792, 159);
            this.lblErrorTitle.Name = "lblErrorTitle";
            this.lblErrorTitle.Size = new System.Drawing.Size(102, 13);
            this.lblErrorTitle.TabIndex = 73;
            this.lblErrorTitle.Text = "Error, name required";
            this.lblErrorTitle.Visible = false;
            // 
            // txtTitle
            // 
            this.txtTitle.AccessibleName = "Title";
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.Gray;
            this.txtTitle.Location = new System.Drawing.Point(792, 136);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(192, 20);
            this.txtTitle.TabIndex = 57;
            this.txtTitle.Tag = "";
            this.txtTitle.Text = "Title";
            this.txtTitle.Enter += new System.EventHandler(this.txt_Enter);
            this.txtTitle.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(664, 136);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 18);
            this.lblTitle.TabIndex = 72;
            this.lblTitle.Text = "Title";
            // 
            // lblErrorAssetStatus
            // 
            this.lblErrorAssetStatus.AutoSize = true;
            this.lblErrorAssetStatus.ForeColor = System.Drawing.Color.Red;
            this.lblErrorAssetStatus.Location = new System.Drawing.Point(792, 352);
            this.lblErrorAssetStatus.Name = "lblErrorAssetStatus";
            this.lblErrorAssetStatus.Size = new System.Drawing.Size(132, 13);
            this.lblErrorAssetStatus.TabIndex = 71;
            this.lblErrorAssetStatus.Text = "Error, asset status required";
            this.lblErrorAssetStatus.Visible = false;
            // 
            // lblErrorPegi
            // 
            this.lblErrorPegi.AutoSize = true;
            this.lblErrorPegi.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPegi.Location = new System.Drawing.Point(792, 304);
            this.lblErrorPegi.Name = "lblErrorPegi";
            this.lblErrorPegi.Size = new System.Drawing.Size(129, 13);
            this.lblErrorPegi.TabIndex = 70;
            this.lblErrorPegi.Text = "Error, you must select one";
            this.lblErrorPegi.Visible = false;
            // 
            // lblErrorSoftwareUsed
            // 
            this.lblErrorSoftwareUsed.AutoSize = true;
            this.lblErrorSoftwareUsed.ForeColor = System.Drawing.Color.Red;
            this.lblErrorSoftwareUsed.Location = new System.Drawing.Point(792, 256);
            this.lblErrorSoftwareUsed.Name = "lblErrorSoftwareUsed";
            this.lblErrorSoftwareUsed.Size = new System.Drawing.Size(453, 13);
            this.lblErrorSoftwareUsed.TabIndex = 69;
            this.lblErrorSoftwareUsed.Text = "Error, software used required - I don\'t know if you need an error here really but" +
    " if you do need it ";
            this.lblErrorSoftwareUsed.Visible = false;
            // 
            // lblErrorAssetType
            // 
            this.lblErrorAssetType.AutoSize = true;
            this.lblErrorAssetType.ForeColor = System.Drawing.Color.Red;
            this.lblErrorAssetType.Location = new System.Drawing.Point(792, 208);
            this.lblErrorAssetType.Name = "lblErrorAssetType";
            this.lblErrorAssetType.Size = new System.Drawing.Size(124, 13);
            this.lblErrorAssetType.TabIndex = 68;
            this.lblErrorAssetType.Text = "Error, asset type required";
            this.lblErrorAssetType.Visible = false;
            // 
            // txtAssetStatus
            // 
            this.txtAssetStatus.AccessibleName = "Asset Status";
            this.txtAssetStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssetStatus.ForeColor = System.Drawing.Color.Gray;
            this.txtAssetStatus.Location = new System.Drawing.Point(792, 328);
            this.txtAssetStatus.Name = "txtAssetStatus";
            this.txtAssetStatus.Size = new System.Drawing.Size(192, 20);
            this.txtAssetStatus.TabIndex = 61;
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
            this.txtSoftwareUsed.Location = new System.Drawing.Point(792, 232);
            this.txtSoftwareUsed.Name = "txtSoftwareUsed";
            this.txtSoftwareUsed.Size = new System.Drawing.Size(192, 20);
            this.txtSoftwareUsed.TabIndex = 59;
            this.txtSoftwareUsed.Tag = "";
            this.txtSoftwareUsed.Text = "Software Used";
            this.txtSoftwareUsed.Enter += new System.EventHandler(this.txt_Enter);
            this.txtSoftwareUsed.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(656, 376);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(48, 18);
            this.lblNotes.TabIndex = 67;
            this.lblNotes.Text = "Notes";
            // 
            // lblPegi
            // 
            this.lblPegi.AutoSize = true;
            this.lblPegi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPegi.Location = new System.Drawing.Point(664, 280);
            this.lblPegi.Name = "lblPegi";
            this.lblPegi.Size = new System.Drawing.Size(43, 18);
            this.lblPegi.TabIndex = 66;
            this.lblPegi.Text = "PEGI";
            // 
            // lblAssetStatus
            // 
            this.lblAssetStatus.AutoSize = true;
            this.lblAssetStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssetStatus.Location = new System.Drawing.Point(640, 328);
            this.lblAssetStatus.Name = "lblAssetStatus";
            this.lblAssetStatus.Size = new System.Drawing.Size(91, 18);
            this.lblAssetStatus.TabIndex = 65;
            this.lblAssetStatus.Text = "Asset Status";
            // 
            // lblSoftwareUsed
            // 
            this.lblSoftwareUsed.AutoSize = true;
            this.lblSoftwareUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoftwareUsed.Location = new System.Drawing.Point(632, 232);
            this.lblSoftwareUsed.Name = "lblSoftwareUsed";
            this.lblSoftwareUsed.Size = new System.Drawing.Size(106, 18);
            this.lblSoftwareUsed.TabIndex = 64;
            this.lblSoftwareUsed.Text = "Software Used";
            // 
            // lblAssetType
            // 
            this.lblAssetType.AutoSize = true;
            this.lblAssetType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssetType.Location = new System.Drawing.Point(648, 184);
            this.lblAssetType.Name = "lblAssetType";
            this.lblAssetType.Size = new System.Drawing.Size(81, 18);
            this.lblAssetType.TabIndex = 63;
            this.lblAssetType.Text = "Asset Type";
            // 
            // btnConfirmChanges
            // 
            this.btnConfirmChanges.Location = new System.Drawing.Point(800, 536);
            this.btnConfirmChanges.Name = "btnConfirmChanges";
            this.btnConfirmChanges.Size = new System.Drawing.Size(168, 23);
            this.btnConfirmChanges.TabIndex = 74;
            this.btnConfirmChanges.Text = "Confirm Changes";
            this.btnConfirmChanges.UseVisualStyleBackColor = true;
            // 
            // picGallery
            // 
            this.picGallery.Location = new System.Drawing.Point(112, 432);
            this.picGallery.Name = "picGallery";
            this.picGallery.Size = new System.Drawing.Size(464, 81);
            this.picGallery.TabIndex = 3;
            this.picGallery.TabStop = false;
            // 
            // picThumbnail
            // 
            this.picThumbnail.Location = new System.Drawing.Point(232, 128);
            this.picThumbnail.Name = "picThumbnail";
            this.picThumbnail.Size = new System.Drawing.Size(225, 225);
            this.picThumbnail.TabIndex = 0;
            this.picThumbnail.TabStop = false;
            // 
            // EditAssetPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnConfirmChanges);
            this.Controls.Add(this.cboAssetType);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.cboPegi);
            this.Controls.Add(this.lblErrorTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblErrorAssetStatus);
            this.Controls.Add(this.lblErrorPegi);
            this.Controls.Add(this.lblErrorSoftwareUsed);
            this.Controls.Add(this.lblErrorAssetType);
            this.Controls.Add(this.txtAssetStatus);
            this.Controls.Add(this.txtSoftwareUsed);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblPegi);
            this.Controls.Add(this.lblAssetStatus);
            this.Controls.Add(this.lblSoftwareUsed);
            this.Controls.Add(this.lblAssetType);
            this.Controls.Add(this.picGallery);
            this.Controls.Add(this.btnUploadGallery);
            this.Controls.Add(this.btnUploadThumbnail);
            this.Controls.Add(this.picThumbnail);
            this.Name = "EditAssetPageControl";
            this.Size = new System.Drawing.Size(1280, 720);
            ((System.ComponentModel.ISupportInitialize)(this.picGallery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picThumbnail;
        private System.Windows.Forms.Button btnUploadThumbnail;
        private System.Windows.Forms.Button btnUploadGallery;
        private System.Windows.Forms.PictureBox picGallery;
        private System.Windows.Forms.ComboBox cboAssetType;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.ComboBox cboPegi;
        private System.Windows.Forms.Label lblErrorTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblErrorAssetStatus;
        private System.Windows.Forms.Label lblErrorPegi;
        private System.Windows.Forms.Label lblErrorSoftwareUsed;
        private System.Windows.Forms.Label lblErrorAssetType;
        private System.Windows.Forms.TextBox txtAssetStatus;
        private System.Windows.Forms.TextBox txtSoftwareUsed;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblPegi;
        private System.Windows.Forms.Label lblAssetStatus;
        private System.Windows.Forms.Label lblSoftwareUsed;
        private System.Windows.Forms.Label lblAssetType;
        private System.Windows.Forms.Button btnConfirmChanges;
    }
}
