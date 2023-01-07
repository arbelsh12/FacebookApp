using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace FacebookAppLogic
{
    internal class ClassicThumbnailBox : ThumbnailBox
    {
        public ClassicThumbnailBox(string i_Text, string i_PictureUrl) : base(i_Text, i_PictureUrl)
        {
            BackColor = SystemColors.GradientActiveCaption; ;
        }
    }
}
