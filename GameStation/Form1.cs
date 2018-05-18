using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GameStation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected SqlConnection connection;
        private string stringConnection = "";
        

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClientsRegistration clientsRegistration = new ClientsRegistration();
                clientsRegistration.Show();
            }
            catch
            {
                //
            }
        }
    }
}
