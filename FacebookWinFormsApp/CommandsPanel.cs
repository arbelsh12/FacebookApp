using System.Collections.Generic;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class CommandsPanel : Panel
    {
        private List<CommandButton> m_FeaturesButtons;

        public CommandsPanel()
        {
            m_FeaturesButtons = new List<CommandButton>();
            Location = new System.Drawing.Point(450, 45);
            Name = "panelPostFeatures";
            Size = new System.Drawing.Size(400, 250);
            AutoSize = true;
        }

        public void Add(CommandButton i_FeatureButton)
        {
            m_FeaturesButtons.Add(i_FeatureButton);
            Controls.Add(i_FeatureButton);
        }

        public void Remove(CommandButton i_FeatureButton)
        {
            m_FeaturesButtons.Remove(i_FeatureButton);
            Controls.Remove(i_FeatureButton);
        }
    }
}
