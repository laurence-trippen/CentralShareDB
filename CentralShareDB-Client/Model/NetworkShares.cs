using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralShareDB_Client.Model
{
    public class NetworkShares
    {
        private static NetworkShares instance = null;

        public static NetworkShares Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NetworkShares();
                }
                return instance;
            }
        }

        public BindingList<NetworkShare> Shares { get; private set; }

        private NetworkShares()
        {
            this.Shares = new BindingList<NetworkShare>();
        }
    }
}