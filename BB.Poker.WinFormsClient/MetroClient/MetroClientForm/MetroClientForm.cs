using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BB.Common.WinForms;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public partial class MetroClientForm : MetroForm, IMetroClientUserInterface
    {
        public MetroFlowMenu FlowMenu
        {
            get { return MyMenu; }
        }

        public MetroClientForm()
        {
            InitializeComponent();

            RegisterForDragFeedback(TitleLabel);
            RegisterForDragFeedback(MyMenu);
            RegisterForDragFeedback(SignOutLabel);
        }

        public Form GetForm()
        {
            return this;
        }

        public void ShowSignOutButton(string playerName)
        {
            SignOutLabel.Invoke(delegate()
            {
                SignOutLabel.Text = "Sign out: " + playerName;
                SignOutLabel.BringToFront();
            });
        }

        public void ShowTitleLabel()
        {
            TitleLabel.Invoke(delegate()
            {
                TitleLabel.BringToFront();
            });
        }

        protected override void OnExitButtonClicked(object sender, EventArgs e)
        {
            ExitButtonClicked.Fire(sender, e);
        }

        private void SignOutLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignOutLabel.Text = string.Empty;
            SignOutButtonClicked.Fire(sender, e);
        }

        public event EventHandler ExitButtonClicked;

        public event EventHandler SignOutButtonClicked;
    }
}
