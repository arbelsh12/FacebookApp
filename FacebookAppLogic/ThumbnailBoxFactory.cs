using System;

namespace FacebookAppLogic
{
    public static class ThumbnailBoxFactory
    {
        public static ThumbnailBox Create(eTheme i_Theme, string i_Text, string i_PictureUrl)
        {
            ThumbnailBox box = null;

            switch (i_Theme)
            {
                case eTheme.Classic:
                    {
                        box = new ClassicThumbnailBox(i_Text, i_PictureUrl);
                        break;
                    }
                case eTheme.Dark:
                    {
                        box = new DarkThumbnailBox(i_Text, i_PictureUrl);
                        break;
                    }
                case eTheme.Facebook:
                    {
                        box = new FacebookThumbnailBox(i_Text, i_PictureUrl);
                        break;
                    }
                default:
                    break;
            }

            return box;
        }
    }
}
