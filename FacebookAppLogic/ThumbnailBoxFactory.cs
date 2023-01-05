using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookAppLogic
{
    public static class ThumbnailBoxFactory
    {
        public static ThumbnailBox Create(eTheme i_Theme, string i_Text, string i_PictureUrl)
        {
            ThumbnailBox box = null;

            switch (i_Theme)
            {
                case eTheme.Dark:
                    box = new DarkThumbnailBox(i_Text, i_PictureUrl);
                    break;
                case eTheme.Facebook:
                    box = new FacebookThumbnailBox(i_Text, i_PictureUrl);
                    break;
                default:
                    //throw new ArgumentException("Not Valid vehicle type");
                    break;
            }

            return box;
        }
    }
}
