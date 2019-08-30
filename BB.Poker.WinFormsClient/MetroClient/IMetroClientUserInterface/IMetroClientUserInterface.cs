using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BB.Common.WinForms;

namespace BB.Poker.WinFormsClient
{
    public interface IMetroClientUserInterface
    {
        void Show();

        void Activate();

        bool Focus();

        void RegisterForDragFeedback(Control control);

        void ShowSignOutButton(string playerName);

        void ShowTitleLabel();

        Form GetForm();

        MetroFlowMenu FlowMenu { get; }

        bool Visible { get; set; }

        FormWindowState WindowState { get; set; }

        event EventHandler ExitButtonClicked;

        event EventHandler SignOutButtonClicked;
    }
}
