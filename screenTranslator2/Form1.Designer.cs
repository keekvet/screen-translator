namespace screenTranslator2
{
    partial class form
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
            this.components = new System.ComponentModel.Container();
            this.ipTB = new System.Windows.Forms.TextBox();
            this.clientCheck = new System.Windows.Forms.CheckBox();
            this.conectBtn = new System.Windows.Forms.Button();
            this.disconectBtn = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.screenShotTimer = new System.Windows.Forms.Timer(this.components);
            this.statLabel = new System.Windows.Forms.Label();
            this.portTb = new System.Windows.Forms.TextBox();
            this.timerGet = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ipTB
            // 
            this.ipTB.Location = new System.Drawing.Point(13, 13);
            this.ipTB.Name = "ipTB";
            this.ipTB.Size = new System.Drawing.Size(100, 20);
            this.ipTB.TabIndex = 0;
            this.ipTB.Text = "235.5.5.11";
            this.ipTB.WordWrap = false;
            // 
            // clientCheck
            // 
            this.clientCheck.AutoSize = true;
            this.clientCheck.Checked = true;
            this.clientCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clientCheck.Location = new System.Drawing.Point(120, 15);
            this.clientCheck.Name = "clientCheck";
            this.clientCheck.Size = new System.Drawing.Size(51, 17);
            this.clientCheck.TabIndex = 1;
            this.clientCheck.Text = "client";
            this.clientCheck.UseVisualStyleBackColor = true;
            // 
            // conectBtn
            // 
            this.conectBtn.Location = new System.Drawing.Point(177, 15);
            this.conectBtn.Name = "conectBtn";
            this.conectBtn.Size = new System.Drawing.Size(75, 23);
            this.conectBtn.TabIndex = 2;
            this.conectBtn.Text = "conect";
            this.conectBtn.UseVisualStyleBackColor = true;
            this.conectBtn.Click += new System.EventHandler(this.ConectBtn_Click);
            // 
            // disconectBtn
            // 
            this.disconectBtn.Location = new System.Drawing.Point(258, 15);
            this.disconectBtn.Name = "disconectBtn";
            this.disconectBtn.Size = new System.Drawing.Size(75, 23);
            this.disconectBtn.TabIndex = 3;
            this.disconectBtn.Text = "disconect";
            this.disconectBtn.UseVisualStyleBackColor = true;
            this.disconectBtn.Click += new System.EventHandler(this.DisconectBtn_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(13, 40);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(775, 398);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // screenShotTimer
            // 
            this.screenShotTimer.Interval = 200;
            this.screenShotTimer.Tick += new System.EventHandler(this.ScreenShotTimer_Tick);
            // 
            // statLabel
            // 
            this.statLabel.AutoSize = true;
            this.statLabel.Location = new System.Drawing.Point(605, 19);
            this.statLabel.Name = "statLabel";
            this.statLabel.Size = new System.Drawing.Size(35, 13);
            this.statLabel.TabIndex = 5;
            this.statLabel.Text = "status";
            // 
            // portTb
            // 
            this.portTb.Location = new System.Drawing.Point(340, 14);
            this.portTb.Name = "portTb";
            this.portTb.Size = new System.Drawing.Size(100, 20);
            this.portTb.TabIndex = 6;
            this.portTb.Text = "34567";
            // 
            // timerGet
            // 
            this.timerGet.Interval = 50;
            this.timerGet.Tick += new System.EventHandler(this.TimerGet_Tick);
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.portTb);
            this.Controls.Add(this.statLabel);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.disconectBtn);
            this.Controls.Add(this.conectBtn);
            this.Controls.Add(this.clientCheck);
            this.Controls.Add(this.ipTB);
            this.Name = "form";
            this.Text = "screenTranslator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipTB;
        private System.Windows.Forms.CheckBox clientCheck;
        private System.Windows.Forms.Button conectBtn;
        private System.Windows.Forms.Button disconectBtn;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Timer screenShotTimer;
        private System.Windows.Forms.Label statLabel;
        private System.Windows.Forms.TextBox portTb;
        private System.Windows.Forms.Timer timerGet;
    }
}

