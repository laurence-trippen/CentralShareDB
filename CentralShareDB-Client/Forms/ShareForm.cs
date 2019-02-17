using CentralShareDB_Client.DB;
using CentralShareDB_Client.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentralShareDB_Client.Forms
{
    public partial class ShareForm : Form
    {
        private NetworkShare editShare;

        public ShareForm()
        {
            InitializeComponent();
            this.LoadDriveLetters();
        }

        public ShareForm(NetworkShare share)
        {
            InitializeComponent();
            this.LoadDriveLetters();
            this.editShare = share;
            this.newShareBtn.Text = this.Text = "Edit Share";
            this.pathTbx.Text = share.SharePath;
            this.driveLettersCbx.SelectedIndex = this.driveLettersCbx.FindString(share.ShareLetter);
        }

        private void LoadDriveLetters()
        {
            List<char> driveLetters = new List<char>(26); // Allocate space for alphabet
            for (int i = 65; i < 91; i++) // increment from ASCII values for A-Z
            {
                driveLetters.Add(Convert.ToChar(i)); // Add uppercase letters to possible drive letters
            }

            foreach (string drive in Directory.GetLogicalDrives())
            {
                driveLetters.Remove(drive[0]); // removed used drive letters from possible drive letters
            }

            foreach (char drive in driveLetters)
            {
                this.driveLettersCbx.Items.Add(drive); // add unused drive letters to the combo box
            }

            this.driveLettersCbx.SelectedIndex = 0;
        }

        private void newShareBtn_Click(object sender, EventArgs e)
        {
            string driveLetter = this.driveLettersCbx.SelectedItem.ToString();
            string path = this.pathTbx.Text;

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Path is not set!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // New Share
                if (editShare == null)
                {
                    NetworkShare share = new NetworkShare(driveLetter, path);
                    NetworkShares.Instance.Shares.Add(share);

                    var document = new BsonDocument
                    {
                        {"share_letter", new BsonString(driveLetter)},
                        {"share_path", new BsonString(path)}
                    };

                    DatabaseConnection connection = DatabaseConnection.Instance;
                    var database = connection.Client.GetDatabase(Properties.Settings.Default.mongodb_database);
                    var collection = database.GetCollection<BsonDocument>(Properties.Settings.Default.mongodb_collection_shares);
                    collection.InsertOne(document);

                    this.Close();
                }
                else // Edit Share
                {
                    NetworkShares shares = NetworkShares.Instance;
                    int index = shares.Shares.IndexOf(editShare);
                    string editLetter = editShare.ShareLetter;
                    editShare.ShareLetter = driveLetter;
                    editShare.SharePath = path;
                    shares.Shares[index] = editShare;

                    DatabaseConnection connection = DatabaseConnection.Instance;
                    var database = connection.Client.GetDatabase(Properties.Settings.Default.mongodb_database);
                    var collection = database.GetCollection<BsonDocument>(Properties.Settings.Default.mongodb_collection_shares);
                    var filter = Builders<BsonDocument>.Filter.Eq("share_letter", editLetter);
                    var update = Builders<BsonDocument>.Update
                        .Set("share_letter", driveLetter)
                        .Set("share_path", path);
                    var result = collection.UpdateOne(filter, update);

                    this.Close();
                }
            }
        }
    }
}