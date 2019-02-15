using CentralShareDB_Client.DB;
using MongoDB.Bson;
using MongoDB.Driver;
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

        public void Sync()
        {
            Shares.Clear();

            DatabaseConnection connection = DatabaseConnection.Instance;
            var database = connection.Client.GetDatabase(Properties.Settings.Default.mongodb_database);
            var sharesCollection = database.GetCollection<BsonDocument>(Properties.Settings.Default.mongodb_collection_shares);

            using (IAsyncCursor<BsonDocument> cursor = sharesCollection.FindSync(new BsonDocument()))
            {
                while (cursor.MoveNext())
                {
                    IEnumerable<BsonDocument> batch = cursor.Current;
                    foreach (BsonDocument document in batch)
                    {
                        string shareLetter = document["share_letter"].AsString;
                        string sharePath = document["share_path"].AsString;

                        Shares.Add(new NetworkShare(shareLetter, sharePath));
                    }
                }
            }
        }
    }
}