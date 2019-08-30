using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BB.Poker.Common
{
    public class JsonSerializer : ISerialize
    {
        public JsonSerializer() 
        {
            
        }

        #region ISerialize Members

        public T GetObject<T>(byte[] data)
        {
            string jsonString = Encoding.Default.GetString(data);

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public byte[] GetBytes(object dataObject)
        {
            string jsonString = JsonConvert.SerializeObject(dataObject);

            return Encoding.Default.GetBytes(jsonString);
        }

        #endregion
    }
}
