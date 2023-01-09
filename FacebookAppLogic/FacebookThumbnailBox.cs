using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacebookAppLogic
{
    public class FacebookThumbnailBox : ThumbnailBox
    {
        private readonly PictureBox r_FacebookPictureLeft;
        private readonly PictureBox r_FacebookPictureRight;

        public FacebookThumbnailBox(string i_Text, string i_PictureUrl) : base(i_Text, i_PictureUrl)
        {
            r_FacebookPictureLeft = new PictureBox()
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(31, 32),
                Name = "pictureBoxFacebook",
                Location = new Point(7, 112),
            };

            r_FacebookPictureRight = new PictureBox()
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(31, 32),
                Name = "pictureBoxFacebook",
                Location = new Point(138, 112),
            };

            r_FacebookPictureLeft.LoadAsync("https://cdn-icons-png.flaticon.com/512/124/124010.png");
            r_FacebookPictureRight.LoadAsync("https://cdn-icons-png.flaticon.com/512/124/124010.png");
            BackColor = SystemColors.GradientActiveCaption;
            Controls.Add(r_FacebookPictureLeft);
            Controls.Add(r_FacebookPictureRight);
        }

        public PictureBox FacebookPictureLeft
        {
            get { return r_FacebookPictureLeft; } 
        }

        public PictureBox FacebookPictureRight
        {
            get { return r_FacebookPictureRight; }
        }
    }
}
