namespace DAC627_Project
{
    partial class AssetButton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssetButton));
            this.picAsset = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAsset)).BeginInit();
            this.SuspendLayout();
            // 
            // picAsset
            // 
            this.picAsset.Image = ((System.Drawing.Image)(resources.GetObject("picAsset.Image")));
            this.picAsset.InitialImage = null;
            this.picAsset.Location = new System.Drawing.Point(0, 0);
            this.picAsset.Name = "picAsset";
            this.picAsset.Size = new System.Drawing.Size(200, 200);
            this.picAsset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAsset.TabIndex = 0;
            this.picAsset.TabStop = false;
            this.picAsset.Click += new System.EventHandler(this.picAsset_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblName.Location = new System.Drawing.Point(0, 200);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(89, 18);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Asset Name";
            // 
            // AssetButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picAsset);
            this.Name = "AssetButton";
            this.Size = new System.Drawing.Size(200, 220);
            ((System.ComponentModel.ISupportInitialize)(this.picAsset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picAsset;
        private System.Windows.Forms.Label lblName;
    }
}
