using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStation
{
    public partial class EmployessReport : Form
    {
        public EmployessReport()
        {
            InitializeComponent();
        }

        private void EmployessReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_gamestationDataSet2.tb_funcionarios' table. You can move, or remove it, as needed.
            this.tb_funcionariosTableAdapter.Fill(this.db_gamestationDataSet2.tb_funcionarios);

            this.reportViewer1.RefreshReport();
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try {
                this.tb_funcionariosTableAdapter.Fill(this.db_gamestationDataSet2.tb_funcionarios);
            } catch (System.Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
