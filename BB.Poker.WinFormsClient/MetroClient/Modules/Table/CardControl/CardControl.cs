using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BB.Poker.WinFormsClient.MetroClient.Components.Modules.Table.CardControl
{
    public partial class CardControl : BB.Common.WinForms.MetroUserControl
    {
        public CardControl()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);

            InitializeComponent();          
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (RankLabel != null && SuitLabel != null)
            {
                RankLabel.Width = (int)(SuitLabel.Width / 2.31);

                RankLabel.Height = (int)(SuitLabel.Height / 4.0);

                RankLabel.Location = new Point(SuitLabel.Width - RankLabel.Width,
                    SuitLabel.Height - RankLabel.Height);

                Invalidate();
            }
        }
    }
}
