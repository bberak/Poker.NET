using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    public class Account
    {
        public string PlayerName { get; protected set; }
        public double Chips { get; set; }

        public Account(string name, string password, double chips)
        {
            PlayerName = name;
            Chips = chips;
        }
    }
}
