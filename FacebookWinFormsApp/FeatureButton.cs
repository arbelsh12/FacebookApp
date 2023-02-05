using FacebookAppLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class FeatureButton : Button
    {
        public  ICommand Command { get; set; }

        public FeatureButton()
        {

        }

        protected override void OnClick(EventArgs e)
        {
            if (Command != null)
            {
                Command.Execute();
            }
        }
    }
}
