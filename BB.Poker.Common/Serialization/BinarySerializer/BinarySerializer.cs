using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace BB.Poker.Common
{
    public class BinarySerializer : ISerialize
    {
        private IFormatter m_ifmFormatter;

        public BinarySerializer()
        {
            m_ifmFormatter = new BinaryFormatter();
        }

        public T GetObject<T>(byte[] data)
        {
            MemoryStream ms = null;
            object deserializedObj;

            try
            {
                ms = new MemoryStream();

                ms.Write(data, 0, data.Length);

                ms.Seek(0, SeekOrigin.Begin);
               
                deserializedObj = m_ifmFormatter.Deserialize(ms);
            }
            finally
            {
                ms.Close();
            }

            return (T)deserializedObj;
        }

        public byte[] GetBytes(object sObject)
        {
            MemoryStream ms = null;
            byte[] data;

            try
            {
                ms = new MemoryStream();

                m_ifmFormatter.Serialize(ms, sObject);

                data = ms.ToArray();

            }
            finally
            {
                ms.Close();
            }

            return data;
        }     
    }
}
