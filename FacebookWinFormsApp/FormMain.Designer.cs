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
            this.listBoxGroups = new System.Windows.Forms.ListBox();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.labelGroups = new System.Windows.Forms.Label();
            this.textBoxPost = new System.Windows.Forms.TextBox();
            this.buttonPost = new System.Windows.Forms.Button();
            this.listBoxAlbums = new System.Windows.Forms.ListBox();
            this.labelAlbums = new System.Windows.Forms.Label();
            this.pictureBoxSelectedAlbum = new System.Windows.Forms.PictureBox();
            this.labelSelectedAlbum = new System.Windows.Forms.Label();
            this.listBoxAlbumPhotos = new System.Windows.Forms.ListBox();
            this.pictureBoxSelectedPhoto = new System.Windows.Forms.PictureBox();
            this.labelSelectedPhoto = new System.Windows.Forms.Label();
            this.labelSelectedAlbumPhotos = new System.Windows.Forms.Label();
            this.listBoxUserPosts = new System.Windows.Forms.ListBox();
            this.listBoxPostComments = new System.Windows.Forms.ListBox();
            this.labelUserPosts = new System.Windows.Forms.Label();
            this.labelPostComments = new System.Windows.Forms.Label();
            this.pictureBoxGroup = new System.Windows.Forms.PictureBox();
            this.listBoxFriendsList = new System.Windows.Forms.ListBox();
            this.labelFriends = new System.Windows.Forms.Label();
            this.labelEvents = new System.Windows.Forms.Label();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.comboBoxFilterTime = new System.Windows.Forms.ComboBox();
            this.buttonEventsFilter = new System.Windows.Forms.Button();
            this.comboBoxSortByAttends = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedAlbum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(1025, 12);
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
            this.buttonLogout.Location = new System.Drawing.Point(1025, 51);
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
            this.pictureBoxProfile.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(158, 141);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxProfile.TabIndex = 53;
            this.pictureBoxProfile.TabStop = false;
            this.pictureBoxProfile.Click += new System.EventHandler(this.pictureBoxProfile_Click);
            // 
            // listBoxAboutInfo
            // 
            this.listBoxAboutInfo.FormattingEnabled = true;
            this.listBoxAboutInfo.ItemHeight = 20;
            this.listBoxAboutInfo.Location = new System.Drawing.Point(12, 199);
            this.listBoxAboutInfo.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
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
            this.listBoxPages.Location = new System.Drawing.Point(12, 325);
            this.listBoxPages.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.listBoxPages.Name = "listBoxPages";
            this.listBoxPages.Size = new System.Drawing.Size(302, 164);
            this.listBoxPages.TabIndex = 57;
            this.listBoxPages.SelectedIndexChanged += new System.EventHandler(this.listBoxPages_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 58;
            this.label1.Text = "Liked pages";
            // 
            // buttonAstrologyHoroscopePost
            // 
            this.buttonAstrologyHoroscopePost.Location = new System.Drawing.Point(1072, 108);
            this.buttonAstrologyHoroscopePost.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.buttonAstrologyHoroscopePost.Name = "buttonAstrologyHoroscopePost";
            this.buttonAstrologyHoroscopePost.Size = new System.Drawing.Size(141, 111);
            this.buttonAstrologyHoroscopePost.TabIndex = 59;
            this.buttonAstrologyHoroscopePost.Text = "Post Daily Compatibility Astrology Horoscope";
            this.buttonAstrologyHoroscopePost.UseVisualStyleBackColor = true;
            this.buttonAstrologyHoroscopePost.Click += new System.EventHandler(this.buttonAstrologyHoroscopePost_Click);
            // 
            // listBoxGroups
            // 
            this.listBoxGroups.FormattingEnabled = true;
            this.listBoxGroups.ItemHeight = 20;
            this.listBoxGroups.Location = new System.Drawing.Point(343, 325);
            this.listBoxGroups.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.listBoxGroups.Name = "listBoxGroups";
            this.listBoxGroups.Size = new System.Drawing.Size(291, 164);
            this.listBoxGroups.TabIndex = 60;
            this.listBoxGroups.SelectedIndexChanged += new System.EventHandler(this.listBoxGroups_SelectedGroupIndexChanged);
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.Location = new System.Drawing.Point(280, 12);
            this.pictureBoxCover.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(343, 141);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCover.TabIndex = 62;
            this.pictureBoxCover.TabStop = false;
            this.pictureBoxCover.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelGroups
            // 
            this.labelGroups.AutoSize = true;
            this.labelGroups.Location = new System.Drawing.Point(343, 299);
            this.labelGroups.Name = "labelGroups";
            this.labelGroups.Size = new System.Drawing.Size(62, 20);
            this.labelGroups.TabIndex = 63;
            this.labelGroups.Text = "Groups";
            // 
            // textBoxPost
            // 
            this.textBoxPost.Location = new System.Drawing.Point(12, 915);
            this.textBoxPost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPost.Name = "textBoxPost";
            this.textBoxPost.Size = new System.Drawing.Size(392, 26);
            this.textBoxPost.TabIndex = 64;
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(12, 956);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(75, 31);
            this.buttonPost.TabIndex = 65;
            this.buttonPost.Text = "Post";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 20;
            this.listBoxAlbums.Location = new System.Drawing.Point(665, 325);
            this.listBoxAlbums.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(280, 164);
            this.listBoxAlbums.TabIndex = 64;
            this.listBoxAlbums.SelectedIndexChanged += new System.EventHandler(this.listBoxAlbums_SelectedAlbumIndexChanged);
            // 
            // labelAlbums
            // 
            this.labelAlbums.AutoSize = true;
            this.labelAlbums.Location = new System.Drawing.Point(667, 299);
            this.labelAlbums.Name = "labelAlbums";
            this.labelAlbums.Size = new System.Drawing.Size(62, 20);
            this.labelAlbums.TabIndex = 65;
            this.labelAlbums.Text = "Albums";
            this.labelAlbums.Click += new System.EventHandler(this.labelAlbums_Click);
            // 
            // pictureBoxSelectedAlbum
            // 
            this.pictureBoxSelectedAlbum.Location = new System.Drawing.Point(958, 379);
            this.pictureBoxSelectedAlbum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxSelectedAlbum.Name = "pictureBoxSelectedAlbum";
            this.pictureBoxSelectedAlbum.Size = new System.Drawing.Size(118, 112);
            this.pictureBoxSelectedAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSelectedAlbum.TabIndex = 66;
            this.pictureBoxSelectedAlbum.TabStop = false;
            // 
            // labelSelectedAlbum
            // 
            this.labelSelectedAlbum.AutoSize = true;
            this.labelSelectedAlbum.Location = new System.Drawing.Point(954, 355);
            this.labelSelectedAlbum.Name = "labelSelectedAlbum";
            this.labelSelectedAlbum.Size = new System.Drawing.Size(121, 20);
            this.labelSelectedAlbum.TabIndex = 67;
            this.labelSelectedAlbum.Text = "Selected Album";
            // 
            // listBoxAlbumPhotos
            // 
            this.listBoxAlbumPhotos.FormattingEnabled = true;
            this.listBoxAlbumPhotos.ItemHeight = 20;
            this.listBoxAlbumPhotos.Location = new System.Drawing.Point(12, 536);
            this.listBoxAlbumPhotos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxAlbumPhotos.Name = "listBoxAlbumPhotos";
            this.listBoxAlbumPhotos.Size = new System.Drawing.Size(302, 144);
            this.listBoxAlbumPhotos.TabIndex = 68;
            this.listBoxAlbumPhotos.SelectedIndexChanged += new System.EventHandler(this.listBoxAlbumPhotos_SelectedPhotoChanged);
            // 
            // pictureBoxSelectedPhoto
            // 
            this.pictureBoxSelectedPhoto.Location = new System.Drawing.Point(339, 536);
            this.pictureBoxSelectedPhoto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxSelectedPhoto.Name = "pictureBoxSelectedPhoto";
            this.pictureBoxSelectedPhoto.Size = new System.Drawing.Size(198, 146);
            this.pictureBoxSelectedPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSelectedPhoto.TabIndex = 69;
            this.pictureBoxSelectedPhoto.TabStop = false;
            // 
            // labelSelectedPhoto
            // 
            this.labelSelectedPhoto.AutoSize = true;
            this.labelSelectedPhoto.Location = new System.Drawing.Point(338, 509);
            this.labelSelectedPhoto.Name = "labelSelectedPhoto";
            this.labelSelectedPhoto.Size = new System.Drawing.Size(118, 20);
            this.labelSelectedPhoto.TabIndex = 70;
            this.labelSelectedPhoto.Text = "Selected Photo";
            // 
            // labelSelectedAlbumPhotos
            // 
            this.labelSelectedAlbumPhotos.AutoSize = true;
            this.labelSelectedAlbumPhotos.Location = new System.Drawing.Point(14, 509);
            this.labelSelectedAlbumPhotos.Name = "labelSelectedAlbumPhotos";
            this.labelSelectedAlbumPhotos.Size = new System.Drawing.Size(108, 20);
            this.labelSelectedAlbumPhotos.TabIndex = 71;
            this.labelSelectedAlbumPhotos.Text = "Album Photos";
            // 
            // listBoxUserPosts
            // 
            this.listBoxUserPosts.FormattingEnabled = true;
            this.listBoxUserPosts.ItemHeight = 20;
            this.listBoxUserPosts.Location = new System.Drawing.Point(564, 540);
            this.listBoxUserPosts.Name = "listBoxUserPosts";
            this.listBoxUserPosts.Size = new System.Drawing.Size(295, 104);
            this.listBoxUserPosts.TabIndex = 72;
            this.listBoxUserPosts.SelectedIndexChanged += new System.EventHandler(this.listBoxUserPosts_SelectedPostIndexChanged);
            // 
            // listBoxPostComments
            // 
            this.listBoxPostComments.FormattingEnabled = true;
            this.listBoxPostComments.ItemHeight = 20;
            this.listBoxPostComments.Location = new System.Drawing.Point(892, 540);
            this.listBoxPostComments.Name = "listBoxPostComments";
            this.listBoxPostComments.Size = new System.Drawing.Size(141, 104);
            this.listBoxPostComments.TabIndex = 73;
            // 
            // labelUserPosts
            // 
            this.labelUserPosts.AutoSize = true;
            this.labelUserPosts.Location = new System.Drawing.Point(560, 514);
            this.labelUserPosts.Name = "labelUserPosts";
            this.labelUserPosts.Size = new System.Drawing.Size(98, 20);
            this.labelUserPosts.TabIndex = 74;
            this.labelUserPosts.Text = "User\'s Posts";
            // 
            // labelPostComments
            // 
            this.labelPostComments.AutoSize = true;
            this.labelPostComments.Location = new System.Drawing.Point(878, 509);
            this.labelPostComments.Name = "labelPostComments";
            this.labelPostComments.Size = new System.Drawing.Size(122, 20);
            this.labelPostComments.TabIndex = 75;
            this.labelPostComments.Text = "Post Comments";
            // 
            // pictureBoxGroup
            // 
            this.pictureBoxGroup.Location = new System.Drawing.Point(555, 410);
            this.pictureBoxGroup.Name = "pictureBoxGroup";
            this.pictureBoxGroup.Size = new System.Drawing.Size(68, 60);
            this.pictureBoxGroup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGroup.TabIndex = 76;
            this.pictureBoxGroup.TabStop = false;
            // 
            // listBoxFriendsList
            // 
            this.listBoxFriendsList.FormattingEnabled = true;
            this.listBoxFriendsList.ItemHeight = 20;
            this.listBoxFriendsList.Location = new System.Drawing.Point(892, 678);
            this.listBoxFriendsList.Name = "listBoxFriendsList";
            this.listBoxFriendsList.Size = new System.Drawing.Size(143, 104);
            this.listBoxFriendsList.TabIndex = 77;
            // 
            // labelFriends
            // 
            this.labelFriends.AutoSize = true;
            this.labelFriends.Location = new System.Drawing.Point(1003, 410);
            this.labelFriends.Name = "labelFriends";
            this.labelFriends.Size = new System.Drawing.Size(62, 20);
            this.labelFriends.TabIndex = 78;
            this.labelFriends.Text = "Friends";
            // 
            // labelEvents
            // 
            this.labelEvents.AutoSize = true;
            this.labelEvents.Location = new System.Drawing.Point(463, 805);
            this.labelEvents.Name = "labelEvents";
            this.labelEvents.Size = new System.Drawing.Size(62, 20);
            this.labelEvents.TabIndex = 74;
            this.labelEvents.Text = "Events:";
            this.labelEvents.Click += new System.EventHandler(this.labelEvents_Click);
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.ItemHeight = 20;
            this.listBoxEvents.Location = new System.Drawing.Point(467, 843);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(277, 144);
            this.listBoxEvents.TabIndex = 75;
            this.listBoxEvents.SelectedIndexChanged += new System.EventHandler(this.listBoxEvents_SelectedIndexChanged);
            // 
            // comboBoxFilterTime
            // 
            this.comboBoxFilterTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilterTime.FormattingEnabled = true;
            this.comboBoxFilterTime.Items.AddRange(new object[] {
            "-select-",
            "Today",
            "In the next 7 days",
            "This month"});
            this.comboBoxFilterTime.Location = new System.Drawing.Point(760, 888);
            this.comboBoxFilterTime.Name = "comboBoxFilterTime";
            this.comboBoxFilterTime.Size = new System.Drawing.Size(149, 28);
            this.comboBoxFilterTime.TabIndex = 76;
            this.comboBoxFilterTime.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilterTime_SelectedIndexChanged);
            // 
            // buttonEventsFilter
            // 
            this.buttonEventsFilter.Location = new System.Drawing.Point(760, 843);
            this.buttonEventsFilter.Name = "buttonEventsFilter";
            this.buttonEventsFilter.Size = new System.Drawing.Size(89, 29);
            this.buttonEventsFilter.TabIndex = 77;
            this.buttonEventsFilter.Text = "Filter";
            this.buttonEventsFilter.UseVisualStyleBackColor = true;
            this.buttonEventsFilter.Click += new System.EventHandler(this.buttonEventsFilter_Click);
            // 
            // comboBoxSortByAttends
            // 
            this.comboBoxSortByAttends.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSortByAttends.FormattingEnabled = true;
            this.comboBoxSortByAttends.Items.AddRange(new object[] {
            "-select-",
            "Attending",
            "Interested",
            "Declined",
            "Maybe"});
            this.comboBoxSortByAttends.Location = new System.Drawing.Point(760, 922);
            this.comboBoxSortByAttends.Name = "comboBoxSortByAttends";
            this.comboBoxSortByAttends.Size = new System.Drawing.Size(149, 28);
            this.comboBoxSortByAttends.TabIndex = 78;
            this.comboBoxSortByAttends.SelectedIndexChanged += new System.EventHandler(this.comboBoxSortByAttends_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 1021);
            this.Controls.Add(this.labelFriends);
            this.Controls.Add(this.listBoxFriendsList);
            this.Controls.Add(this.pictureBoxGroup);
            this.Controls.Add(this.labelPostComments);
            this.Controls.Add(this.labelUserPosts);
            this.Controls.Add(this.listBoxPostComments);
            this.Controls.Add(this.listBoxUserPosts);
            this.Controls.Add(this.comboBoxSortByAttends);
            this.Controls.Add(this.buttonEventsFilter);
            this.Controls.Add(this.comboBoxFilterTime);
            this.Controls.Add(this.listBoxEvents);
            this.Controls.Add(this.labelEvents);
            this.Controls.Add(this.labelSelectedAlbumPhotos);
            this.Controls.Add(this.labelSelectedPhoto);
            this.Controls.Add(this.pictureBoxSelectedPhoto);
            this.Controls.Add(this.listBoxAlbumPhotos);
            this.Controls.Add(this.buttonPost);
            this.Controls.Add(this.textBoxPost);
            this.Controls.Add(this.labelSelectedAlbum);
            this.Controls.Add(this.pictureBoxSelectedAlbum);
            this.Controls.Add(this.labelAlbums);
            this.Controls.Add(this.listBoxAlbums);
            this.Controls.Add(this.labelGroups);
            this.Controls.Add(this.pictureBoxCover);
            this.Controls.Add(this.listBoxGroups);
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
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedAlbum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroup)).EndInit();
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
        private System.Windows.Forms.ListBox listBoxGroups;
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.Label labelGroups;
        private System.Windows.Forms.TextBox textBoxPost;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.ListBox listBoxAlbums;
        private System.Windows.Forms.Label labelAlbums;
        private System.Windows.Forms.PictureBox pictureBoxSelectedAlbum;
        private System.Windows.Forms.Label labelSelectedAlbum;
        private System.Windows.Forms.ListBox listBoxAlbumPhotos;
        private System.Windows.Forms.PictureBox pictureBoxSelectedPhoto;
        private System.Windows.Forms.Label labelSelectedPhoto;
        private System.Windows.Forms.Label labelSelectedAlbumPhotos;
        private System.Windows.Forms.ListBox listBoxUserPosts;
        private System.Windows.Forms.ListBox listBoxPostComments;
        private System.Windows.Forms.Label labelUserPosts;
        private System.Windows.Forms.Label labelPostComments;
        private System.Windows.Forms.PictureBox pictureBoxGroup;
        private System.Windows.Forms.ListBox listBoxFriendsList;
        private System.Windows.Forms.Label labelFriends;
        private System.Windows.Forms.Label labelEvents;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.ComboBox comboBoxFilterTime;
        private System.Windows.Forms.Button buttonEventsFilter;
        private System.Windows.Forms.ComboBox comboBoxSortByAttends;
    }
}

