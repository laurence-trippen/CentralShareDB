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
                    var database = connection.Client.GetDatabase(Properties.Settings.Default.mongodb_database);
                    var sharesCollection = database.GetCollection<BsonDocument>(Properties.Settings.Default.mongodb_collection_shares);
                    /*
                    var options = new CreateIndexOptions() { Unique = true };
                    var field = new StringFieldDefinition<BsonDocument>("string_letter");
                    var index = new IndexKeysDefinitionBuilder<BsonDocument>().Ascending(field);
                    */
                    // db.network_shares.createIndex({ "share_letter": 1}, { unique: true});
                    // var keys = Builders<BsonDocument>.IndexKeys.Ascending("i");
                    // collection.Indexes.CreateOne(keys);

                    sharesCollection.Indexes.CreateOne("{share_letter : 1}", new CreateIndexOptions()
                    {
                        Unique = true
                    });
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
            foreach (Object item in sharesListBox.SelectedItems)
            {
                NetworkShare share = (NetworkShare)item;
                if (NetworkDrives.IsDriveMapped(share.ShareLetter))
                {
                    MessageBox.Show("Letter Drive (" + share.ShareLetter + ":) is already mounted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    NetworkDrives.MapNetworkDrive(share.ShareLetter, share.SharePath);
                }
            }
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
            ShareForm nsf = new ShareForm();
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

                    DatabaseConnection connection = DatabaseConnection.Instance;
                    var database = connection.Client.GetDatabase(Properties.Settings.Default.mongodb_database);
                    var collection = database.GetCollection<BsonDocument>(Properties.Settings.Default.mongodb_collection_shares);
                    collection.DeleteOne(Builders<BsonDocument>.Filter.Eq("share_letter", share.ShareLetter));
                }
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(1000, "Info", "CentralShareDB runs in the background.", ToolTipIcon.Info);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetworkShares.Instance.Sync();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            NetworkShares.Instance.Sync();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if (e.KeyCode == Keys.F5)
            {
                MessageBox.Show("Test");
                NetworkShares.Instance.Sync();
            }
            */
        }

        private void editShareBtn_Click(object sender, EventArgs e)
        {
            NetworkShare[] shareBuffer = new NetworkShare[sharesListBox.SelectedItems.Count];

            int i = 0;
            foreach (Object item in sharesListBox.SelectedItems)
            {
                NetworkShare share = (NetworkShare)item;
                shareBuffer[i] = share;
                i++;
            }

            foreach (NetworkShare share in shareBuffer)
            {
                ShareForm sf = new ShareForm(share);
                sf.ShowDialog();
            }
        }

        private void unmountBtn_Click(object sender, EventArgs e)
        {
            foreach (Object item in sharesListBox.SelectedItems)
            {
                NetworkShare share = (NetworkShare)item;
                if (NetworkDrives.IsDriveMapped(share.ShareLetter))
                {
                    NetworkDrives.DisconnectNetworkDrive(share.ShareLetter, false);
                }
                else
                {
                    MessageBox.Show("You can not unmount an unmounted drive.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}