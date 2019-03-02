namespace DAC627_Project
{
    partial class EditProjectPageControl
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
            this.btnConfirmChanges = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblErrorTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.btnUploadThumbnail = new System.Windows.Forms.Button();
            this.picThumbnail = new System.Windows.Forms.PictureBox();
            this.cboProjectType = new System.Windows.Forms.ComboBox();
            this.lblErrorProjectType = new System.Windows.Forms.Label();
            this.lblProjectType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirmChanges
            // 
            this.btnConfirmChanges.Location = new System.Drawing.Point(800, 536);
            this.btnConfirmChanges.Name = "btnConfirmChanges";
            this.btnConfirmChanges.Size = new System.Drawing.Size(168, 23);
            this.btnConfirmChanges.TabIndex = 96;
            this.btnConfirmChanges.Text = "Confirm Changes";
            this.btnConfirmChanges.UseVisualStyleBackColor = true;
            this.btnConfirmChanges.Click += new System.EventHandler(this.btnConfirmChanges_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.AccessibleName = "Notes";
            this.txtNotes.ForeColor = System.Drawing.Color.Gray;
            this.txtNotes.Location = new System.Drawing.Point(792, 232);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(192, 112);
            this.txtNotes.TabIndex = 84;
            this.txtNotes.Text = "Notes";
            this.txtNotes.Enter += new System.EventHandler(this.txt_Enter);
            this.txtNotes.Leave += new System.EventHandler(this.TextInput);
            // 
            // lblErrorTitle
            // 
            this.lblErrorTitle.AutoSize = true;
            this.lblErrorTitle.ForeColor = System.Drawing.Color.Red;
            this.lblErrorTitle.Location = new System.Drawing.Point(792, 159);
            this.lblErrorTitle.Name = "lblErrorTitle";
            this.lblErrorTitle.Size = new System.Drawing.Size(102, 13);
            this.lblErrorTitle.TabIndex = 95;
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
            this.txtTitle.TabIndex = 79;
            this.txtTitle.Tag = "";
            this.txtTitle.Text = "Title";
            this.txtTitle.Enter += new System.EventHandler(this.txt_Enter);
            this.txtTitle.Leave += new System.EventHandler(this.TextInput);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(664, 136);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 18);
            this.lblTitle.TabIndex = 94;
            this.lblTitle.Text = "Title";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(656, 232);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(48, 18);
            this.lblNotes.TabIndex = 89;
            this.lblNotes.Text = "Notes";
            // 
            // btnUploadThumbnail
            // 
            this.btnUploadThumbnail.Location = new System.Drawing.Point(264, 376);
            this.btnUploadThumbnail.Name = "btnUploadThumbnail";
            this.btnUploadThumbnail.Size = new System.Drawing.Size(168, 23);
            this.btnUploadThumbnail.TabIndex = 76;
            this.btnUploadThumbnail.Text = "Upload Thumbnail";
            this.btnUploadThumbnail.UseVisualStyleBackColor = true;
            // 
            // picThumbnail
            // 
            this.picThumbnail.Location = new System.Drawing.Point(232, 128);
            this.picThumbnail.Name = "picThumbnail";
            this.picThumbnail.Size = new System.Drawing.Size(225, 224);
            this.picThumbnail.TabIndex = 75;
            this.picThumbnail.TabStop = false;
            // 
            // cboProjectType
            // 
            this.cboProjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProjectType.Items.AddRange(new object[] {
            "Unity Project",
            "Unreal Project"});
            this.cboProjectType.Location = new System.Drawing.Point(792, 184);
            this.cboProjectType.Name = "cboProjectType";
            this.cboProjectType.Size = new System.Drawing.Size(192, 21);
            this.cboProjectType.TabIndex = 97;
            this.cboProjectType.Leave += new System.EventHandler(this.DropDownInput);
            // 
            // lblErrorProjectType
            // 
            this.lblErrorProjectType.AutoSize = true;
            this.lblErrorProjectType.ForeColor = System.Drawing.Color.Red;
            this.lblErrorProjectType.Location = new System.Drawing.Point(792, 208);
            this.lblErrorProjectType.Name = "lblErrorProjectType";
            this.lblErrorProjectType.Size = new System.Drawing.Size(131, 13);
            this.lblErrorProjectType.TabIndex = 99;
            this.lblErrorProjectType.Text = "Error, project type required";
            this.lblErrorProjectType.Visible = false;
            // 
            // lblProjectType
            // 
            this.lblProjectType.AutoSize = true;
            this.lblProjectType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectType.Location = new System.Drawing.Point(640, 184);
            this.lblProjectType.Name = "lblProjectType";
            this.lblProjectType.Size = new System.Drawing.Size(91, 18);
            this.lblProjectType.TabIndex = 98;
            this.lblProjectType.Text = "Project Type";
            // 
            // EditProjectPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboProjectType);
            this.Controls.Add(this.lblErrorProjectType);
            this.Controls.Add(this.lblProjectType);
            this.Controls.Add(this.btnConfirmChanges);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblErrorTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.btnUploadThumbnail);
            this.Controls.Add(this.picThumbnail);
            this.Name = "EditProjectPageControl";
            this.Size = new System.Drawing.Size(1280, 720);
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmChanges;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblErrorTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Button btnUploadThumbnail;
        private System.Windows.Forms.PictureBox picThumbnail;
        private System.Windows.Forms.ComboBox cboProjectType;
        private System.Windows.Forms.Label lblErrorProjectType;
        private System.Windows.Forms.Label lblProjectType;
    }
}
