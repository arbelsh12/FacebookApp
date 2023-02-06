using System.Collections.Generic;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class FeaturesPanel : Panel
    {
        private List<FeatureButton> m_FeaturesButtons;

        public FeaturesPanel()
        {
            m_FeaturesButtons = new List<FeatureButton>();
            Location = new System.Drawing.Point(450, 45);
            Name = "panelPostFeatures";
            Size = new System.Drawing.Size(150, 250);
            AutoSize = true;
        }

        public void Add(FeatureButton i_FeatureButton)
        {
            m_FeaturesButtons.Add(i_FeatureButton);
            Controls.Add(i_FeatureButton);
        }

        public void Remove(FeatureButton i_FeatureButton)
        {
            m_FeaturesButtons.Remove(i_FeatureButton);
            Controls.Remove(i_FeatureButton);
        }
    }
}
