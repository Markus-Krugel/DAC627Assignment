namespace DAC627_Project
{
    partial class MessagingPageControl
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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.messageAccountButton2 = new DAC627_Project.UserControls.Prefabs.MessageAccountButton();
            this.messageAccountButton1 = new DAC627_Project.UserControls.Prefabs.MessageAccountButton();
            this.messageHistory1 = new DAC627_Project.UserControls.Prefabs.MessageHistory();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(368, 640);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(624, 32);
            this.txtMessage.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(1016, 640);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(104, 32);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send Message";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // messageAccountButton2
            // 
            this.messageAccountButton2.Location = new System.Drawing.Point(64, 160);
            this.messageAccountButton2.Name = "messageAccountButton2";
            this.messageAccountButton2.Size = new System.Drawing.Size(225, 50);
            this.messageAccountButton2.TabIndex = 5;
            // 
            // messageAccountButton1
            // 
            this.messageAccountButton1.Location = new System.Drawing.Point(64, 96);
            this.messageAccountButton1.Name = "messageAccountButton1";
            this.messageAccountButton1.Size = new System.Drawing.Size(225, 50);
            this.messageAccountButton1.TabIndex = 4;
            // 
            // messageHistory1
            // 
            this.messageHistory1.Location = new System.Drawing.Point(368, 88);
            this.messageHistory1.Name = "messageHistory1";
            this.messageHistory1.Size = new System.Drawing.Size(750, 530);
            this.messageHistory1.TabIndex = 6;
            // 
            // MessagingPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.messageHistory1);
            this.Controls.Add(this.messageAccountButton2);
            this.Controls.Add(this.messageAccountButton1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Name = "MessagingPageControl";
            this.Size = new System.Drawing.Size(1280, 720);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private UserControls.Prefabs.MessageAccountButton messageAccountButton1;
        private UserControls.Prefabs.MessageAccountButton messageAccountButton2;
        private UserControls.Prefabs.MessageHistory messageHistory1;
    }
}
