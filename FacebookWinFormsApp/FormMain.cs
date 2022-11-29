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

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private const int k_NotSelected = -1;
        private readonly Astrology r_Astrology;
        private readonly FilterEvents r_FilterEvents;
        private User m_LoggedInUser;
        private LoginResult m_LoginResult;      

        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
            r_Astrology = new Astrology();
            r_FilterEvents = new FilterEvents();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns20cc"); /// the current password for Desig Patter

            m_LoginResult = FacebookService.Login(
                    "1089208135099959",
                    "email",
                    "public_profile",
                    "user_age_range",
                    "user_birthday",
                    "user_events",
                    "user_friends",
                    "user_gender",
                    "user_hometown",
                    "user_likes",
                    "user_link",
                    "user_location",
                    "user_photos",
                    "user_posts",
                    "user_videos",
                    "groups_access_member_info");

            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                m_LoggedInUser = m_LoginResult.LoggedInUser;
                loadUserInfo();
            }
            else
            {
                MessageBox.Show(m_LoginResult.ErrorMessage, "Login Failed");
            }

           // buttonLogin.Text = $"Logged in as {m_LoginResult.LoggedInUser.Name}";
        }

        private void loadUserInfo()
        {
            string userGender = m_LoggedInUser.Gender == User.eGender.female ? "Female" : "Male";

            pictureBoxProfile.LoadAsync(m_LoggedInUser.PictureNormalURL);
            listBoxAboutInfo.Items.Add(m_LoggedInUser.Email);
            listBoxAboutInfo.Items.Add(m_LoggedInUser.Birthday);
            listBoxAboutInfo.Items.Add(userGender);
            listBoxAboutInfo.Items.Add(r_Astrology.GetZodiac(m_LoggedInUser.Birthday));

            fetchCoverPhoto();
            fetchAlbums();
            fetchAlbumPhotos();
            fetchUserPosts();
            fetchFriendsList();
            fetchPagesList();
            fetchGroupsList();
            fetchEventsList();
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
            try
            {
                foreach (Album album in m_LoggedInUser.Albums)
                {
                    if (album.Name.Equals("Cover photos"))
                    {
                        pictureBoxCover.LoadAsync(album.Photos[0].PictureNormalURL);
                    }
                    else
                    {
                        MessageBox.Show("No cover photo to retrieve :(");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fetchFriendsList()
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fetchAlbums()
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void displaySelectedAlbum()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// End copy
        /// 
        private void fetchAlbumPhotos()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void displaySelectedPhoto()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //copied from Guy TODO: delete comment and change the code
        // Changed name, GUY - listBoxPosts MY name - listBoxUserPosts
        private void fetchUserPosts()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
			buttonLogin.Text = "Login";
            m_LoginResult = null;
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
            try
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
    }
}
