using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralShareDB_Client.DB
{
    public class DatabaseAddress
    {
        public string Host { get; private set; }
        public int Port { get; private set; }

        public DatabaseAddress(string host, int port)
        {
            this.Host = host;
            this.Port = port;
        }

        public string GetFullAddress()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("mongodb://");
            sb.Append(this.Host);
            sb.Append("/");
            sb.Append(this.Port);
            return sb.ToString();
        }
    }
}