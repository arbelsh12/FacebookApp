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
           // Location = new System.Drawing.Point(536, 1);
            Location = new System.Drawing.Point(335, 10);
            Name = "panelPostFeatures";
            //Size = new System.Drawing.Size(366, 261);
            Size = new System.Drawing.Size(300, 185);
            //BackColor = System.Drawing.Color.Red;
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
