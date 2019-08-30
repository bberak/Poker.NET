using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    [Serializable]
    public class TableSummary
    {    
        public TableState State { get; set; }
        public Card[] TurnRiverOrFlop { get; set; }
        public double PotValue { get; set; }
        public int DealerButtonPosition { get; set; }
        public int MaxPlayers { get; set; }
        public int PlayerCount { get; set; }
        public double SmallBlind { get; set; }
        public double BigBlind { get; set; }
        public string TableId { get; set; }
        public string Description { get; set; }
        public int[] AvailableSeats { get; set; }
        public int MaxDecisionTime { get; set; }
        public bool IsChatEnabled { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Table Id: " + TableId + Environment.NewLine);
            sb.Append("Dealer Button Position: " + DealerButtonPosition + Environment.NewLine);
            sb.Append("Community Cards: " + TurnRiverOrFlop.ToString() + Environment.NewLine);
            sb.Append("Pot Value: $" + PotValue + Environment.NewLine);
            sb.Append("Blinds: $" + SmallBlind + "/$" + BigBlind + Environment.NewLine);
            sb.Append("Players: " + PlayerCount + "/" + MaxPlayers + Environment.NewLine);
            sb.Append("Table State: " + State.ToString());

            string seats = String.Empty;
            foreach (int seat in AvailableSeats)
            {
                seats += seat.ToString() + "-";
            }
            sb.Append("Available Seats: " + seats.TrimEnd(new char[]{'-'}));
            
            return sb.ToString();
        }
    }
}
