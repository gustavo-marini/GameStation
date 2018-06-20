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
                comm.Parameters.AddWithValue("@cod", codigo);

                SqlDataReader read = comm.ExecuteReader();

                if (read.HasRows) {
                    if (read.Read()) {
                        string nome = read.GetString(4);
                        string sobrenome = read.GetString(5);
                        string email = read.GetString(6);
                        string data_nascimento = read.GetString(9);
                        string telefone = read.GetString(7);
                        string celular = read.GetString(8);
                        int idade = read.GetInt32(10);
                        string cpf = read.GetString(12);
                        string cep = read.GetString(15);
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
