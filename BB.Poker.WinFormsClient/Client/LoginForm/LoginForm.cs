using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public partial class LoginForm : Form
    {
        public Account UserAccount { get; protected set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            m_txtPassword.Text = string.Empty;
            m_txtName.Text = string.Empty;
            UserAccount = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void m_btnLogin_Click(object sender, EventArgs e)
        {
            UserAccount  = new Account(m_txtName.Text, m_txtPassword.Text, 3000);
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
