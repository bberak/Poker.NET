using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BB.Poker.Common
{
    public class JsonCardConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Card).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);

            Rank r = (Rank)jsonObject["Rank"].Value<int>();
            Suit s = (Suit)jsonObject["Suit"].Value<int>();

            return new Card(r, s);
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (value is Card)
            {
                Card c = (Card)value;
                writer.WriteStartObject();
                    writer.WritePropertyName("Rank");
                    writer.WriteValue((int)c.Rank);
                    writer.WritePropertyName("Suit");
                    writer.WriteValue((int)c.Suit);
                writer.WriteEndObject();
            }
            else
            {
                throw new Exception("Unexpected value when converting Card.");
            }
        }
    }
}
