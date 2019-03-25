namespace DAC627_Project
{
    partial class FormMain
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
            this.picHomeButton = new System.Windows.Forms.PictureBox();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.picProfile = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // picHomeButton
            // 
            this.picHomeButton.Image = global::DAC627_Project.Properties.Resources.thEGE72UK4;
            this.picHomeButton.Location = new System.Drawing.Point(16, 16);
            this.picHomeButton.Name = "picHomeButton";
            this.picHomeButton.Size = new System.Drawing.Size(256, 48);
            this.picHomeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHomeButton.TabIndex = 0;
            this.picHomeButton.TabStop = false;
            this.picHomeButton.Click += new System.EventHandler(this.picHomeButton_Click);
            this.picHomeButton.MouseEnter += new System.EventHandler(this.picHomeButton_MouseEnter);
            this.picHomeButton.MouseLeave += new System.EventHandler(this.picHomeButton_MouseLeave);
            // 
            // lblProfileName
            // 
            this.lblProfileName.AutoSize = true;
            this.lblProfileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfileName.Location = new System.Drawing.Point(1040, 32);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(144, 18);
            this.lblProfileName.TabIndex = 3;
            this.lblProfileName.Text = "Default Profile Name";
            this.lblProfileName.Visible = false;
            // 
            // picProfile
            // 
            this.picProfile.Image = global::DAC627_Project.Properties.Resources.thEGE72UK4;
            this.picProfile.Location = new System.Drawing.Point(1200, 16);
            this.picProfile.Name = "picProfile";
            this.picProfile.Size = new System.Drawing.Size(50, 50);
            this.picProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProfile.TabIndex = 2;
            this.picProfile.TabStop = false;
            this.picProfile.Visible = false;
            this.picProfile.Click += new System.EventHandler(this.picProfile_Click);
            this.picProfile.MouseEnter += new System.EventHandler(this.picHomeButton_MouseEnter);
            this.picProfile.MouseLeave += new System.EventHandler(this.picHomeButton_MouseLeave);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1276, 720);
            this.Controls.Add(this.lblProfileName);
            this.Controls.Add(this.picProfile);
            this.Controls.Add(this.picHomeButton);
            this.Name = "FormMain";
            this.Text = "Prototype";
            ((System.ComponentModel.ISupportInitialize)(this.picHomeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picHomeButton;
        private System.Windows.Forms.Label lblProfileName;
        private System.Windows.Forms.PictureBox picProfile;
    }
}

