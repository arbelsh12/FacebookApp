using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookAppLogic;
using FacebookWrapper;
using System.Threading;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private const int k_NotSelected = -1;
        private readonly Astrology r_Astrology;
        private readonly FilterEvents r_FilterEvents;
        private readonly FormLogIn r_FormLogIn;
        public eTheme Theme { get; set; }
        public eTheme PrevTheme { get; set; }

        public FormMain(FormLogIn i_FormLogin)
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
            r_Astrology = new Astrology();
            r_FilterEvents = new FilterEvents();
            r_FormLogIn = i_FormLogin;
            Theme = eTheme.Classic;
            PrevTheme = eTheme.Classic;
            loadUserInfo();
        }

        private enum eTab
        {
            FeedProfile,
            Friends,
            Albums,
            LikedPages,
            Groups,
            SportTeams,
            Events
        }

        private void loadUserInfo()
        {
            string userGender = LoggedInUserSingelton.Instance.User.Gender == User.eGender.female ? "Female" : "Male";
            string zodiac = r_Astrology.GetZodiac(LoggedInUserSingelton.Instance.User.Birthday);

            pictureBoxProfile.LoadAsync(LoggedInUserSingelton.Instance.User.PictureNormalURL);
            labelUserName.Text = LoggedInUserSingelton.Instance.User.Name;
            labelBirthDate.Text = LoggedInUserSingelton.Instance.User.Birthday;
            labelUserEmail.Text = LoggedInUserSingelton.Instance.User.Email;
            labelUserGender.Text = userGender;
            labelUserZodiac.Text = zodiac;
            new Thread(fetchCoverPhoto).Start();
            new Thread(fetchAlbums).Start();
            new Thread(fetchUserPosts).Start();
            pictureBoxSelectedAlbum.LoadAsync("https://media.istockphoto.com/id/1422715938/vector/no-image-vector-symbol-shadow-missing-available-icon-no-gallery-for-this-moment-placeholder.jpg?b=1&s=170667a&w=0&k=20&c=-GBgNDJfqE-wJmB9aew8E7Qzi197xz9JfCa88C_0rY8=");
        }
        
        private void fetchCoverPhoto()
        {
            foreach (Album album in LoggedInUserSingelton.Instance.User.Albums)
            {
                if (album.Name.Equals("Cover photos"))
                {
                    pictureBoxCover.LoadAsync(album.Photos[0].PictureNormalURL);

                    return;
                }
            }

            MessageBox.Show("No cover photo to retrieve :(");
        }

        private void fetchAlbums()
        {
            FacebookObjectCollection<Album> albums = LoggedInUserSingelton.Instance.User.Albums;

            listBoxAlbums.Invoke(new Action(
                () =>
                {
                    listBoxAlbums.Items.Clear();
                    listBoxAlbums.DisplayMember = "Name";
                    foreach (Album album in LoggedInUserSingelton.Instance.User.Albums)
                    {
                        listBoxAlbums.Items.Add(album);
                    }

                    if (listBoxAlbums.Items.Count == 0)
                    {
                        MessageBox.Show("No Albums to retrieve :(");
                    }
                }
            ));
        }

        private void displaySelectedAlbum()
        {
            if (listBoxAlbums.SelectedItems.Count == 1)
            {
                Album selectedAlbum = listBoxAlbums.SelectedItem as Album;

                if (selectedAlbum.PictureAlbumURL != null)
                {
                    pictureBoxSelectedAlbum.LoadAsync(selectedAlbum.PictureAlbumURL);
                }
                else
                {
                    pictureBoxSelectedAlbum.Image = pictureBoxSelectedAlbum.ErrorImage;
                }
            }
        }

        private void fetchUserPosts()
        {
            FacebookObjectCollection<Post> posts = LoggedInUserSingelton.Instance.User.Posts;

            listBoxUserPosts.Invoke(new Action(() => addPostsToListBox(posts)));
        }

        private void addPostsToListBox(FacebookObjectCollection<Post> i_Posts)
        {
            listBoxUserPosts.Items.Clear();
            foreach (Post post in i_Posts)
            {
                if (post.Message != null)
                {
                     listBoxUserPosts.Items.Add(post.Message);
                }
                else if (post.Caption != null)
                {
                   listBoxUserPosts.Items.Add(post.Caption);
                }
                else
                {
                    listBoxUserPosts.Items.Add(string.Format("[{0}]", post.Type));
                }
            }

            if (listBoxUserPosts.Items.Count == 0)
            {
                MessageBox.Show("No User Posts to retrieve :(");
            }
        }

        private void listBoxUserPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchPostComments();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
			FacebookService.LogoutWithUI();
            this.Hide();
            r_FormLogIn.Show();
            this.Close();
            LoggedInUserSingelton.Instance.User = null;
        }

        private async void buttonAstrologyHoroscopePost_Click(object sender, EventArgs e)
        {
            try
            {
                string astrologyHoroscopePost = await r_Astrology.CreateHoroscopePost(LoggedInUserSingelton.Instance.User.Birthday);

                MessageBox.Show(astrologyHoroscopePost);
                Status postedStatus = LoggedInUserSingelton.Instance.User.PostStatus(astrologyHoroscopePost);
                
                MessageBox.Show($"Post (ID {postedStatus.Id}) was posted succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Posting to feed failed (No permissions)");
            }
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            try
            {
                Status postedStatus = LoggedInUserSingelton.Instance.User.PostStatus(textBoxPost.Text);

                MessageBox.Show($"Post (ID {postedStatus.Id}) was posted succesfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Posting to feed failed (No permissions)");
            }
        }

        private void buttonEventsFilter_Click(object sender, EventArgs e)
        {
            if (comboBoxFilterTime.SelectedIndex == k_NotSelected && comboBoxSortByAttends.SelectedIndex == k_NotSelected)
            {
                MessageBox.Show("Please select filter's values in order to filter the events", "Filter failed");

                return;
            }

            try
            {
                if(LoggedInUserSingelton.Instance.Events?.Count > 0)
                {
                    ICollection<iEvent> sortedAndFilteredEvents = r_FilterEvents.FilterAndSortByUserSelection(LoggedInUserSingelton.Instance.Events, comboBoxFilterTime.SelectedIndex, comboBoxSortByAttends.SelectedIndex);

                    dataGridViewEvents.DataSource = sortedAndFilteredEvents;
                }
                else
                {
                    MessageBox.Show("No events to filter :(");

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to filter the events");
            }
        }
     
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case (int)eTab.FeedProfile:
                    {
                        break;
                    }
                case (int)eTab.Friends:
                    {
                        fetchFriends();
                        break;
                    }
                case (int)eTab.Albums:
                    {
                        break;
                    }
                case (int)eTab.LikedPages:
                    {
                        new Thread(fetchLikedPages).Start();
                        break;
                    }
                case (int)eTab.Groups:
                    {
                        new Thread(fetchGroups).Start();
                        break;
                    }
                case (int)eTab.SportTeams:
                    {
                        new Thread(fetchSportTeams).Start();
                        break;
                    }
                case (int)eTab.Events:
                    {
                        fetchEvents();
                        comboBoxFilterTime.SelectedIndex = comboBoxFilterTime.FindStringExact("-select-");
                        comboBoxSortByAttends.SelectedIndex = comboBoxFilterTime.FindStringExact("-select-");
                        break;
                    }
                default:
                    break;
            }
        }

        private void fetchLikedPages()
        {
            FacebookObjectCollection<Page> likedPages = LoggedInUserSingelton.Instance.User.LikedPages;

            flowLayoutPanelPages.Invoke(new Action(() => addLikedPagesToPanel(likedPages)));
            listBoxLikedPages.Invoke(new Action(() => pageBindingSource.DataSource = likedPages));
        }

        private void addLikedPagesToPanel(FacebookObjectCollection<Page> i_LikedPages)
        {
            if (flowLayoutPanelPages.Controls.Count == 0 || Theme != PrevTheme)
            {
                if (flowLayoutPanelPages.Controls.Count != 0)
                {
                    flowLayoutPanelPages.Controls.Clear();
                }

                if (i_LikedPages != null)
                {
                    try
                    {
                        foreach (Page page in i_LikedPages)
                        {
                            addGroupBoxToPanel(Theme, flowLayoutPanelPages, page.Name, page.PictureNormalURL);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            if (flowLayoutPanelPages.Controls.Count == 0)
            {
                MessageBox.Show("No liked pages to retrieve :(");
            }
        }


        private void fetchGroups()
        {
            FacebookObjectCollection<Group> groups = LoggedInUserSingelton.Instance.User.Groups;

            flowLayoutPanelGroups.Invoke(new Action(() => addGroupsToPanel(groups)));
            listBoxGroups.Invoke(new Action(() => groupBindingSource.DataSource = groups));
        }

        private void addGroupsToPanel(FacebookObjectCollection<Group> i_Groups)
        {
            if (flowLayoutPanelGroups.Controls.Count == 0 || Theme != PrevTheme)
            {
                if(flowLayoutPanelGroups.Controls.Count != 0)
                {
                    flowLayoutPanelGroups.Controls.Clear();
                }

                if (i_Groups != null)
                {
                    try
                    {
                        foreach (Group group in i_Groups)
                        {
                            addGroupBoxToPanel(Theme, flowLayoutPanelGroups, group.Name, group.PictureNormalURL);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            if (flowLayoutPanelGroups.Controls.Count == 0)
            {
                MessageBox.Show("No groups to retrieve :(");
            }
        }

        private void addGroupBoxToPanel(eTheme i_Theme, FlowLayoutPanel i_Panel, string i_Name, string i_PictureURL)
        {
            ThumbnailBox thumbnail = ThumbnailBoxFactory.Create(i_Theme, i_Name, i_PictureURL);
            i_Panel.Controls.Add(thumbnail);
        }

        private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            Album selectedAlbum = listBoxAlbums.SelectedItem as Album;

            displaySelectedAlbum();
            new Thread(() => fetchAlbumPhotos(selectedAlbum)).Start();
        }

        private void fetchAlbumPhotos(Album i_album)
        {
            FacebookObjectCollection<Photo> photos = i_album.Photos;

            flowLayoutPanelAlbumPhotos.Invoke(new Action(() => addPhotosToPanel(photos)));
        }

        private void addPhotosToPanel(FacebookObjectCollection<Photo> i_Photos)
        {
            flowLayoutPanelAlbumPhotos.Controls.Clear();
            try
            {
                if(listBoxAlbums.SelectedItems.Count == 1)
                {
                    foreach (Photo photo in i_Photos)
                    {
                        PictureBox picture = new PictureBox();

                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        picture.Size = new Size(100, 100);
                        if (photo.PictureNormalURL != null)
                        {
                            picture.LoadAsync(photo.PictureNormalURL);
                        }
                        else
                        {
                            picture.Image = picture.ErrorImage;
                        }

                        picture.Location = new Point(35, 45);
                        flowLayoutPanelAlbumPhotos.Controls.Add(picture);
                    }
                }
                else
                {
                    MessageBox.Show("No photos to retrieve in selected album :(");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fetchSportTeams()
        {
            Page[] teams = LoggedInUserSingelton.Instance.User.FavofriteTeams;

            flowLayoutPanelSport.Invoke(new Action(() => addSportTeamsToPanel(teams)));
        }

        private void addSportTeamsToPanel(Page[] i_Teams)
        {
            if (flowLayoutPanelSport.Controls.Count == 0 || Theme != PrevTheme)
            {
                if(flowLayoutPanelSport.Controls.Count != 0)
                {
                    flowLayoutPanelSport.Controls.Clear();
                }

                if (i_Teams != null)
                {
                    try
                    {
                        foreach (Page team in i_Teams)
                        {
                            addGroupBoxToPanel(Theme, flowLayoutPanelSport, team.Name, team.PictureNormalURL);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
           
            if (flowLayoutPanelSport.Controls.Count == 0)
            {
                MessageBox.Show("No sport teams to retrieve :(");
            }
        }

        private void fetchPostComments()
        {
            Post selected = LoggedInUserSingelton.Instance.User.Posts[listBoxUserPosts.SelectedIndex];

            flowLayoutPanelComments.Controls.Clear();
            if(selected != null)
            {
                try
                {
                    foreach (Comment comment in selected.Comments)
                    {
                        addCommentToPanel(flowLayoutPanelComments, comment.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No permissions to show this comment :(");
                }
            }

            if (flowLayoutPanelComments.Controls.Count == 0)
            {
                addCommentToPanel(flowLayoutPanelComments, "No comments for this post");
            }
        }

        private void addCommentToPanel(FlowLayoutPanel i_Panel, string i_comment)
        {
            Label label = new Label();

            label.Text = i_comment;
            label.BackColor = Color.LightSkyBlue;
            label.AutoSize = true;
            i_Panel.Controls.Add(label);
        }

        private void fetchFriends()
        {
            if (flowLayoutPanelFriends.Controls.Count != 0)
            {
                flowLayoutPanelFriends.Controls.Clear();
            }

            List<MockUser> friendsList = new List<MockUser>();

            foreach (MockUser friend in LoggedInUserSingelton.Instance.MockFriends)
            {
                addGroupBoxToPanel(Theme, flowLayoutPanelFriends, friend.Name, friend.PictureURL);
                friendsList.Add(friend);
            }

            mockUserBindingSource.DataSource = friendsList;

            if (flowLayoutPanelFriends.Controls.Count == 0)
            {
                try
                {
                    foreach (User friend in LoggedInUserSingelton.Instance.User.Friends)
                    {
                        addGroupBoxToPanel(Theme, flowLayoutPanelFriends, friend.Name, friend.PictureNormalURL);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (flowLayoutPanelFriends.Controls.Count == 0)
            {
                MessageBox.Show("No freinds to retrieve :(");
            }
        }

        private void fetchEvents()
        {
            try
            {
                dataGridViewEvents.DataSource = LoggedInUserSingelton.Instance.Events;

                dataGridViewEvents.Columns[0].HeaderText = "Name";
                dataGridViewEvents.Columns[1].HeaderText = "Start Time";
                dataGridViewEvents.Columns[2].HeaderText = "Attending";
                dataGridViewEvents.Columns[3].HeaderText = "Intrested";
                dataGridViewEvents.Columns[4].HeaderText = "Declined";
                dataGridViewEvents.Columns[5].HeaderText = "Maybe";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (dataGridViewEvents.Rows.Count == 0)
            {
                MessageBox.Show("No Events to retrieve :(");
            }
        }

        private void comboBoxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            PrevTheme = Theme;

            switch (comboBox.SelectedIndex)
            {
                case (int)eTheme.Classic:
                    {
                        Theme = eTheme.Classic;
                        break;
                    }
                case (int)eTheme.Dark:
                    {
                        Theme = eTheme.Dark;
                        break;
                    }
                case (int)eTheme.Facebook:
                    {
                        Theme = eTheme.Facebook;
                        break;
                    }
                default:
                    {
                        Theme = eTheme.Classic;
                        break;
                    }
            }

            if (Theme != PrevTheme)
            {
                updateCurTabTheme();
            }
        }

        private void updateCurTabTheme()
        {
            switch (tabControl.SelectedIndex)
            {
                case (int)eTab.Friends:
                    {
                        fetchFriends();
                        break;
                    }
                case (int)eTab.LikedPages:
                    {
                        new Thread(fetchLikedPages).Start();
                        break;
                    }
                case (int)eTab.Groups:
                    {
                        new Thread(fetchGroups).Start();
                        break;
                    }
                case (int)eTab.SportTeams:
                    {
                        new Thread(fetchSportTeams).Start();
                        break;
                    }
                default:
                    break;
            }
        }

        private void comboBoxFilterFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            switch (comboBox.SelectedIndex)
            {
                case (int)User.eGender.female:
                    {
                        LoggedInUserSingelton.Instance.MockFriends.UpdateGenderFilter((int)User.eGender.female);
                        break;
                    }
                case (int)User.eGender.male:
                    {
                        LoggedInUserSingelton.Instance.MockFriends.UpdateGenderFilter((int)User.eGender.male);
                        break;
                    }
                default:
                    {
                        LoggedInUserSingelton.Instance.MockFriends.UpdateGenderFilter(LoggedInUserSingelton.Instance.MockFriends.AllGenders);
                        break;
                    }
            }

            fetchFriends();
        }
    }
}

