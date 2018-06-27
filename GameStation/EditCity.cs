using GameStation.Libs;
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
    public partial class EditCity : Form
    {
        private int codigo;
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;

        public EditCity(int code)
        {
            InitializeComponent();

            this.codigo = code;
        }

        private void EditCity_Load(object sender, EventArgs e)
        {
            try {
                conn = new SqlConnection(connectionString);
                conn.Open();

                // Alimenta campos
                string sqlCidade = "SELECT * FROM tb_cidades WHERE codigo = @cod";
                SqlCommand comm = new SqlCommand(sqlCidade, conn);
                comm.Parameters.AddWithValue("@cod", this.codigo);

                SqlDataReader cityRead = comm.ExecuteReader();

                int codigo_estado = -1;

                if (cityRead.HasRows) {
                    while (cityRead.Read()) {
                        codigo_estado = cityRead.GetInt32(1);
                        string nome = cityRead.GetString(2);

                        txtCidade.Text = nome;

                        string sqlEstados = "SELECT * FROM tb_estados";
                        SqlCommand commandEstados = new SqlCommand(sqlEstados, conn);
                        SqlDataReader er = commandEstados.ExecuteReader();

                        List<Estado> estados = new List<Estado>();
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
                                cmbEstados.Items.Add(estado);
                            }
                        }
                    }
                }

                foreach (Estado estado in cmbEstados.Items) {
                    if (estado.codigo == codigo_estado) {
                        cmbEstados.SelectedIndex = cmbEstados.Items.IndexOf(estado);
                    }
                }

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void cmbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnNewCity_Click(object sender, EventArgs e)
        {
            string nome = txtCidade.Text;
            Estado selectedState = cmbEstados.SelectedItem as Estado;
            int codigo_estado = selectedState.codigo;

            string update = "UPDATE tb_cidades SET nome = @nome, codigo_estado = @cod_est WHERE codigo = @cod";
            SqlCommand upComm = new SqlCommand(update, conn);
            upComm.Parameters.AddWithValue("@nome", nome);
            upComm.Parameters.AddWithValue("@cod_est", codigo_estado);
            upComm.Parameters.AddWithValue("@cod", this.codigo);

            upComm.ExecuteNonQuery();

            AllCities allCities = new AllCities();
            allCities.Focus();
            this.Close();
        }
    }
}
