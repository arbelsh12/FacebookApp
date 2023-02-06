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
        public  Action CommandAction { get; set; }

        public virtual void Selected()
        {
            if(CommandAction != null)
            {
                CommandAction.Invoke();
            }
        }
    }
}
