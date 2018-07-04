using GameStation.Libs;
using Newtonsoft.Json;
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
                        txtName.Text = read.GetString(4);
                        txtSurname.Text = read.GetString(5);
                        txtEmail.Text = read.GetString(6);
                        txtBirthday.Text = read.GetString(9);
                        txtPhone.Text = read.GetString(7);
                        txtCellphone.Text = read.GetString(8);
                        txtAge.Text = read.GetInt32(10).ToString();
                        txtCpf.Text = read.GetString(12);
                        txtCep.Text = read.GetString(15);
                        txtNumber.Text = read.GetInt32(14).ToString();

                        string cep = txtCep.Text;
                        cep = Basics.limpaCep(cep);

                        string api_url = "https://api.postmon.com.br/v1/cep/" + cep;

                        string request = Basics.httpGet(api_url);
                        Endereco result = JsonConvert.DeserializeObject<Endereco>(request);

                        if (!String.IsNullOrEmpty(result.Logradouro)) {
                            txtAddress.Text = result.Logradouro;
                            txtNeighborhood.Text = result.Bairro;
                            txtCity.Text = result.Cidade;
                            txtState.Text = result.EstadoInfo.Nome;

                            txtAddress.ReadOnly = txtNeighborhood.ReadOnly = txtCity.ReadOnly = txtState.ReadOnly = true;
                        }
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }


        private void txtCep_TextChanged(object sender, EventArgs e)
        {
            string cepText = txtCep.Text.ToString();
            try {
                int inputSize = txtCep.Text.ToString().Length;

                if (inputSize == 9) {
                    string cep = cepText;
                    cep = Basics.limpaCep(cep);

                    string api_url = "https://api.postmon.com.br/v1/cep/" + cep;

                    string request = Basics.httpGet(api_url);
                    Endereco result = JsonConvert.DeserializeObject<Endereco>(request);

                    if (!String.IsNullOrEmpty(result.Logradouro)) {
                        txtAddress.Text = result.Logradouro;
                        txtNeighborhood.Text = result.Bairro;
                        txtCity.Text = result.Cidade;
                        txtState.Text = result.EstadoInfo.Nome;

                        txtAddress.ReadOnly = txtNeighborhood.ReadOnly = txtCity.ReadOnly = txtState.ReadOnly = true;
                    }
                } else {
                    txtAddress.Text = txtNeighborhood.Text = txtCity.Text = txtState.Text = "";

                    txtAddress.ReadOnly = txtNeighborhood.ReadOnly = txtCity.ReadOnly = txtState.ReadOnly = false;
                }
            } catch (Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try {
                Validate val = new Validate();

                bool validateName = val.onlyLetters(txtName, "Nome");
                bool validateSurname = val.onlyLetters(txtSurname, "Sobrenome");
                bool validateEmail = val.Required(txtEmail, "Email");
                bool validateEmailSyntax = val.email(txtEmail, "Email");
                bool validateBirthdate = val.date(txtBirthday, "Data de nascimento");
                bool validateCpf = val.validateCpf(txtCpf, "CPF");
                bool validateCep = val.required(txtCep, "CEP");
                bool validateNumero = val.Required(txtNumber, "Número");

                if (validateName && validateSurname && validateEmail && validateEmailSyntax && validateBirthdate && validateCpf && validateCep && validateNumero) {
                    string nome = txtName.Text.ToString();
                    string sobrenome = txtSurname.Text.ToString();
                    string email = txtEmail.Text.ToString();
                    string telefone = txtPhone.Text.ToString();
                    string celular = txtCellphone.Text.ToString();
                    string data_nascimento = txtBirthday.Text.ToString();
                    int idade = Convert.ToInt32(txtAge.Text.ToString());
                    string endereco = txtAddress.Text.ToString();
                    string cpf = txtCpf.Text.ToString();
                    string cidade = txtCity.Text.ToString();
                    string estado = txtState.Text.ToString();
                    string bairro = txtNeighborhood.Text.ToString();
                    int numero = Convert.ToInt32(txtNumber.Text.ToString());
                    string cep = txtCep.Text.ToString();


                    // Tenta encontrar a cidade no banco. 
                    // Se encontrar, pega o código dela, senão adiciona a cidade.
                    int codigo_cidade = -1, codigo_estado = -1;

                    string sqlCity = "SELECT * FROM tb_cidades WHERE lower(nome) = @nome";
                    SqlCommand commandCity = new SqlCommand(sqlCity, conn);
                    commandCity.Parameters.AddWithValue("@nome", cidade.ToLower());

                    SqlDataReader cityReader = commandCity.ExecuteReader();

                    if (cityReader.HasRows) {
                        if (cityReader.Read()) {
                            codigo_cidade = cityReader.GetInt32(0);
                            codigo_estado = cityReader.GetInt32(1);
                        }
                    } else {
                        // Se não encontrar a cidade na tabela, então pega a informação recebida da API e adiciona.
                        string sqlState = "SELECT * FROM tb_estados WHERE lower(nome)='" + estado.ToLower() + "'";
                        SqlCommand commandState = new SqlCommand(sqlState, conn);

                        SqlDataReader stateReader = commandState.ExecuteReader();

                        if (stateReader.HasRows) {
                            if (stateReader.Read()) {
                                codigo_estado = Convert.ToInt32(stateReader.GetInt32(0));
                                stateReader.Close();

                                try {
                                    string insertNewCity = "INSERT INTO tb_cidades (codigo_estado, nome, cep) OUTPUT INSERTED.codigo " +
                                    " VALUES (@codigo_estado, @nome, @cep)";
                                    SqlCommand commandNewCity = new SqlCommand(insertNewCity, conn);

                                    commandNewCity.Parameters.Add("@codigo_estado", SqlDbType.Int).Value = codigo_estado;
                                    commandNewCity.Parameters.Add("@nome", SqlDbType.VarChar).Value = cidade;
                                    commandNewCity.Parameters.Add("@cep", SqlDbType.VarChar).Value = cep;

                                    int id = Convert.ToInt32(commandNewCity.ExecuteScalar());
                                    codigo_cidade = id;
                                } catch (Exception ex) {
                                    Console.WriteLine("Erro: " + ex.Message);
                                }
                            }
                        } else {
                            MessageBox.Show("Nenhum estado encontrado");
                        }
                    }


                    // Atualizar cliente
                    string sqlUpdate = "UPDATE tb_clientes SET codigo_estado = @cod_es, codigo_cidade = @cod_cid, nome = @nome, sobrenome = @sobrenome, email = @email, telefone = @tel, celular = @cel, data_nascimento = @data, idade = @idade, endereco = @end, cpf = @cpf, bairro = @bairro, numero = @numero, cep = @cep WHERE codigo = @codigo";
                    SqlCommand update = new SqlCommand(sqlUpdate, conn);
                    update.Parameters.AddWithValue("@cod_es", codigo_estado);
                    update.Parameters.AddWithValue("@cod_cid", codigo_cidade);
                    update.Parameters.AddWithValue("@nome", nome);
                    update.Parameters.AddWithValue("@sobrenome", sobrenome);
                    update.Parameters.AddWithValue("@email", email);
                    update.Parameters.AddWithValue("@tel", telefone);
                    update.Parameters.AddWithValue("@cel", celular);
                    update.Parameters.AddWithValue("@data", data_nascimento);
                    update.Parameters.AddWithValue("@idade", idade);
                    update.Parameters.AddWithValue("@end", endereco);
                    update.Parameters.AddWithValue("@cpf", cpf);
                    update.Parameters.AddWithValue("@bairro", bairro);
                    update.Parameters.AddWithValue("@numero", numero);
                    update.Parameters.AddWithValue("@cep", cep);
                    update.Parameters.AddWithValue("@codigo", this.codigo);

                    update.ExecuteNonQuery();

                    AllClients allClients = new AllClients();
                    allClients.Focus();
                    this.Close();
                } else {
                    MessageBox.Show(val.getErrors(), "Erro na validação dos campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                } catch (Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
