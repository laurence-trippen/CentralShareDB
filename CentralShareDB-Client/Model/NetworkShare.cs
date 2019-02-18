using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralShareDB_Client.Model
{
    public class NetworkShare
    {
        public bool IsChecked { get; set; }
        public bool IsMounted { get; set; }
        public string ShareLetter { get; set; }
        public string SharePath { get; set; }
        public string DisplayMember
        {
            get
            {
                return (IsMounted ? "[Mounted]" : "[Not Mounted]") + "\t" + "(" + ShareLetter + ":)\t" + SharePath;
            }
        }

        public NetworkShare(string letter, string path)
        {
            this.ShareLetter = letter;
            this.SharePath = path;
            this.IsMounted = false;
        }

        public NetworkShare(string letter, string path, bool mounted)
        {
            this.ShareLetter = letter;
            this.SharePath = path;
            this.IsMounted = mounted;
        }
    }
}