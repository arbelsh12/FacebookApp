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
        private User m_LoggedInUser;
        private LoginResult m_LoginResult;
        private AstrologyHoroscope m_AstrologyHoroscope;

        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
            m_AstrologyHoroscope = new AstrologyHoroscope();
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
                    "user_videos");

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
            fetchCoverPhoto();
            fetchAlbums();
            fetchAlbumPhotos();
            fetchUserPosts();
            // To change to picture that says someing like "No album selected" 
            pictureBoxSelectedAlbum.LoadAsync("http://www.trendycovers.com/covers/Listen_to_your_heart_facebook_cover_1330517429.jpg");

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
            /// End copy

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
            /// End copy
        }

        private void fetchCoverPhoto()
        {
            foreach (Album album in m_LoggedInUser.Albums)
            {
                if(album.Name.Equals("Cover photos"))
                {
                    pictureBoxCover.LoadAsync(album.Photos[0].PictureNormalURL);
                    return;
                }
            }

            MessageBox.Show("No cover photo to retrieve :(");
        }

        

        //copied from Guy TODO: delete comment and change the code
        private void fetchAlbums()
        {
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
                string astrologyHoroscopePost = await m_AstrologyHoroscope.CreatePost(m_LoggedInUser.Birthday);
                MessageBox.Show(astrologyHoroscopePost);
                Status postedStatus = m_LoggedInUser.PostStatus(astrologyHoroscopePost);
                MessageBox.Show($"Post (ID {postedStatus.Id}) was posted succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Posting to feed failed (No permissions)");
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

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
            catch (Exception ex)
            {
                MessageBox.Show($"Posting to feed faile (No permissions)");
            }
        }

        private void labelAlbums_Click(object sender, EventArgs e)
        {

        }
    }
}
