using System.Collections.Generic;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class CommandsPanel : Panel
    {
        private List<CommandButton> m_CommandsButtons;

        public CommandsPanel()
        {
            m_CommandsButtons = new List<CommandButton>();
            Location = new System.Drawing.Point(450, 45);
            Name = "panelPostFeatures";
            Size = new System.Drawing.Size(400, 250);
            AutoSize = true;
        }

        public void Add(CommandButton i_CommandButton)
        {
            m_CommandsButtons.Add(i_CommandButton);
            Controls.Add(i_CommandButton);
        }

        public void Remove(CommandButton i_CommandButton)
        {
            m_CommandsButtons.Remove(i_CommandButton);
            Controls.Remove(i_CommandButton);
        }
    }
}
