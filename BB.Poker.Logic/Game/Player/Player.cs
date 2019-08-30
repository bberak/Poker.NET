using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;
using Newtonsoft.Json;
using BB.Poker.Common;

namespace BB.Poker.Logic
{
    [JsonObject(MemberSerialization.OptOut)]
    [Serializable]
    public class Player
    {
        public CardCollection Cards { get; protected set; }

        public string Name { get; protected set; }

        public double Chips { get; protected set; }

        public string GatewayServerId { get; protected set; }

        public PlayerState State { get; set; }

        [JsonIgnore]
        public Card Card1 { get { return Cards[0]; } }

        [JsonIgnore]
        public Card Card2 { get { return Cards[1]; } }

        public Player(string name, double chips, PlayerState state, string gatewayServerId)
        {
            Name = name;
            Chips = chips;
            State = state;
            GatewayServerId = gatewayServerId;
            Cards = new CardCollection();
        }

        //-- This constructor is useful for local testing purposes.
        public Player(string name, double chips)
            :this(name, chips, PlayerState.Playing, string.Empty)
        {

        }

        public double HandOverChips(double betAmount)
        {
            Chips -= betAmount;

            return betAmount;
        }

        public double AllIn()
        {
            double everything = Chips;

            Chips -= everything;

            return everything;
        }

        public void PocketWinnings(double winnings)
        {
            Chips += winnings;
        }

        public PlayerSummary GetSummary(int pos)
        {
            PlayerSummary ps = new PlayerSummary();
            ps.Name = Name;
            ps.Chips = Chips;
            ps.Position = pos;
            ps.State = State;

            return ps;
        }

        public override bool Equals(object obj)
        {
            if (obj is Player)
            {
                Player other = (Player)obj;

                if (other.Name.Equals(this.Name))
                    return true;
                else
                    return false;
            }

            throw new ArgumentException("Object is not a Player");
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name + ": " + Chips + ", " + State.ToString();
        }

        public static Player GetTempPlayer(string name, string gatewayServerId)
        {
            return new Player(name, 0.0, PlayerState.Bust, gatewayServerId);
        }

        public static Player GetTempPlayer(string name)
        {
            return GetTempPlayer(name, string.Empty);
        }
    }
}
