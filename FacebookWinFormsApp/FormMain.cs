﻿using System;
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

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private User m_LoggedInUser;
        private const int k_NotSelected = -1;
        private readonly Astrology r_Astrology;
        private readonly FilterEvents r_FilterEvents;
        private readonly FilterMockEvents r_FilterMockEvents;
        private readonly FormLogIn r_FormLogIn;
        private readonly MockData r_MockData;

        public FormMain(User i_User, FormLogIn i_FormLogin)
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
            r_Astrology = new Astrology();
            r_FilterEvents = new FilterEvents();
            r_FilterMockEvents = new FilterMockEvents();
            r_MockData = new MockData();
            r_FormLogIn = i_FormLogin;
            m_LoggedInUser = i_User;
            loadUserInfo();
        }

        private void loadUserInfo()
        {
            string userGender = m_LoggedInUser.Gender == User.eGender.female ? "Female" : "Male";
            string zodiac = r_Astrology.GetZodiac(m_LoggedInUser.Birthday);

            pictureBoxProfile.LoadAsync(m_LoggedInUser.PictureNormalURL);
            labelUserName.Text = m_LoggedInUser.Name;
            labelBirthDate.Text = m_LoggedInUser.Birthday;
            labelUserEmail.Text = m_LoggedInUser.Email;
            labelUserGender.Text = userGender;
            labelUserZodiac.Text = zodiac;

            fetchCoverPhoto();
            fetchAlbums();
            fetchUserPosts();
            pictureBoxSelectedAlbum.LoadAsync("https://media.istockphoto.com/id/1422715938/vector/no-image-vector-symbol-shadow-missing-available-icon-no-gallery-for-this-moment-placeholder.jpg?b=1&s=170667a&w=0&k=20&c=-GBgNDJfqE-wJmB9aew8E7Qzi197xz9JfCa88C_0rY8=");
        }
        
        private void fetchCoverPhoto()
        {
            foreach (Album album in m_LoggedInUser.Albums)
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
            //copied from Guy TODO: delete comment and change the code
            listBoxAlbums.Items.Clear();
            listBoxAlbums.DisplayMember = "Name";

            foreach (Album album in m_LoggedInUser.Albums)
            {
                listBoxAlbums.Items.Add(album);
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
                    // CHANGE to another picture, not profile
                    pictureBoxSelectedAlbum.Image = pictureBoxProfile.ErrorImage;
                }
            }
        }
        /// End copy      

        //copied from Guy TODO: delete comment and change the code
        // Changed name, GUY - listBoxPosts MY name - listBoxUserPosts
        private void fetchUserPosts()
        {
            listBoxUserPosts.Items.Clear();

            foreach (Post post in m_LoggedInUser.Posts)
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

        /// <summary>
        /// Fetching all comments *** made by the logged in user ***, to the selected post:
        /// </summary>
        private void listBoxUserPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchCommentsFlowControl();
        }
        /// END COPY

        private void buttonLogout_Click(object sender, EventArgs e)
        {
			FacebookService.LogoutWithUI();
            this.Hide();
            r_FormLogIn.Show(); // maybe should use : ShowDialog();
            this.Close();
            m_LoggedInUser = null;
        }

        private void pictureBoxProfile_Click(object sender, EventArgs e)
        {

        }

        private async void buttonAstrologyHoroscopePost_Click(object sender, EventArgs e)
        {
            try
            {
                string astrologyHoroscopePost = await r_Astrology.CreateHoroscopePost(m_LoggedInUser.Birthday);

                MessageBox.Show(astrologyHoroscopePost);
                Status postedStatus = m_LoggedInUser.PostStatus(astrologyHoroscopePost);
                
                MessageBox.Show($"Post (ID {postedStatus.Id}) was posted succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Posting to feed failed (No permissions)");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //copied from Guy TODO: delete comment and change the code
        private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedAlbum();
            fetchAlbumPhotosFlowControl();
        }
        /// End copy

        private void buttonPost_Click(object sender, EventArgs e)
        {
            try
            {
                Status postedStatus = m_LoggedInUser.PostStatus(textBoxPost.Text);

                MessageBox.Show($"Post (ID {postedStatus.Id}) was posted succesfully");
            }
            catch (Exception)
            {
                MessageBox.Show($"Posting to feed failed (No permissions)");
            }
        }

        private void labelAlbums_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxFilterTime_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                if(m_LoggedInUser.Events.Count > 0)
                {
                    ICollection<Event> sortedAndFilteredEvents = r_FilterEvents.FilterAndSortByUserSelection(m_LoggedInUser.Events.ToList(), comboBoxFilterTime.SelectedIndex, comboBoxSortByAttends.SelectedIndex);

                    dataGridViewEvents.DataSource = sortedAndFilteredEvents;
                }
                else if (r_MockData.Events.Count > 0)
                {
                    ICollection<MockEvent> sortedAndFilteredEvents = r_FilterMockEvents.FilterAndSortByUserSelection(r_MockData.Events, comboBoxFilterTime.SelectedIndex, comboBoxSortByAttends.SelectedIndex);

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

        private void comboBoxSortByAttends_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelEvents_Click(object sender, EventArgs e)
        {

        }

        //

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        fetchFriendsFlowControl();
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        fetchLikedPagesListFlowControl();
                        break;
                    }
                case 4:
                    {
                        fetchGroupsListFlowControl();
                        break;
                    }
                case 5:
                    {
                        fetchSportTeamsFlowControl();
                        break;
                    }
                case 6:
                    {
                        fetchEventsDataGrid();
                        comboBoxFilterTime.SelectedIndex = comboBoxFilterTime.FindStringExact("-select-");
                        comboBoxSortByAttends.SelectedIndex = comboBoxFilterTime.FindStringExact("-select-");
                        break;
                    }
                default:
                    break;
            }

        }

        private void fetchLikedPagesListFlowControl()
        {
            flowLayoutPanelPages.Controls.Clear();
            //listBoxPages.DisplayMember = "Name";
            if (m_LoggedInUser.LikedPages != null)
            {
                try
                {
                    foreach (Page page in m_LoggedInUser.LikedPages)
                    {
                        addGroupBoxToPanel(flowLayoutPanelPages, page.Name, page.PictureNormalURL);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
            if (flowLayoutPanelPages.Controls.Count == 0)
            {
                MessageBox.Show("No liked pages to retrieve :(");
            }
        }

        private void fetchGroupsListFlowControl()
        {
            flowLayoutPanelGroups.Controls.Clear();
            //listBoxPages.DisplayMember = "Name";
            if(m_LoggedInUser.Groups != null)
            {
                try
                {
                    foreach (Group group in m_LoggedInUser.Groups)
                    {
                        addGroupBoxToPanel(flowLayoutPanelGroups, group.Name, group.PictureNormalURL);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (flowLayoutPanelGroups.Controls.Count == 0)
            {
                MessageBox.Show("No groups to retrieve :(");
            }
        }

        private void addGroupBoxToPanel(FlowLayoutPanel i_Panel, string i_Name, string i_PictureURL)
        {
            GroupBox box = new GroupBox();
            PictureBox picture = new PictureBox();

            box.Size = new Size(140, 120);
            box.Text = i_Name;
            box.Name = "Groupbox" + i_Name;
            box.BackColor = SystemColors.GradientActiveCaption;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Size = new Size(70, 70);
            picture.LoadAsync(i_PictureURL);
            picture.Name = "pictureBox" + i_Name;
            picture.Location = new Point(35, 45);
            box.Controls.Add(picture);
            i_Panel.Controls.Add(box);
        }

        private void fetchAlbumPhotosFlowControl()
        {
            flowLayoutPanelAlbumPhotos.Controls.Clear();
            //listBoxPages.DisplayMember = "Name";
            try
            {
                if (listBoxAlbums.SelectedItems.Count == 1)
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
                            // CHANGE to another picture, not profile
                            picture.Image = pictureBoxProfile.ErrorImage;
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

        private void fetchSportTeamsFlowControl()
        {
            flowLayoutPanelSport.Controls.Clear();
            //listBoxPages.DisplayMember = "Name";
            if (m_LoggedInUser.FavofriteTeams != null)
            {
                try
                {
                    foreach (Page team in m_LoggedInUser.FavofriteTeams)
                    {
                        addGroupBoxToPanel(flowLayoutPanelSport, team.Name, team.PictureNormalURL);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            if (flowLayoutPanelSport.Controls.Count == 0)
            {
                MessageBox.Show("No sport teams to retrieve :(");
            }
        }

        private void fetchCommentsFlowControl()
        {
            Post selected = m_LoggedInUser.Posts[listBoxUserPosts.SelectedIndex];

            flowLayoutPanelComments.Controls.Clear();
            if (selected != null)
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

        private void fetchFriendsFlowControl()
        {
            flowLayoutPanelFriends.Controls.Clear();

            try
            {
                foreach (User friend in m_LoggedInUser.Friends)
                {
                    addGroupBoxToPanel(flowLayoutPanelFriends, friend.Name, friend.PictureNormalURL);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (flowLayoutPanelFriends.Controls.Count == 0)
            {
                foreach(MockUser friend in r_MockData.Friends)
                {
                    addGroupBoxToPanel(flowLayoutPanelFriends, friend.Name, friend.PictureURL);
                }
            }

            if (flowLayoutPanelFriends.Controls.Count == 0)
            {
                MessageBox.Show("No freinds to retrieve :(");
            }
        }

        private void fetchEventsDataGrid()
        {
            try
            {
                if(m_LoggedInUser.Events.Count != 0)
                {
                    dataGridViewEvents.DataSource = m_LoggedInUser.Events;
                }
                else
                {
                    dataGridViewEvents.DataSource = r_MockData.Events;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //if (dataGridViewEvents.Rows.Count == 0)
            //{
            //    dataGridViewEvents.DataSource = r_MockData.Events;
            //}

            if (dataGridViewEvents.Rows.Count == 0)
            {
                MessageBox.Show("No Events to retrieve :(");
            }
        }

        private void tabPageEvents_Click(object sender, EventArgs e)
        {

        }

        private void labelSort_Click(object sender, EventArgs e)
        {

        }
    }
}

