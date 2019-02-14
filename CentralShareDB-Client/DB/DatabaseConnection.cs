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
                var database = client.GetDatabase(Properties.Settings.Default.mongodb_database);
                return database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);
            }
            else
            {
                return false;
            }
        }

        public bool HasDatabase(string database)
        {
            if (this.client != null)
            {
                var databases = client.ListDatabaseNames();
                if (databases.ToList().Contains(database))
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public bool HasDatabaseCollection(string database, string collection)
        {
            if (this.client != null)
            {
                var db = client.GetDatabase(database);
                var cls = db.ListCollectionNames();
                if (cls.ToList().Contains(collection))
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public void CreateCollection(string name)
        {
            if (this.client != null)
            {
                var database = client.GetDatabase(Properties.Settings.Default.mongodb_database);
                database.CreateCollection(name);
            }
        }
    }
}