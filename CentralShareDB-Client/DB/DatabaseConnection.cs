using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CentralShareDB_Client.DB
{
    public sealed class DatabaseConnection
    {
        private static DatabaseConnection instance = null;

        public static DatabaseConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseConnection();
                }
                return instance;
            }
        }

        private MongoClient client;
        public DatabaseAddress Address { get; set; }

        private DatabaseConnection()
        {
        }

        public void Connect()
        {
            this.client = new MongoClient(Address.GetFullAddress());
        }

        public bool Test()
        {
            if (this.client != null)
            {
                var database = client.GetDatabase("centralsharedb");
                return database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);
            }
            else
            {
                return false;
            }
        }
    }
}
