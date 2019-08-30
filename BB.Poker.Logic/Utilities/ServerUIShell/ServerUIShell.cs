using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BB.Poker.Common;
using BB.Common.WinForms;

namespace BB.Poker.Logic
{
    public partial class ServerUIShell : Form
    {
        public static TextBox Console { get; protected set; }

        private static bool isMouseDownOnConsole;

        public ServerUIShell()
        {
            InitializeComponent();

            Console = console;
        }

        public static void WriteLine(string newText)
        {
            if (Console == null) throw new NullReferenceException("Console cannot be null. You need instantiate an instance of ServerUISHell or a dervied class.");
            Console.ExecuteMethod("AppendText", typeof(string).ToArray(), new object[] { newText + Environment.NewLine });

            //-- Only set and scroll to the caret if the user is not holding onto the scroll bars etc.
            if (isMouseDownOnConsole == false)
            {
                Console.UpdateProperty<int>("SelectionStart", Console.Text.Length);
                Console.Execute(new Action(Console.ScrollToCaret));
            }
        }

        public static void WriteLine()
        {
            WriteLine(string.Empty);
        }

        protected virtual void OnStart()
        {
        }

        protected virtual void OnExit()
        {
        }

        private void ServerUIShell_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnExit();
        }

        private void console_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDownOnConsole = true;
        }

        private void console_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDownOnConsole = false;
        }

        private void ServerUIShell_Shown(object sender, EventArgs e)
        {
            OnStart();
        }
    }
}
