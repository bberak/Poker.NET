using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BB.Poker.WinFormsClient
{
    public partial class ChooseSeatForm : Form
    {
        public int? ChosenSeat { get; protected set; }
        public ChooseSeatForm()
        {
            InitializeComponent();
        }

        public void UpdateControls(int[] availableseats)
        {
            ChosenSeat = null;
            m_cbxSeats.Items.Clear();

            foreach (int i in availableseats)
            {
                m_cbxSeats.Items.Add(i);
            }

            if (m_cbxSeats.Items.Count > 0)
                m_cbxSeats.SelectedIndex = 0;
        }

        private void m_cbxSeats_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChosenSeat = (int?)m_cbxSeats.SelectedItem;
        }

        private void m_btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
