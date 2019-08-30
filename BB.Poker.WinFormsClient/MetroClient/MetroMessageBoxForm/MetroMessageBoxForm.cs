using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BB.Common.WinForms;

namespace BB.Poker.WinFormsClient
{
    public partial class MetroMessageBoxForm : MetroForm
    {
        public MetroMessageBoxForm()
        {
            InitializeComponent();

            RegisterForDragFeedback(MessagePanel);
            RegisterForDragFeedback(MessageLabel);
        }

        protected override void OnExitButtonClicked(object sender, EventArgs e)
        {
            //-- Do nothing
        }

        public DialogResult ShowDialog(string message)
        {
            MessageLabel.UpdateProperty<string>("Text", message);

            DialogResult res = DialogResult.None;

            if (Owner != null)
            {
                Owner.Invoke(delegate()
                {
                    res = this.ShowDialog();
                });
            }
            else
                res = this.ShowDialog();

            return res;
        }
    }
}
