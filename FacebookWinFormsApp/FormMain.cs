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
                    pictureBoxProfile.Image = pictureBoxProfile.ErrorImage;
                }
            }
        }
        /// End copy



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
            //copied from Guy TODO: delete comment and change the code
            try
            {
                string astrologyHoroscopePost = await m_AstrologyHoroscope.CreatePost(m_LoggedInUser.Birthday);
                MessageBox.Show(astrologyHoroscopePost);
                Status postedStatus = m_LoggedInUser.PostStatus(astrologyHoroscopePost);
                MessageBox.Show("Status Posted! ID: " + postedStatus.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Posting to feed faile (No permissions)");
            }
            ///
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
    }
}
