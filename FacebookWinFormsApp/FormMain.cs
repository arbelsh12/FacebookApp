using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private eTheme m_Theme;
        private eTheme m_prevTheme;

        public FormMain(FormLogIn i_FormLogin)
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
            r_Astrology = new Astrology();
            r_FilterEvents = new FilterEvents();
            r_FormLogIn = i_FormLogin;
            m_Theme = eTheme.Classic;
            m_prevTheme = eTheme.Classic;
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
            //fetchUserPosts();
            new Thread(fetchCoverPhoto).Start();
            new Thread(fetchAlbums).Start();
            //new Thread(fetchUserPosts).Start();
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
            listBoxAlbums.Items.Clear();
            listBoxAlbums.DisplayMember = "Name";
            foreach (Album album in LoggedInUserSingelton.Instance.User.Albums)
            {
                listBoxAlbums.Invoke(new Action(() => listBoxAlbums.Items.Add(album)));
            }

            if (listBoxAlbums.Items.Count == 0)
            {
                MessageBox.Show("No Albums to retrieve :(");
            }
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
            listBoxUserPosts.Items.Clear();
            foreach (Post post in LoggedInUserSingelton.Instance.User.Posts)
            {
                if (post.Message != null)
                {
                    listBoxUserPosts.Invoke(new Action(() => listBoxUserPosts.Items.Add(post.Message)));
                }
                else if (post.Caption != null)
                {
                    listBoxUserPosts.Invoke(new Action(() => listBoxUserPosts.Items.Add(post.Caption)));
                }
                else
                {
                    listBoxUserPosts.Invoke(new Action(() => listBoxUserPosts.Items.Add(string.Format("[{0}]", post.Type))));
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

        private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedAlbum();
            fetchAlbumPhotos();
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
                if(LoggedInUserSingelton.Instance.User.Events.Count > 0)
                {
                    //TODO: Do I need to create an object of fake User and set his Data? - Resume the code in this case in the next commit with mock user
                    //ICollection<iEvent> sortedAndFilteredEvents = r_FilterEvents.FilterAndSortByUserSelection(m_LoggedInUser.Events.ToList(), comboBoxFilterTime.SelectedIndex, comboBoxSortByAttends.SelectedIndex);

                    //dataGridViewEvents.DataSource = sortedAndFilteredEvents;
                }
                else if (LoggedInUserSingelton.Instance.MockData.Events.Count > 0)
                {
                    //old code - delete in future
                    //ICollection<MockEvent> sortedAndFilteredEvents = r_FilterMockEvents.FilterAndSortByUserSelection(r_MockData.Events, comboBoxFilterTime.SelectedIndex, comboBoxSortByAttends.SelectedIndex);
                    ICollection<iEvent> sortedAndFilteredEvents = r_FilterEvents.FilterAndSortByUserSelection(LoggedInUserSingelton.Instance.MockData.Events, comboBoxFilterTime.SelectedIndex, comboBoxSortByAttends.SelectedIndex);

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
            if (flowLayoutPanelPages.Controls.Count == 0 || m_Theme != m_prevTheme)
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
                            addGroupBoxToPanel(m_Theme, flowLayoutPanelPages, page.Name, page.PictureNormalURL);
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
            if (flowLayoutPanelGroups.Controls.Count == 0 || m_Theme != m_prevTheme)
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
                            addGroupBoxToPanel(m_Theme, flowLayoutPanelGroups, group.Name, group.PictureNormalURL);
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

        private void fetchAlbumPhotos()
        {
            flowLayoutPanelAlbumPhotos.Controls.Clear();
            try
            {
                if(listBoxAlbums.SelectedItems.Count == 1)
                {
                    Album selectedAlbum = listBoxAlbums.SelectedItem as Album;

                    foreach (Photo photo in selectedAlbum.Photos)
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
            if (flowLayoutPanelSport.Controls.Count == 0 || m_Theme != m_prevTheme)
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
                            addGroupBoxToPanel(m_Theme, flowLayoutPanelSport, team.Name, team.PictureNormalURL);
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
            if(flowLayoutPanelFriends.Controls.Count == 0 || m_Theme != m_prevTheme)
            {
                if(flowLayoutPanelFriends.Controls.Count != 0)
                {
                    flowLayoutPanelFriends.Controls.Clear();
                }

                try
                {
                    foreach (User friend in LoggedInUserSingelton.Instance.User.Friends)
                    {
                        addGroupBoxToPanel(m_Theme, flowLayoutPanelFriends, friend.Name, friend.PictureNormalURL);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (flowLayoutPanelFriends.Controls.Count == 0)
                {
                    foreach (MockUser friend in LoggedInUserSingelton.Instance.MockData.Friends)
                    {
                        addGroupBoxToPanel(m_Theme, flowLayoutPanelFriends, friend.Name, friend.PictureURL);
                    }

                    mockUserBindingSource.DataSource = LoggedInUserSingelton.Instance.MockData.Friends;
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
                if(LoggedInUserSingelton.Instance.User.Events.Count > 0)
                {
                    dataGridViewEvents.DataSource = LoggedInUserSingelton.Instance.User.Events;
                }
                else
                {
                    dataGridViewEvents.DataSource = LoggedInUserSingelton.Instance.MockData.Events;
                }

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

            m_prevTheme = m_Theme;

            switch (comboBox.SelectedIndex)
            {
                case (int)eTheme.Classic:
                    {
                        m_Theme = eTheme.Classic;
                        break;
                    }
                case (int)eTheme.Dark:
                    {
                        m_Theme = eTheme.Dark;
                        break;
                    }
                case (int)eTheme.Facebook:
                    {
                        m_Theme = eTheme.Facebook;
                        break;
                    }
                default:
                    {
                        m_Theme = eTheme.Classic;
                        break;
                    }
            }
        }
    }
}

