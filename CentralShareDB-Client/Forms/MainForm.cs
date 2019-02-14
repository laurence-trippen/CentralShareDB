using CentralShareDB_Client.DB;
using CentralShareDB_Client.Forms;
using CentralShareDB_Client.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CentralShareDB_Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.TestConnection();
            this.LoadShares();
        }

        private void TestConnection()
        {
            string host = Properties.Settings.Default.mongodb_host;
            int port = Properties.Settings.Default.mongodb_port;

            DatabaseAddress address = new DatabaseAddress(host, port);
            DatabaseConnection connection = DatabaseConnection.Instance;

            connection.Address = address;
            connection.Connect();
            bool isReachable = connection.Test();

            if (!isReachable)
            {
                MessageBox.Show("MongoDB is not reachable. Please configure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ConnectionForm connectionForm = new ConnectionForm();
                connectionForm.ShowDialog();
            }
            else
            {
                if (!connection.HasDatabaseCollection(Properties.Settings.Default.mongodb_database, Properties.Settings.Default.mongodb_collection_shares))
                {
                    connection.CreateCollection(Properties.Settings.Default.mongodb_collection_shares);
                }
            }
        }

        private void LoadShares()
        {
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

                        NetworkShares.Instance.Shares.Add(new NetworkShare(shareLetter, sharePath));
                    }
                }
            }

            sharesListBox.DataSource = NetworkShares.Instance.Shares;
            sharesListBox.DisplayMember = "DisplayMember";
            sharesListBox.ValueMember = "IsChecked";
        }

        private void addShareBtn_Click(object sender, EventArgs e)
        {
            // DriveSettings.MapNetworkDrive("Z", @"\\192.168.1.118\lt-nas-01-productive");
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionForm cf = new ConnectionForm();
            cf.ShowDialog();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void testConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isReachable = DatabaseConnection.Instance.Test();

            if (!isReachable)
            {
                MessageBox.Show("MongoDB is not reachable. Please configure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ConnectionForm connectionForm = new ConnectionForm();
                connectionForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("MongoDB is reachable.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void addNewShareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewShareForm nsf = new NewShareForm();
            nsf.ShowDialog();
            sharesListBox.Update();
        }

        private void deleteShareBtn_Click(object sender, EventArgs e)
        {
            NetworkShare[] shareBuffer = new NetworkShare[sharesListBox.SelectedItems.Count];
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Do you want to delete these entries?\n");

            int i = 0;
            foreach (Object item in sharesListBox.SelectedItems)
            {
                NetworkShare share = (NetworkShare)item;
                sb.AppendLine("(" + share.ShareLetter + ":) " + share.SharePath);
                shareBuffer[i] = share;
                i++;
            }

            DialogResult result = MessageBox.Show(sb.ToString(), "Question",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {                
                foreach (NetworkShare share in shareBuffer)
                {
                    NetworkShares.Instance.Shares.Remove(share);
                }
            }
        }
    }
}