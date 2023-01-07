using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacebookAppLogic
{
    public class DarkThumbnailBox : ThumbnailBox
    {
        private readonly Label r_Label;
        public DarkThumbnailBox(string i_Text, string i_PictureUrl) : base(i_Text, i_PictureUrl)
        {
            r_Label = new Label()
            {
                Text = i_Text,
                Font = new Font("Algerian", 10.8f, FontStyle.Bold),
                Location = new Point(36, 36),
                ForeColor = Color.White
            };

            Controls.Add(r_Label);
            BackColor = Color.Black;
            ForeColor = Color.LightGray;
        }
    
    }
}
