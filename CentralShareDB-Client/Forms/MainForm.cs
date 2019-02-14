using CentralShareDB_Client.DB;
using CentralShareDB_Client.Forms;
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
        }
    }
}