using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BB.Poker.Common;
using BB.Common.WinForms;

namespace BB.Poker.WinFormsClient
{
    public partial class LobbyModuleControl : MetroUserControl
    {
        public LobbyModuleControl()
        {
            InitializeComponent();

            //-- MetroScrollBar setup.
            TableScrollBar.BindTo(InnerTablePanel, OutterTablePanel);

            //-- Event to resize the table rows (nothing to do with the MetroScrollBar).
            this.OutterTablePanel.Resize += new EventHandler(OutterTablePanel_Resize);
        }

        private void OutterTablePanel_Resize(object sender, EventArgs e)
        {
            InnerTablePanel.Width = OutterTablePanel.DisplayRectangle.Width - TableScrollBar.Width;
        }

        private void RefreshListButton_Click(object sender, EventArgs e)
        {
            StatusLabel.Visible = true;

            RefreshButtonClicked.Fire(sender, e);
        }

        private void ChangeBorderColorOfLastItem(bool applyChange)
        {
            if (InnerTablePanel.Controls.Count > 0)
            {
                LobbyListItemControl last = (LobbyListItemControl)InnerTablePanel.Controls[InnerTablePanel.Controls.Count - 1];
                last.ChangeBorderColor(applyChange);
            }
        }

        public void ClearTableList()
        {
            InnerTablePanel.Invoke(delegate()
            {
                InnerTablePanel.Controls.Clear();
            });
        }

        public void AppendToTableList(TableSummary[] summaries)
        {
            ChangeBorderColorOfLastItem(false);

            int count = InnerTablePanel.Controls.Count;

            InnerTablePanel.Invoke(delegate()
            {
                StatusLabel.Visible = false;

                foreach (TableSummary ts in summaries)
                {
                    LobbyListItemControl item = new LobbyListItemControl();
                    item.LoadFrom(ts);
                    item.Left = 0;
                    item.Top = count * item.Height;
                    item.Width = InnerTablePanel.ClientRectangle.Width;
                    item.ItemClicked += new EventHandler<TableItemClickedEventArgs>(LobbyList_ItemClicked);
                    InnerTablePanel.Controls.Add(item);               
                    count++;
                }
            });

            ChangeBorderColorOfLastItem(true);
        }

        void LobbyList_ItemClicked(object sender, TableItemClickedEventArgs e)
        {
            TableItemClicked.Fire<TableItemClickedEventArgs>(sender, e);
        }

        public void FocusOnScrollBar()
        {
            TableScrollBar.Invoke(delegate()
            {
                TableScrollBar.Focus();
            });
        }

        public event EventHandler<TableItemClickedEventArgs> TableItemClicked;

        public event EventHandler RefreshButtonClicked;
    }
}
