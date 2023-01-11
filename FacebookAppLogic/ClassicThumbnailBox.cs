using System;
using System.Drawing;


namespace FacebookAppLogic
{
    public class ClassicThumbnailBox : ThumbnailBox
    {
        public ClassicThumbnailBox(string i_Text, string i_PictureUrl) : base(i_Text, i_PictureUrl)
        {
            BackColor = SystemColors.GradientActiveCaption; ;
        }
    }
}
