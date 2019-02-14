using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentralShareDB_Client
{
    public partial class ConnectionForm : Form
    {
        public ConnectionForm()
        {
            InitializeComponent();
            this.hostTbx.Text = Properties.Settings.Default.mongodb_host;
            this.portNud.Value = Properties.Settings.Default.mongodb_port;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            if (!IPAddress.TryParse(this.hostTbx.Text, out ip))
            {
                MessageBox.Show("IPv4 Adress is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.hostTbx.SelectAll();
                this.hostTbx.Focus();
            }
            else
            {
                Properties.Settings.Default.mongodb_host = this.hostTbx.Text;
                Properties.Settings.Default.mongodb_port = (int) this.portNud.Value;
                Properties.Settings.Default.Save();
                this.Close();
            }
        }

        private void testConnectionBtn_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("mongodb://");
            sb.Append(this.hostTbx.Text);
            sb.Append("/");
            sb.Append(this.portNud.Value);

            string connection = sb.ToString();

            var client = new MongoClient(connection);
            var database = client.GetDatabase("centralsharedb");
            bool isMongoAlive = database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);

            if (isMongoAlive)
            {
                MessageBox.Show("MongoDB is reachable.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("MongoDB is not reachable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}