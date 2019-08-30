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
    public partial class VerifyClientModuleControl : MetroUserControl
    {
        public VerifyClientModuleControl()
        {
            InitializeComponent();

            UpdateButton.Click += new EventHandler(UpdateButton_Click);
            ExitButton.Click += new EventHandler(ExitButton_Click);
        }

        void ExitButton_Click(object sender, EventArgs e)
        {
            ExitButtonClicked.Fire(sender, e);
        }

        void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateButtonClicked.Fire(sender, e);
        }

        public void ShowButtons()
        {
            UpdateButton.UpdateProperty<bool>("Visible", true);
            ExitButton.UpdateProperty<bool>("Visible", true);
        }

        public void HideButtons()
        {
            UpdateButton.UpdateProperty<bool>("Visible", false);
            ExitButton.UpdateProperty<bool>("Visible", false);
        }

        public void ChangeStatus(string newStatus)
        {
            StatusLabel.UpdateProperty<string>("Text", newStatus);
        }

        public void SetProgressStyle(MetroProgressBarStyle style)
        {
            ProgressBar.UpdateProperty<MetroProgressBarStyle>("BarStyle", style);
        }

        public void UpdateProgressBar(int newValue)
        {
            SetProgressStyle(MetroProgressBarStyle.Standard);
            ProgressBar.UpdateProperty<int>("Value", newValue);
        }

        public event EventHandler UpdateButtonClicked;

        public event EventHandler ExitButtonClicked;
    }
}
