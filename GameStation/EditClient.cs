using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStation
{
    public partial class EditClient : Form
    {
        private int codigo = -1;
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;

        public EditClient(int pk_value)
        {
            InitializeComponent();

            codigo = pk_value;
        }

        private void EditClient_Load(object sender, EventArgs e)
        {
            try {
                conn = new SqlConnection(connectionString);
                conn.Open();


                string sqlCliente = "SELECT * FROM tb_clientes WHERE codigo = @cod";
                SqlCommand comm = new SqlCommand(sqlCliente, conn);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
