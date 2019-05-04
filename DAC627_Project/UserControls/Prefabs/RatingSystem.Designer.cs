namespace DAC627_Project.UserControls.Prefabs
{
    partial class RatingSystem
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
            this.picStar5 = new System.Windows.Forms.PictureBox();
            this.picStar4 = new System.Windows.Forms.PictureBox();
            this.picStar3 = new System.Windows.Forms.PictureBox();
            this.picStar2 = new System.Windows.Forms.PictureBox();
            this.picStar1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picStar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStar1)).BeginInit();
            this.SuspendLayout();
            // 
            // picStar5
            // 
            this.picStar5.Image = global::DAC627_Project.Properties.Resources.StarEmpty;
            this.picStar5.Location = new System.Drawing.Point(192, 0);
            this.picStar5.Name = "picStar5";
            this.picStar5.Size = new System.Drawing.Size(40, 40);
            this.picStar5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStar5.TabIndex = 31;
            this.picStar5.TabStop = false;
            this.picStar5.Click += new System.EventHandler(this.picStar5_Click);
            // 
            // picStar4
            // 
            this.picStar4.Image = global::DAC627_Project.Properties.Resources.StarEmpty;
            this.picStar4.Location = new System.Drawing.Point(144, 0);
            this.picStar4.Name = "picStar4";
            this.picStar4.Size = new System.Drawing.Size(40, 40);
            this.picStar4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStar4.TabIndex = 30;
            this.picStar4.TabStop = false;
            this.picStar4.Click += new System.EventHandler(this.picStar4_Click);
            // 
            // picStar3
            // 
            this.picStar3.Image = global::DAC627_Project.Properties.Resources.StarEmpty;
            this.picStar3.Location = new System.Drawing.Point(96, 0);
            this.picStar3.Name = "picStar3";
            this.picStar3.Size = new System.Drawing.Size(40, 40);
            this.picStar3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStar3.TabIndex = 29;
            this.picStar3.TabStop = false;
            this.picStar3.Click += new System.EventHandler(this.picStar3_Click);
            // 
            // picStar2
            // 
            this.picStar2.Image = global::DAC627_Project.Properties.Resources.StarEmpty;
            this.picStar2.Location = new System.Drawing.Point(48, 0);
            this.picStar2.Name = "picStar2";
            this.picStar2.Size = new System.Drawing.Size(40, 40);
            this.picStar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStar2.TabIndex = 28;
            this.picStar2.TabStop = false;
            this.picStar2.Click += new System.EventHandler(this.picStar2_Click);
            // 
            // picStar1
            // 
            this.picStar1.Image = global::DAC627_Project.Properties.Resources.StarFull;
            this.picStar1.Location = new System.Drawing.Point(0, 0);
            this.picStar1.Name = "picStar1";
            this.picStar1.Size = new System.Drawing.Size(40, 40);
            this.picStar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStar1.TabIndex = 23;
            this.picStar1.TabStop = false;
            this.picStar1.Click += new System.EventHandler(this.PicStar1_Click);
            // 
            // RatingSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picStar5);
            this.Controls.Add(this.picStar4);
            this.Controls.Add(this.picStar3);
            this.Controls.Add(this.picStar2);
            this.Controls.Add(this.picStar1);
            this.Name = "RatingSystem";
            this.Size = new System.Drawing.Size(232, 40);
            ((System.ComponentModel.ISupportInitialize)(this.picStar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picStar1;
        private System.Windows.Forms.PictureBox picStar2;
        private System.Windows.Forms.PictureBox picStar3;
        private System.Windows.Forms.PictureBox picStar4;
        private System.Windows.Forms.PictureBox picStar5;
    }
}
