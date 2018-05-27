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
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
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
                        cmbEstados.Items.Add(estado);
                    }
                }
            } catch(Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        private void cmbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                Estado selectedItem = cmbEstados.SelectedItem as Estado;

                int codigo = selectedItem.codigo;
                string nome = selectedItem.nome;

                string selectCidades = "SELECT * FROM tb_cidades WHERE codigo_estado = @codigo_cidade";
                SqlCommand commandCadastroCidade = new SqlCommand(selectCidades, conn);
                commandCadastroCidade.Parameters.Add("@codigo_cidade", SqlDbType.Int).Value = codigo;

                SqlDataReader rc = commandCadastroCidade.ExecuteReader();

                if (rc.HasRows) {
                    txtCidade.ReadOnly = false;
                    txtCidade.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtCidade.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();

                    while (rc.Read()) {
                        autoComplete.Add(rc.GetString(2));
                    }
                    rc.Close();

                    txtCidade.AutoCompleteCustomSource = autoComplete;
                }
            } catch(Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        private void btnNewCity_Click(object sender, EventArgs e)
        {
            try {
                string cidade = txtCidade.Text.ToString();

                if (cidade.Length > 0) {
                    string sqlCheck = "SELECT COUNT(*) FROM tb_cidades WHERE nome = @nome";
                    SqlCommand commandCheck = new SqlCommand(sqlCheck, conn);
                    commandCheck.Parameters.Add("@nome", SqlDbType.VarChar).Value = cidade;

                    int checkCidade = Convert.ToInt32(commandCheck.ExecuteScalar());
                    Console.WriteLine(checkCidade);

                    if(checkCidade == 0) {
                        Estado selectedItem = cmbEstados.SelectedItem as Estado;

                        string sqlInsert = "INSERT INTO tb_cidades (codigo_estado, nome) VALUES (@codigo_estado, @nome)";
                        SqlCommand insertCidade = new SqlCommand(sqlInsert, conn);
                        insertCidade.Parameters.Add("@codigo_estado", SqlDbType.Int).Value = selectedItem.codigo;
                        insertCidade.Parameters.Add("@nome", SqlDbType.VarChar).Value = cidade;

                        int insertQuery = insertCidade.ExecuteNonQuery();
                    }
                }
            } catch(Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
