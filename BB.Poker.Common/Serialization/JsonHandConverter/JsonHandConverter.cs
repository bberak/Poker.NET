using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BB.Poker.Common
{
    public class JsonHandConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Hand).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);          

            Hand hand = new Hand();

            Rank rank = (Rank)jsonObject["HighCard"].Value<int>("Rank");
            Suit suit = (Suit)jsonObject["HighCard"].Value<int>("Suit");
            Card highCard = new Card(rank, suit);
            Combination combination = (Combination)jsonObject["BestCombination"].Value<int>();

            hand.BestCombination = combination;
            hand.HighCard = highCard;
            
            var cards = jsonObject["Cards"].Children();
           
            foreach (JToken jt in cards)
            {
                Rank r = (Rank)jt["Rank"].Value<int>();
                Suit s = (Suit)jt["Suit"].Value<int>();
                Card c = new Card(r, s);
                hand.Add(c);
            }
           
            return hand;
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (value is Hand)
            {
                Hand hand = (Hand)value;

                writer.WriteStartObject();
                writer.WritePropertyName("Cards");

                writer.WriteStartArray();

                foreach (Card c in hand)
                {
                    writer.WriteStartObject();

                    writer.WritePropertyName("Rank");
                    writer.WriteValue((int)c.Rank);
                    writer.WritePropertyName("Suit");
                    writer.WriteValue((int)c.Suit);

                    writer.WriteEndObject();
                }

                writer.WriteEndArray();

                writer.WritePropertyName("HighCard");
                writer.WriteStartObject();

                writer.WritePropertyName("Rank");
                writer.WriteValue((int)hand.HighCard.Rank);

                writer.WritePropertyName("Suit");
                writer.WriteValue((int)hand.HighCard.Suit);

                writer.WriteEndObject();

                writer.WritePropertyName("BestCombination");
                writer.WriteValue((int)hand.BestCombination);

                writer.WriteEndObject();
            }
            else
            {
                throw new Exception("Unexpected value when converting Hand.");
            }
        }
    }
}
