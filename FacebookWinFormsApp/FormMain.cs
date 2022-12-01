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
        private const int k_NotSelected = -1;
        private readonly Astrology r_Astrology;
        private readonly FilterEvents r_FilterEvents;
        private readonly FormLogIn r_FormLogIn;
        private User m_LoggedInUser;

        public FormMain(User i_User, FormLogIn i_FormLogin)
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
            r_Astrology = new Astrology();
            r_FilterEvents = new FilterEvents();
            r_FormLogIn = i_FormLogin;
            m_LoggedInUser = i_User;
            loadUserInfo();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

        }

        private void loadUserInfo()
        {
            string userGender = m_LoggedInUser.Gender == User.eGender.female ? "Female" : "Male";

            pictureBoxProfile.LoadAsync(m_LoggedInUser.PictureNormalURL);
            listBoxAboutInfo.Items.Add(m_LoggedInUser.Email);
            listBoxAboutInfo.Items.Add(m_LoggedInUser.Birthday);
            listBoxAboutInfo.Items.Add(userGender);
            listBoxAboutInfo.Items.Add(r_Astrology.GetZodiac(m_LoggedInUser.Birthday));
            labelUserName.Text = m_LoggedInUser.Name;
            labelUserName.Show();

            fetchCoverPhoto();
            fetchAlbums();
            //fetchAlbumPhotos();
            fetchUserPosts();
            //fetchFriendsList();
            fetchPagesList();
            fetchGroupsList();
           // fetchEventsList();
            pictureBoxSelectedAlbum.LoadAsync("https://media.istockphoto.com/id/1422715938/vector/no-image-vector-symbol-shadow-missing-available-icon-no-gallery-for-this-moment-placeholder.jpg?b=1&s=170667a&w=0&k=20&c=-GBgNDJfqE-wJmB9aew8E7Qzi197xz9JfCa88C_0rY8=");
        }

        private void fetchEventsList()
        {
            //copied from Guy TODO: delete comment and change the code
            listBoxEvents.Items.Clear();
            listBoxEvents.DisplayMember = "Name";

            foreach (Event fbEvent in m_LoggedInUser.Events)
            {
                listBoxEvents.Items.Add(fbEvent);
            }

            if (listBoxEvents.Items.Count == 0)
            {
                MessageBox.Show("No Events to retrieve :(");
            }
        }

        private void fetchGroupsList()
        {
            //copied from Guy TODO: delete comment and change the code
            listBoxGroups.Items.Clear();
            listBoxGroups.DisplayMember = "Name";

            try
            {
                foreach (Group group in m_LoggedInUser.Groups)
                {
                    listBoxGroups.Items.Add(group);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (listBoxGroups.Items.Count == 0)
            {
                MessageBox.Show("No groups to retrieve :(");
            }
        }

        private void fetchPagesList()
        {
            //copied from Guy TODO: delete comment and change the code
            listBoxPages.Items.Clear();
            listBoxPages.DisplayMember = "Name";

            try
            {
                foreach (Page page in m_LoggedInUser.LikedPages)
                {
                    listBoxPages.Items.Add(page);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (listBoxPages.Items.Count == 0)
            {
                MessageBox.Show("No liked pages to retrieve :(");
            }
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

        private void fetchFriendsList()
        {
            listBoxFriendsList.Items.Clear();

            foreach (User friend in m_LoggedInUser.Friends)
            {
                listBoxFriendsList.Items.Add(friend);
            }

            if (listBoxFriendsList.Items.Count == 0)
            {
                MessageBox.Show("No friends to retrieve :(");
            }
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

                fetchAlbumPhotos();
            }
        }
        /// End copy
        /// 
        private void fetchAlbumPhotos()
        {
            if (listBoxAlbums.SelectedItems.Count == 1)
            {
                Album selectedAlbum = listBoxAlbums.SelectedItem as Album;

                listBoxAlbumPhotos.Items.Clear();
                listBoxAlbumPhotos.DisplayMember = "Name";
                pictureBoxSelectedPhoto.LoadAsync(selectedAlbum.PictureAlbumURL);

                foreach (Photo photo in selectedAlbum.Photos)
                {
                    listBoxAlbumPhotos.Items.Add(photo);
                }
            }
            else
            {
                MessageBox.Show("No photos to retrieve in selected album :(");
            }
        }

        private void displaySelectedPhoto()
        {
            if (listBoxAlbumPhotos.SelectedItems.Count == 1)
            {
                Photo selectedPhoto = listBoxAlbumPhotos.SelectedItem as Photo;

                if (selectedPhoto.PictureNormalURL != null)
                {
                    pictureBoxSelectedPhoto.LoadAsync(selectedPhoto.PictureNormalURL);
                }
                else
                {
                    // CHANGE to another picture, not profile
                    pictureBoxSelectedPhoto.Image = pictureBoxProfile.ErrorImage;
                }
            }
        }

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
        private void listBoxUserPosts_SelectedPostIndexChanged(object sender, EventArgs e)
        {
            Post selected = m_LoggedInUser.Posts[listBoxUserPosts.SelectedIndex];
            listBoxPostComments.DisplayMember = "Message";

            try
            {
                listBoxPostComments.DataSource = selected.Comments;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No permissions to show this comment :(");
            }
        }

        private void listBoxGroups_SelectedGroupIndexChanged(object sender, EventArgs e)
        {
            if (listBoxGroups.SelectedItems.Count == 1)
            {
                Group selectedGroup = listBoxGroups.SelectedItem as Group;
                pictureBoxGroup.LoadAsync(selectedGroup.PictureNormalURL);
            }
        }
        /// END COPY

        private void buttonLogout_Click(object sender, EventArgs e)
        {
			FacebookService.LogoutWithUI();
            this.Hide();
            r_FormLogIn.Show(); // maybe should use : ShowDialog();
            this.Close();
        }

        private void pictureBoxProfile_Click(object sender, EventArgs e)
        {

        }

        private void listViewAboutInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelAbout_Click(object sender, EventArgs e)
        {

        }

        private void listBoxPages_SelectedIndexChanged(object sender, EventArgs e)
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
        private void listBoxAlbums_SelectedAlbumIndexChanged(object sender, EventArgs e)
        {
            displaySelectedAlbum();
            fetchAlbumPhotosFlowControl();
        }
        /// End copy
        
        private void listBoxAlbumPhotos_SelectedPhotoChanged(object sender, EventArgs e)
        {
            displaySelectedPhoto();
        }

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
                if (listBoxEvents.Items.Count == 0)
                {
                    MessageBox.Show("No events to filter :(");
                    
                    return;
                }

                if(comboBoxFilterTime.SelectedIndex == k_NotSelected && comboBoxSortByAttends.SelectedIndex == k_NotSelected)
                {
                    MessageBox.Show("Please select filter's values in order to filter the events", "Filter failed");

                    return;
                }

            try
            {
                listBoxEvents.Items.Clear();                
                ICollection<Event> sortedAndFilteredEvents = r_FilterEvents.FilterAndSortByUserSelection(m_LoggedInUser.Events.ToList(), comboBoxFilterTime.SelectedIndex, comboBoxSortByAttends.SelectedIndex);

                listBoxEvents.Items.AddRange((ListBox.ObjectCollection)sortedAndFilteredEvents);
            }
            catch(Exception ex)
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
                        MessageBox.Show("Click tab 1 ! :)");
                        break;
                    }
                case 1:
                    {
                        MessageBox.Show("Click tab 2 ! :)");
                        break;
                    }
                case 2:
                    {
                        MessageBox.Show("Click tab 3 ! :)");
                        fetchLikedPagesListFlowControl();
                        break;
                    }
                case 3:
                    {
                        MessageBox.Show("Click tab 4 ! :)");
                        fetchGroupsListFlowControl();
                        break;
                    }
                case 4:
                    {
                        MessageBox.Show("Click tab 5 ! :)");
                        fetchSportTeamsFlowControl();
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

            try
            {
                foreach (Page page in m_LoggedInUser.LikedPages)
                {
                    GroupBox box = new GroupBox();
                    box.Size = new Size(140, 120);
                    box.Text = page.Name;
                    box.Name = "Groupbox" + page.Name;
                    box.BackColor = Color.Pink;

                    PictureBox pagePicture = new PictureBox();
                    pagePicture.SizeMode = PictureBoxSizeMode.StretchImage;
                    pagePicture.Size = new Size(70, 70);
                    pagePicture.LoadAsync(page.PictureNormalURL);
                    pagePicture.Name = "pictureBox" + page.Name;
                    pagePicture.Location = new Point(35, 45);


                    box.Controls.Add(pagePicture);

                    flowLayoutPanelPages.Controls.Add(box);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

            try
            {
                foreach (Group group in m_LoggedInUser.Groups)
                {
                    GroupBox box = new GroupBox();
                    box.Size = new Size(140, 120);
                    box.Text = group.Name;
                    box.Name = "Groupbox" + group.Name;
                    box.BackColor = Color.Pink;

                    PictureBox groupPicture = new PictureBox();
                    groupPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                    groupPicture.Size = new Size(70, 70);
                    groupPicture.LoadAsync(group.PictureNormalURL);
                    groupPicture.Name = "pictureBox" + group.Name;
                    groupPicture.Location = new Point(35, 45);


                    box.Controls.Add(groupPicture);

                    flowLayoutPanelGroups.Controls.Add(box);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (flowLayoutPanelGroups.Controls.Count == 0)
            {
                MessageBox.Show("No groups to retrieve :(");
            }
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

                    pictureBoxSelectedPhoto.LoadAsync(selectedAlbum.PictureAlbumURL);

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

                        //pagePicture.Name = "pictureBox" + photo.Name;
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
                        GroupBox box = new GroupBox();
                        box.Size = new Size(140, 120);
                        box.Text = team.Name;
                        box.Name = "Groupbox" + team.Name;
                        box.BackColor = Color.Pink;

                        PictureBox groupPicture = new PictureBox();
                        groupPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                        groupPicture.Size = new Size(70, 70);
                        groupPicture.LoadAsync(team.PictureNormalURL);
                        groupPicture.Name = "pictureBox" + team.Name;
                        groupPicture.Location = new Point(35, 45);


                        box.Controls.Add(groupPicture);

                        flowLayoutPanelSport.Controls.Add(box);
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

        private void labelUserName_Click(object sender, EventArgs e)
        {

        }
    }
}

