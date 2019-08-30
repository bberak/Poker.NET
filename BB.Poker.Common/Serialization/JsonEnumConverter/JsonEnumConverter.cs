using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BB.Poker.Common
{
    public class JsonEnumConverter<T> : JsonConverter where T : struct
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            string e = reader.Value.ToString();
            return Enum.Parse(typeof(T), e, true);
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (value is T)
            {
                T e = (T)value;
                writer.WriteValue(Convert.ToInt32(e));
            }
            else
            {
                throw new Exception("Unexpected value when converting enumeration.");
            }
        }
    }
}
