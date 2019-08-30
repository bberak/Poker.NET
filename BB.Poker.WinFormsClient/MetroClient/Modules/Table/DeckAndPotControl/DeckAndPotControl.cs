using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BB.Common.WinForms;

namespace BB.Poker.WinFormsClient
{
    public partial class DeckAndPotControl : MetroUserControl
    {
        public DeckAndPotControl()
        {
            InitializeComponent();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (InnerPanel == null)
                return;

            InnerPanel.Left = (ClientSize.Width - InnerPanel.Width) / 2;
            InnerPanel.Top = (ClientSize.Height - InnerPanel.Height) / 2;
        }
    }
}
