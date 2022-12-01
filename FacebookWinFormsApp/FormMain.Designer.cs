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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageFeed = new System.Windows.Forms.TabPage();
            this.tabPageAlbums = new System.Windows.Forms.TabPage();
            this.tabPageLikedPages = new System.Windows.Forms.TabPage();
            this.tabPageGroups = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelPages = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelGroups = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelAlbumPhotos = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedAlbum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroup)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageFeed.SuspendLayout();
            this.tabPageAlbums.SuspendLayout();
            this.tabPageLikedPages.SuspendLayout();
            this.tabPageGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(911, 41);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(201, 28);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(46, 24);
            this.pictureBoxProfile.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(140, 113);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxProfile.TabIndex = 53;
            this.pictureBoxProfile.TabStop = false;
            this.pictureBoxProfile.Click += new System.EventHandler(this.pictureBoxProfile_Click);
            // 
            // listBoxAboutInfo
            // 
            this.listBoxAboutInfo.FormattingEnabled = true;
            this.listBoxAboutInfo.ItemHeight = 16;
            this.listBoxAboutInfo.Location = new System.Drawing.Point(11, 33);
            this.listBoxAboutInfo.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.listBoxAboutInfo.Name = "listBoxAboutInfo";
            this.listBoxAboutInfo.Size = new System.Drawing.Size(269, 68);
            this.listBoxAboutInfo.TabIndex = 55;
            this.listBoxAboutInfo.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // labelAbout
            // 
            this.labelAbout.AutoSize = true;
            this.labelAbout.Location = new System.Drawing.Point(11, 14);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(45, 16);
            this.labelAbout.TabIndex = 56;
            this.labelAbout.Text = "About:";
            this.labelAbout.Click += new System.EventHandler(this.labelAbout_Click);
            // 
            // listBoxPages
            // 
            this.listBoxPages.FormattingEnabled = true;
            this.listBoxPages.ItemHeight = 16;
            this.listBoxPages.Location = new System.Drawing.Point(74, 658);
            this.listBoxPages.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.listBoxPages.Name = "listBoxPages";
            this.listBoxPages.Size = new System.Drawing.Size(269, 132);
            this.listBoxPages.TabIndex = 57;
            this.listBoxPages.SelectedIndexChanged += new System.EventHandler(this.listBoxPages_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 637);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 58;
            this.label1.Text = "Liked pages";
            // 
            // buttonAstrologyHoroscopePost
            // 
            this.buttonAstrologyHoroscopePost.Location = new System.Drawing.Point(473, 141);
            this.buttonAstrologyHoroscopePost.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.buttonAstrologyHoroscopePost.Name = "buttonAstrologyHoroscopePost";
            this.buttonAstrologyHoroscopePost.Size = new System.Drawing.Size(125, 89);
            this.buttonAstrologyHoroscopePost.TabIndex = 59;
            this.buttonAstrologyHoroscopePost.Text = "Post Daily Compatibility Astrology Horoscope";
            this.buttonAstrologyHoroscopePost.UseVisualStyleBackColor = true;
            this.buttonAstrologyHoroscopePost.Click += new System.EventHandler(this.buttonAstrologyHoroscopePost_Click);
            // 
            // listBoxGroups
            // 
            this.listBoxGroups.FormattingEnabled = true;
            this.listBoxGroups.ItemHeight = 16;
            this.listBoxGroups.Location = new System.Drawing.Point(77, 824);
            this.listBoxGroups.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxGroups.Name = "listBoxGroups";
            this.listBoxGroups.Size = new System.Drawing.Size(259, 132);
            this.listBoxGroups.TabIndex = 60;
            this.listBoxGroups.SelectedIndexChanged += new System.EventHandler(this.listBoxGroups_SelectedGroupIndexChanged);
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.Location = new System.Drawing.Point(230, 24);
            this.pictureBoxCover.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(242, 70);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCover.TabIndex = 62;
            this.pictureBoxCover.TabStop = false;
            this.pictureBoxCover.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelGroups
            // 
            this.labelGroups.AutoSize = true;
            this.labelGroups.Location = new System.Drawing.Point(77, 803);
            this.labelGroups.Name = "labelGroups";
            this.labelGroups.Size = new System.Drawing.Size(51, 16);
            this.labelGroups.TabIndex = 63;
            this.labelGroups.Text = "Groups";
            // 
            // textBoxPost
            // 
            this.textBoxPost.Location = new System.Drawing.Point(36, 270);
            this.textBoxPost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPost.Name = "textBoxPost";
            this.textBoxPost.Size = new System.Drawing.Size(349, 22);
            this.textBoxPost.TabIndex = 64;
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(36, 303);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(67, 25);
            this.buttonPost.TabIndex = 65;
            this.buttonPost.Text = "Post";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 16;
            this.listBoxAlbums.Location = new System.Drawing.Point(6, 31);
            this.listBoxAlbums.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(249, 132);
            this.listBoxAlbums.TabIndex = 64;
            this.listBoxAlbums.SelectedIndexChanged += new System.EventHandler(this.listBoxAlbums_SelectedAlbumIndexChanged);
            // 
            // labelAlbums
            // 
            this.labelAlbums.AutoSize = true;
            this.labelAlbums.Location = new System.Drawing.Point(8, 10);
            this.labelAlbums.Name = "labelAlbums";
            this.labelAlbums.Size = new System.Drawing.Size(52, 16);
            this.labelAlbums.TabIndex = 65;
            this.labelAlbums.Text = "Albums";
            this.labelAlbums.Click += new System.EventHandler(this.labelAlbums_Click);
            // 
            // pictureBoxSelectedAlbum
            // 
            this.pictureBoxSelectedAlbum.Location = new System.Drawing.Point(272, 41);
            this.pictureBoxSelectedAlbum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxSelectedAlbum.Name = "pictureBoxSelectedAlbum";
            this.pictureBoxSelectedAlbum.Size = new System.Drawing.Size(105, 90);
            this.pictureBoxSelectedAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSelectedAlbum.TabIndex = 66;
            this.pictureBoxSelectedAlbum.TabStop = false;
            // 
            // labelSelectedAlbum
            // 
            this.labelSelectedAlbum.AutoSize = true;
            this.labelSelectedAlbum.Location = new System.Drawing.Point(268, 22);
            this.labelSelectedAlbum.Name = "labelSelectedAlbum";
            this.labelSelectedAlbum.Size = new System.Drawing.Size(102, 16);
            this.labelSelectedAlbum.TabIndex = 67;
            this.labelSelectedAlbum.Text = "Selected Album";
            // 
            // listBoxAlbumPhotos
            // 
            this.listBoxAlbumPhotos.FormattingEnabled = true;
            this.listBoxAlbumPhotos.ItemHeight = 16;
            this.listBoxAlbumPhotos.Location = new System.Drawing.Point(911, 703);
            this.listBoxAlbumPhotos.Name = "listBoxAlbumPhotos";
            this.listBoxAlbumPhotos.Size = new System.Drawing.Size(269, 116);
            this.listBoxAlbumPhotos.TabIndex = 68;
            this.listBoxAlbumPhotos.SelectedIndexChanged += new System.EventHandler(this.listBoxAlbumPhotos_SelectedPhotoChanged);
            // 
            // pictureBoxSelectedPhoto
            // 
            this.pictureBoxSelectedPhoto.Location = new System.Drawing.Point(1201, 703);
            this.pictureBoxSelectedPhoto.Name = "pictureBoxSelectedPhoto";
            this.pictureBoxSelectedPhoto.Size = new System.Drawing.Size(176, 117);
            this.pictureBoxSelectedPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSelectedPhoto.TabIndex = 69;
            this.pictureBoxSelectedPhoto.TabStop = false;
            // 
            // labelSelectedPhoto
            // 
            this.labelSelectedPhoto.AutoSize = true;
            this.labelSelectedPhoto.Location = new System.Drawing.Point(1200, 681);
            this.labelSelectedPhoto.Name = "labelSelectedPhoto";
            this.labelSelectedPhoto.Size = new System.Drawing.Size(99, 16);
            this.labelSelectedPhoto.TabIndex = 70;
            this.labelSelectedPhoto.Text = "Selected Photo";
            // 
            // labelSelectedAlbumPhotos
            // 
            this.labelSelectedAlbumPhotos.AutoSize = true;
            this.labelSelectedAlbumPhotos.Location = new System.Drawing.Point(912, 681);
            this.labelSelectedAlbumPhotos.Name = "labelSelectedAlbumPhotos";
            this.labelSelectedAlbumPhotos.Size = new System.Drawing.Size(90, 16);
            this.labelSelectedAlbumPhotos.TabIndex = 71;
            this.labelSelectedAlbumPhotos.Text = "Album Photos";
            // 
            // listBoxUserPosts
            // 
            this.listBoxUserPosts.FormattingEnabled = true;
            this.listBoxUserPosts.ItemHeight = 16;
            this.listBoxUserPosts.Location = new System.Drawing.Point(11, 146);
            this.listBoxUserPosts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxUserPosts.Name = "listBoxUserPosts";
            this.listBoxUserPosts.Size = new System.Drawing.Size(263, 84);
            this.listBoxUserPosts.TabIndex = 72;
            this.listBoxUserPosts.SelectedIndexChanged += new System.EventHandler(this.listBoxUserPosts_SelectedPostIndexChanged);
            // 
            // listBoxPostComments
            // 
            this.listBoxPostComments.FormattingEnabled = true;
            this.listBoxPostComments.ItemHeight = 16;
            this.listBoxPostComments.Location = new System.Drawing.Point(318, 146);
            this.listBoxPostComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxPostComments.Name = "listBoxPostComments";
            this.listBoxPostComments.Size = new System.Drawing.Size(126, 84);
            this.listBoxPostComments.TabIndex = 73;
            // 
            // labelUserPosts
            // 
            this.labelUserPosts.AutoSize = true;
            this.labelUserPosts.Location = new System.Drawing.Point(8, 125);
            this.labelUserPosts.Name = "labelUserPosts";
            this.labelUserPosts.Size = new System.Drawing.Size(83, 16);
            this.labelUserPosts.TabIndex = 74;
            this.labelUserPosts.Text = "User\'s Posts";
            // 
            // labelPostComments
            // 
            this.labelPostComments.AutoSize = true;
            this.labelPostComments.Location = new System.Drawing.Point(305, 121);
            this.labelPostComments.Name = "labelPostComments";
            this.labelPostComments.Size = new System.Drawing.Size(101, 16);
            this.labelPostComments.TabIndex = 75;
            this.labelPostComments.Text = "Post Comments";
            // 
            // pictureBoxGroup
            // 
            this.pictureBoxGroup.Location = new System.Drawing.Point(265, 892);
            this.pictureBoxGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxGroup.Name = "pictureBoxGroup";
            this.pictureBoxGroup.Size = new System.Drawing.Size(60, 48);
            this.pictureBoxGroup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGroup.TabIndex = 76;
            this.pictureBoxGroup.TabStop = false;
            // 
            // listBoxFriendsList
            // 
            this.listBoxFriendsList.FormattingEnabled = true;
            this.listBoxFriendsList.ItemHeight = 16;
            this.listBoxFriendsList.Location = new System.Drawing.Point(571, 41);
            this.listBoxFriendsList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxFriendsList.Name = "listBoxFriendsList";
            this.listBoxFriendsList.Size = new System.Drawing.Size(128, 84);
            this.listBoxFriendsList.TabIndex = 77;
            // 
            // labelFriends
            // 
            this.labelFriends.AutoSize = true;
            this.labelFriends.Location = new System.Drawing.Point(568, 23);
            this.labelFriends.Name = "labelFriends";
            this.labelFriends.Size = new System.Drawing.Size(52, 16);
            this.labelFriends.TabIndex = 78;
            this.labelFriends.Text = "Friends";
            // 
            // labelEvents
            // 
            this.labelEvents.AutoSize = true;
            this.labelEvents.Location = new System.Drawing.Point(412, 644);
            this.labelEvents.Name = "labelEvents";
            this.labelEvents.Size = new System.Drawing.Size(51, 16);
            this.labelEvents.TabIndex = 74;
            this.labelEvents.Text = "Events:";
            this.labelEvents.Click += new System.EventHandler(this.labelEvents_Click);
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.ItemHeight = 16;
            this.listBoxEvents.Location = new System.Drawing.Point(415, 674);
            this.listBoxEvents.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(247, 116);
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
            this.comboBoxFilterTime.Location = new System.Drawing.Point(676, 710);
            this.comboBoxFilterTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxFilterTime.Name = "comboBoxFilterTime";
            this.comboBoxFilterTime.Size = new System.Drawing.Size(133, 24);
            this.comboBoxFilterTime.TabIndex = 76;
            this.comboBoxFilterTime.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilterTime_SelectedIndexChanged);
            // 
            // buttonEventsFilter
            // 
            this.buttonEventsFilter.Location = new System.Drawing.Point(676, 674);
            this.buttonEventsFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEventsFilter.Name = "buttonEventsFilter";
            this.buttonEventsFilter.Size = new System.Drawing.Size(79, 23);
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
            this.comboBoxSortByAttends.Location = new System.Drawing.Point(676, 738);
            this.comboBoxSortByAttends.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSortByAttends.Name = "comboBoxSortByAttends";
            this.comboBoxSortByAttends.Size = new System.Drawing.Size(133, 24);
            this.comboBoxSortByAttends.TabIndex = 78;
            this.comboBoxSortByAttends.SelectedIndexChanged += new System.EventHandler(this.comboBoxSortByAttends_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageFeed);
            this.tabControl.Controls.Add(this.tabPageAlbums);
            this.tabControl.Controls.Add(this.tabPageLikedPages);
            this.tabControl.Controls.Add(this.tabPageGroups);
            this.tabControl.Location = new System.Drawing.Point(46, 162);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1053, 459);
            this.tabControl.TabIndex = 79;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageFeed
            // 
            this.tabPageFeed.Controls.Add(this.listBoxAboutInfo);
            this.tabPageFeed.Controls.Add(this.labelAbout);
            this.tabPageFeed.Controls.Add(this.labelUserPosts);
            this.tabPageFeed.Controls.Add(this.buttonAstrologyHoroscopePost);
            this.tabPageFeed.Controls.Add(this.labelPostComments);
            this.tabPageFeed.Controls.Add(this.listBoxUserPosts);
            this.tabPageFeed.Controls.Add(this.listBoxPostComments);
            this.tabPageFeed.Controls.Add(this.textBoxPost);
            this.tabPageFeed.Controls.Add(this.buttonPost);
            this.tabPageFeed.Location = new System.Drawing.Point(4, 25);
            this.tabPageFeed.Name = "tabPageFeed";
            this.tabPageFeed.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFeed.Size = new System.Drawing.Size(1045, 430);
            this.tabPageFeed.TabIndex = 0;
            this.tabPageFeed.Text = "Feed & Profile";
            this.tabPageFeed.UseVisualStyleBackColor = true;
            // 
            // tabPageAlbums
            // 
            this.tabPageAlbums.Controls.Add(this.flowLayoutPanelAlbumPhotos);
            this.tabPageAlbums.Controls.Add(this.listBoxAlbums);
            this.tabPageAlbums.Controls.Add(this.labelAlbums);
            this.tabPageAlbums.Controls.Add(this.pictureBoxSelectedAlbum);
            this.tabPageAlbums.Controls.Add(this.labelSelectedAlbum);
            this.tabPageAlbums.Location = new System.Drawing.Point(4, 25);
            this.tabPageAlbums.Name = "tabPageAlbums";
            this.tabPageAlbums.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlbums.Size = new System.Drawing.Size(1045, 430);
            this.tabPageAlbums.TabIndex = 1;
            this.tabPageAlbums.Text = "Albums";
            this.tabPageAlbums.UseVisualStyleBackColor = true;
            // 
            // tabPageLikedPages
            // 
            this.tabPageLikedPages.Controls.Add(this.flowLayoutPanelPages);
            this.tabPageLikedPages.Location = new System.Drawing.Point(4, 25);
            this.tabPageLikedPages.Name = "tabPageLikedPages";
            this.tabPageLikedPages.Size = new System.Drawing.Size(1045, 430);
            this.tabPageLikedPages.TabIndex = 2;
            this.tabPageLikedPages.Text = "Liked Pages";
            this.tabPageLikedPages.UseVisualStyleBackColor = true;
            // 
            // tabPageGroups
            // 
            this.tabPageGroups.Controls.Add(this.flowLayoutPanelGroups);
            this.tabPageGroups.Location = new System.Drawing.Point(4, 25);
            this.tabPageGroups.Name = "tabPageGroups";
            this.tabPageGroups.Size = new System.Drawing.Size(1045, 430);
            this.tabPageGroups.TabIndex = 3;
            this.tabPageGroups.Text = "Groups";
            this.tabPageGroups.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelPages
            // 
            this.flowLayoutPanelPages.AutoScroll = true;
            this.flowLayoutPanelPages.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelPages.Name = "flowLayoutPanelPages";
            this.flowLayoutPanelPages.Size = new System.Drawing.Size(1039, 424);
            this.flowLayoutPanelPages.TabIndex = 77;
            // 
            // flowLayoutPanelGroups
            // 
            this.flowLayoutPanelGroups.AutoScroll = true;
            this.flowLayoutPanelGroups.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelGroups.Name = "flowLayoutPanelGroups";
            this.flowLayoutPanelGroups.Size = new System.Drawing.Size(1039, 424);
            this.flowLayoutPanelGroups.TabIndex = 0;
            // 
            // flowLayoutPanelAlbumPhotos
            // 
            this.flowLayoutPanelAlbumPhotos.AutoScroll = true;
            this.flowLayoutPanelAlbumPhotos.Location = new System.Drawing.Point(8, 168);
            this.flowLayoutPanelAlbumPhotos.Name = "flowLayoutPanelAlbumPhotos";
            this.flowLayoutPanelAlbumPhotos.Size = new System.Drawing.Size(1028, 256);
            this.flowLayoutPanelAlbumPhotos.TabIndex = 68;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 1026);
            this.Controls.Add(this.pictureBoxCover);
            this.Controls.Add(this.listBoxPages);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelFriends);
            this.Controls.Add(this.listBoxAlbumPhotos);
            this.Controls.Add(this.pictureBoxSelectedPhoto);
            this.Controls.Add(this.pictureBoxGroup);
            this.Controls.Add(this.labelSelectedPhoto);
            this.Controls.Add(this.pictureBoxProfile);
            this.Controls.Add(this.labelSelectedAlbumPhotos);
            this.Controls.Add(this.listBoxGroups);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.labelGroups);
            this.Controls.Add(this.listBoxFriendsList);
            this.Controls.Add(this.comboBoxSortByAttends);
            this.Controls.Add(this.buttonEventsFilter);
            this.Controls.Add(this.comboBoxFilterTime);
            this.Controls.Add(this.listBoxEvents);
            this.Controls.Add(this.labelEvents);
            this.Controls.Add(this.buttonLogout);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedAlbum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroup)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageFeed.ResumeLayout(false);
            this.tabPageFeed.PerformLayout();
            this.tabPageAlbums.ResumeLayout(false);
            this.tabPageAlbums.PerformLayout();
            this.tabPageLikedPages.ResumeLayout(false);
            this.tabPageGroups.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion
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
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageFeed;
        private System.Windows.Forms.TabPage tabPageAlbums;
        private System.Windows.Forms.TabPage tabPageLikedPages;
        private System.Windows.Forms.TabPage tabPageGroups;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPages;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelGroups;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAlbumPhotos;
    }
}

