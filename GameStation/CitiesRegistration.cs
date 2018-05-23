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
using GameStation.Libs;

namespace GameStation
{
    public partial class CitiesRegistration : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True";
        private SqlConnection conn;
        private List<Estado> estados = new List<Estado>();

        public CitiesRegistration()
        {
            InitializeComponent();
        }

        private void CitiesRegistration_Load(object sender, EventArgs e)
        {
            try {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string sqlEstados = "SELECT * FROM tb_estados";
                SqlCommand commandEstados = new SqlCommand(sqlEstados, conn);
                SqlDataReader er = commandEstados.ExecuteReader();

                if (er.HasRows) {
                    while (er.Read()) {
                        Estado estado = new Estado {
                            codigo = er.GetInt32(0),
                            codigo_pais = er.GetInt32(1),
                            uf = er.GetString(2).ToString(),
                            nome = er.GetString(3).ToString()
                        };
                        estados.Add(estado);
                    }

                    estados = estados.OrderBy(o => o.nome).ToList();

                    foreach (Estado estado in estados) {
                        cmbEstados.Items.Add(estado.nome);
                    }
                }
            } catch(Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        private void cmbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                var selectedItem = cmbEstados.SelectedItem;
                Console.WriteLine(selectedItem);
            } catch {

            }
        }
    }
}
