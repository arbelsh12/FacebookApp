namespace BasicFacebookFeatures
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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.listBoxAboutInfo = new System.Windows.Forms.ListBox();
            this.labelAbout = new System.Windows.Forms.Label();
            this.listBoxPages = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAstrologyHoroscopePost = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(1024, 12);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(226, 35);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(1024, 51);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(226, 35);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(86, 12);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(157, 142);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxProfile.TabIndex = 53;
            this.pictureBoxProfile.TabStop = false;
            this.pictureBoxProfile.Click += new System.EventHandler(this.pictureBoxProfile_Click);
            // 
            // listBoxAboutInfo
            // 
            this.listBoxAboutInfo.FormattingEnabled = true;
            this.listBoxAboutInfo.ItemHeight = 20;
            this.listBoxAboutInfo.Location = new System.Drawing.Point(12, 198);
            this.listBoxAboutInfo.Name = "listBoxAboutInfo";
            this.listBoxAboutInfo.Size = new System.Drawing.Size(302, 84);
            this.listBoxAboutInfo.TabIndex = 55;
            this.listBoxAboutInfo.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // labelAbout
            // 
            this.labelAbout.AutoSize = true;
            this.labelAbout.Location = new System.Drawing.Point(12, 175);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(56, 20);
            this.labelAbout.TabIndex = 56;
            this.labelAbout.Text = "About:";
            this.labelAbout.Click += new System.EventHandler(this.labelAbout_Click);
            // 
            // listBoxPages
            // 
            this.listBoxPages.FormattingEnabled = true;
            this.listBoxPages.ItemHeight = 20;
            this.listBoxPages.Location = new System.Drawing.Point(12, 324);
            this.listBoxPages.Name = "listBoxPages";
            this.listBoxPages.Size = new System.Drawing.Size(302, 164);
            this.listBoxPages.TabIndex = 57;
            this.listBoxPages.SelectedIndexChanged += new System.EventHandler(this.listBoxPages_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 58;
            this.label1.Text = "Liked pages";
            // 
            // buttonAstrologyHoroscopePost
            // 
            this.buttonAstrologyHoroscopePost.Location = new System.Drawing.Point(1073, 107);
            this.buttonAstrologyHoroscopePost.Name = "buttonAstrologyHoroscopePost";
            this.buttonAstrologyHoroscopePost.Size = new System.Drawing.Size(125, 60);
            this.buttonAstrologyHoroscopePost.TabIndex = 59;
            this.buttonAstrologyHoroscopePost.Text = "Post Astrology Horoscope";
            this.buttonAstrologyHoroscopePost.UseVisualStyleBackColor = true;
            this.buttonAstrologyHoroscopePost.Click += new System.EventHandler(this.buttonAstrologyHoroscopePost_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 1011);
            this.Controls.Add(this.buttonAstrologyHoroscopePost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxPages);
            this.Controls.Add(this.labelAbout);
            this.Controls.Add(this.listBoxAboutInfo);
            this.Controls.Add(this.pictureBoxProfile);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonLogin);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.ListBox listBoxAboutInfo;
        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.ListBox listBoxPages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAstrologyHoroscopePost;
    }
}

