namespace DAC627_Project.UserControls.Prefabs
{
    partial class MessageHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageHistory));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.message1 = new DAC627_Project.UserControls.Prefabs.Message();
            this.message2 = new DAC627_Project.UserControls.Prefabs.Message();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-16, -8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(784, 544);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // message1
            // 
            this.message1.Location = new System.Drawing.Point(448, 448);
            this.message1.Name = "message1";
            this.message1.Size = new System.Drawing.Size(270, 50);
            this.message1.TabIndex = 2;
            // 
            // message2
            // 
            this.message2.Location = new System.Drawing.Point(32, 376);
            this.message2.Name = "message2";
            this.message2.Size = new System.Drawing.Size(270, 50);
            this.message2.TabIndex = 3;
            // 
            // MessageHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.message2);
            this.Controls.Add(this.message1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MessageHistory";
            this.Size = new System.Drawing.Size(750, 530);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Message message1;
        private Message message2;
    }
}
