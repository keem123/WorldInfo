using SimpleDataClient.Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleDataClient
{
    public partial class ConfigForm : Form
    {
        ServerConfiguration config = new ServerConfiguration();
        public ConfigForm()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = config;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            config.Save();
            this.Close();
            this.Dispose();
        }
    }
}
