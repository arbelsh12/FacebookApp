using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookAppLogic
{
    public class DarkThumbnailBox : ThumbnailBox
    {
        public DarkThumbnailBox(string i_Text, string i_PictureUrl) : base(i_Text, i_PictureUrl)
        {
            BackColor = SystemColors.ControlDark;
        }
    }
}
