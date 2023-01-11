using System;
using System.Windows.Forms;
using System.Drawing;

namespace FacebookAppLogic
{
    public abstract class ThumbnailBox : GroupBox
    {
        private readonly PictureBox r_Picture;

        protected ThumbnailBox(string i_Text, string i_PictureUrl)
        {
            Size = new Size(175, 150);
            Text = i_Text;
            Name = "Groupbox" + i_Text;

            r_Picture = new PictureBox()
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(77, 77),
                Name = "pictureBox" + i_Text,
                Location = new Point(44, 56),
            };

            r_Picture.LoadAsync(i_PictureUrl);
            Controls.Add(r_Picture);
        }

        public PictureBox Picture
        {
            get { return r_Picture; }
        }
    }
}