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
    public partial class ConnectionModuleControl : MetroUserControl
    {
        public ConnectionModuleControl()
        {
            InitializeComponent();

            RetryButton.Click += new EventHandler(RetryButton_Click);
            ExitButton.Click += new EventHandler(ExitButton_Click);
        }

        void ExitButton_Click(object sender, EventArgs e)
        {
            ExitButtonClicked.Fire(sender, e);
        }

        void RetryButton_Click(object sender, EventArgs e)
        {
            RetryButtonClicked.Fire(sender, e);
        }

        public void ShowButtons()
        {
            RetryButton.UpdateProperty<bool>("Visible", true);
            ExitButton.UpdateProperty<bool>("Visible", true);
        }

        public void HideButtons()
        {
            RetryButton.UpdateProperty<bool>("Visible", false);
            ExitButton.UpdateProperty<bool>("Visible", false);
        }

        public void ChangeStatus(string newStatus)
        {
            StatusLabel.UpdateProperty<string>("Text", newStatus);
        }

        public void SetProgressStyle(MetroProgressBarStyle style)
        {
            ConnectionProgressBar.UpdateProperty<MetroProgressBarStyle>("BarStyle", style);
        }

        public void UpdateProgressBar(int newValue)
        {
            SetProgressStyle(MetroProgressBarStyle.Standard);
            ConnectionProgressBar.UpdateProperty<int>("Value", newValue);
        }

        public event EventHandler RetryButtonClicked;

        public event EventHandler ExitButtonClicked;
    }
}
