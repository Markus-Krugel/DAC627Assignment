namespace DAC627_Project
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.homePageControl1 = new DAC627_Project.HomePageControl();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(16, 16);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(256, 40);
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // homePageControl1
            // 
            this.homePageControl1.Location = new System.Drawing.Point(0, 32);
            this.homePageControl1.Name = "homePageControl1";
            this.homePageControl1.Size = new System.Drawing.Size(1264, 681);
            this.homePageControl1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.homePageControl1);
            this.Controls.Add(this.picLogo);
            this.Name = "MainForm";
            this.Text = "Prototype";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private HomePageControl homePageControl1;
    }
}

