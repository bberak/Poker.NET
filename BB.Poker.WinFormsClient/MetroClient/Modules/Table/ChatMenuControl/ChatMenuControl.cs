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
    public partial class ChatMenuControl : MetroSlidingControl
    {
        private bool HasTextBoxBeenFocused;
        private MetroScrollBar ScrollBar;

        public ChatMenuControl()
        {
            InitializeComponent();

            MessageTextBox.KeyPress +=new KeyPressEventHandler(MessageTextBox_KeyPress);
            MessageTextBox.GotFocus += new EventHandler(MessageTextBox_GotFocus);
            MessagesLabel.SizeChanged += new EventHandler(MessagesLabel_SizeChanged);
        }

        private void MessagesLabel_SizeChanged(object sender, EventArgs e)
        {
            if (MessagesLabel.Height > ScrollPanel.Height)
            {
                ScrollBar = new MetroScrollBar();
                ScrollBar.Height = ScrollPanel.ClientRectangle.Height;
                ScrollBar.Location = new Point(ScrollPanel.ClientRectangle.Width - ScrollBar.Width, 0);
                ScrollBar.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
                ResizeMessagesLabel();

                ScrollPanel.Controls.Add(ScrollBar);
                ScrollBar.BindTo(MessagesLabel, ScrollPanel);
            }
        }

        private void MessageTextBox_GotFocus(object sender, EventArgs e)
        {
            if (!HasTextBoxBeenFocused)
            {
                MessageTextBox.Text = string.Empty;
                HasTextBoxBeenFocused = true;
            }
        }

        private void MessageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // The keypressed method uses the KeyChar property to check 
            // whether the ENTER key is pressed. 

            // If the ENTER key is pressed, the Handled property is set to true, 
            // to indicate the event is handled.
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                MessagesLabel.Text += Environment.NewLine + "You: " + MessageTextBox.Text;
                MessageTextBox.Text = string.Empty;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            ResizeMessagesLabel();
        }

        private void ResizeMessagesLabel()
        {
            if (MessagesLabel != null)
            {
                if (ScrollBar != null)
                    MessagesLabel.MaximumSize = new Size(ScrollPanel.ClientRectangle.Width - ScrollBar.Width, 0);
                else
                    MessagesLabel.MaximumSize = new Size(ScrollPanel.ClientRectangle.Width, 0);
            }
        }
    }
}
