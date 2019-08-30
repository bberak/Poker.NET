using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Common
{
    public class TextFormatter
    {
        public static string GetString(Card[] cards)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Card c in cards)
                sb.Append(c.ToString() + ", ");

            return sb.ToString().Trim().TrimEnd(',');
        }
    }
}
