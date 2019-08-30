using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BB.Common.WinForms;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public partial class LoginModuleControl : MetroUserControl
    {
        private bool HasUsernameBeenFocused;
        private bool HasPasswordBeenFocused;

        public LoginModuleControl()
        {
            InitializeComponent();

            SignInButton.Click += new EventHandler(SignInButton_Click);
            UsernameTextBox.GotFocus += new EventHandler(UsernameTextBox_GotFocus);
            PasswordTextBox.GotFocus += new EventHandler(PasswordTextBox_GotFocus);
        }

        void PasswordTextBox_GotFocus(object sender, EventArgs e)
        {
            if (!HasPasswordBeenFocused)
            {
                PasswordTextBox.UpdateProperty<string>("Text", string.Empty);
                PasswordTextBox.UpdateProperty<char>("PasswordChar", '*');
            }

            HasPasswordBeenFocused = true;
        }

        void UsernameTextBox_GotFocus(object sender, EventArgs e)
        {
            if (!HasUsernameBeenFocused)
                UsernameTextBox.UpdateProperty<string>("Text", string.Empty);

            HasUsernameBeenFocused = true;
        }

        void SignInButton_Click(object sender, EventArgs e)
        {
            if (HasUsernameBeenFocused && HasPasswordBeenFocused)
                SignInButtonClicked.Fire(sender, new SignInEventArgs(UsernameTextBox.Text, PasswordTextBox.Text));
        }

        public void ShowButtons()
        {
            SignInButton.UpdateProperty<bool>("Visible", true);
        }

        public void HideButtons()
        {
            SignInButton.UpdateProperty<bool>("Visible", false);
        }

        public void ChangeStatus(string newStatus)
        {
            StatusLabel.UpdateProperty<string>("Text", newStatus);
        }

        public event EventHandler<SignInEventArgs> SignInButtonClicked;

        public class SignInEventArgs : EventArgs
        {
            public string Username { get; protected set; }

            public string Password { get; protected set; }

            public SignInEventArgs(string username, string password)
            {
                Username = username;

                Password = password;
            }
        }
    }
}
