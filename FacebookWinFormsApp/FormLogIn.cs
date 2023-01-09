using FacebookAppLogic;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FormLogIn : Form
    {
        private LoginResult m_LoginResult;

        public FormLogIn()
        {
            InitializeComponent();
            pictureBoxLogo.LoadAsync("https://i2-prod.mirror.co.uk/incoming/article676858.ece/ALTERNATES/s1200/Topic%20-%20Facebook");
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
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
                this.DialogResult = DialogResult.OK;
                this.Hide();
                LoggedInUserSingelton.Instance.User = m_LoginResult.LoggedInUser;
                FormMain formMain = new FormMain(this);
                formMain.ShowDialog();
            }
            else
            {
                MessageBox.Show(m_LoginResult.ErrorMessage, "Login Failed");
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

