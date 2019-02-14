using CentralShareDB_Client.DB;
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
            string host = this.hostTbx.Text;
            int port = (int) this.portNud.Value;

            DatabaseAddress address = new DatabaseAddress(host, port);
            DatabaseConnection connection = DatabaseConnection.Instance;

            connection.Address = address;
            connection.Connect();
            bool isReachable = connection.Test();

            if (isReachable)
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