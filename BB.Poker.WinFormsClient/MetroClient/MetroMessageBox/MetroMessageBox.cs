using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BB.Common.WinForms;

namespace BB.Poker.WinFormsClient
{
    public static class MetroMessageBox
    {
        private static MetroMessageBoxForm MessageBox;

        static MetroMessageBox()
        {
            MessageBox = new MetroMessageBoxForm();

            MessageBox.StartPosition = FormStartPosition.CenterScreen;
        }

        public static void SetOwner(Form owner)
        {
            MessageBox.UpdateProperty<Form>("Owner", owner);

            MessageBox.UpdateProperty<FormStartPosition>("StartPosition", FormStartPosition.CenterParent);
        }

        public static DialogResult Show(string message)
        {
            return MessageBox.ShowDialog(message);
        }

        public static DialogResult Show(string message, Form owner)
        {
            SetOwner(owner);

            return MessageBox.ShowDialog(message);
        }
    }
}
