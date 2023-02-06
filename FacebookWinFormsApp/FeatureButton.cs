using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class FeatureButton : Button
    {
        public  Action CommandAction { get; set; }

        protected override void OnClick(EventArgs e)
        {
            if(CommandAction != null)
            {
                CommandAction.Invoke();
            }
        }
    }
}
