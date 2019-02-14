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
    public partial class NewShareForm : Form
    {
        public NewShareForm()
        {
            InitializeComponent();
            this.LoadDriveLetters();
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

        }
    }
}