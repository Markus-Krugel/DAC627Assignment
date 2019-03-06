namespace DAC627_Project
{
    partial class ViewAssetPageControl
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAssetType = new System.Windows.Forms.Label();
            this.lblPegi = new System.Windows.Forms.Label();
            this.lblSoftware = new System.Windows.Forms.Label();
            this.lblAssetStatus = new System.Windows.Forms.Label();
            this.lblCreator = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.galPictureGallery = new DAC627_Project.PictureGallery();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(80, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(448, 520);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(252, 52);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "This is a bunch of Text as a description for this thing\r\nHA \r\nHA \r\nHA\r\n";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(1024, 152);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Title";
            // 
            // lblAssetType
            // 
            this.lblAssetType.AutoSize = true;
            this.lblAssetType.Location = new System.Drawing.Point(1024, 184);
            this.lblAssetType.Name = "lblAssetType";
            this.lblAssetType.Size = new System.Drawing.Size(60, 13);
            this.lblAssetType.TabIndex = 4;
            this.lblAssetType.Text = "Asset Type";
            // 
            // lblPegi
            // 
            this.lblPegi.AutoSize = true;
            this.lblPegi.Location = new System.Drawing.Point(1024, 248);
            this.lblPegi.Name = "lblPegi";
            this.lblPegi.Size = new System.Drawing.Size(32, 13);
            this.lblPegi.TabIndex = 6;
            this.lblPegi.Text = "PEGI";
            // 
            // lblSoftware
            // 
            this.lblSoftware.AutoSize = true;
            this.lblSoftware.Location = new System.Drawing.Point(1024, 216);
            this.lblSoftware.Name = "lblSoftware";
            this.lblSoftware.Size = new System.Drawing.Size(49, 13);
            this.lblSoftware.TabIndex = 5;
            this.lblSoftware.Text = "Software";
            // 
            // lblAssetStatus
            // 
            this.lblAssetStatus.AutoSize = true;
            this.lblAssetStatus.Location = new System.Drawing.Point(1024, 280);
            this.lblAssetStatus.Name = "lblAssetStatus";
            this.lblAssetStatus.Size = new System.Drawing.Size(63, 13);
            this.lblAssetStatus.TabIndex = 7;
            this.lblAssetStatus.Text = "Asset Satus";
            // 
            // lblCreator
            // 
            this.lblCreator.AutoSize = true;
            this.lblCreator.Location = new System.Drawing.Point(1024, 312);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(41, 13);
            this.lblCreator.TabIndex = 8;
            this.lblCreator.Text = "Creator";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(1024, 416);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(88, 23);
            this.btnDownload.TabIndex = 9;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            // 
            // galPictureGallery
            // 
            this.galPictureGallery.Location = new System.Drawing.Point(372, 73);
            this.galPictureGallery.Name = "galPictureGallery";
            this.galPictureGallery.Size = new System.Drawing.Size(250, 230);
            this.galPictureGallery.TabIndex = 10;
            // 
            // ViewAssetPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.galPictureGallery);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lblCreator);
            this.Controls.Add(this.lblAssetStatus);
            this.Controls.Add(this.lblPegi);
            this.Controls.Add(this.lblSoftware);
            this.Controls.Add(this.lblAssetType);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ViewAssetPageControl";
            this.Size = new System.Drawing.Size(1280, 720);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureGallery galImageGallery;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAssetType;
        private System.Windows.Forms.Label lblPegi;
        private System.Windows.Forms.Label lblSoftware;
        private System.Windows.Forms.Label lblAssetStatus;
        private System.Windows.Forms.Label lblCreator;
        private System.Windows.Forms.Button btnDownload;
        private PictureGallery galPictureGallery;
    }
}
