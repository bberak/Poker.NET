using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace BB.Poker.Logic
{
    public class IPTools
    {
        //-- http://stackoverflow.com/questions/2727609/best-way-to-create-ipendpoint-from-string
        public static IPEndPoint IPEndPointFromString(string endpointstring)
        {
            string[] values = endpointstring.Split(new char[] { ':' });

            if (2 > values.Length)
            {
                throw new FormatException("Invalid endpoint format");
            }

            IPAddress ipaddress;
            string ipaddressstring = string.Join(":", values.Take(values.Length - 1).ToArray());
            if (!IPAddress.TryParse(ipaddressstring, out ipaddress))
            {
                throw new FormatException(string.Format("Invalid endpoint ipaddress '{0}'", ipaddressstring));
            }

            int port;
            if (!int.TryParse(values[values.Length - 1], out port)
             || port < IPEndPoint.MinPort
             || port > IPEndPoint.MaxPort)
            {
                throw new FormatException(string.Format("Invalid end point port '{0}'", values[values.Length - 1]));
            }

            return new IPEndPoint(ipaddress, port);
        }
    }
}
