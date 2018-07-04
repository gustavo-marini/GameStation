using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameStation.Libs;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Globalization;
using System.Threading;

namespace GameStation
{
    public partial class ClientsRegistration : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;

        public ClientsRegistration()
        {
            InitializeComponent();
        }

        private void ClientsRegistration_Load(object sender, EventArgs e)
        {
            try {
                conn = new SqlConnection(connectionString);
                conn.Open();
            } catch {

            }
        }


        private void clearFields()
        {
            foreach (Control control in this.Controls) {
                if (control is TextBox || control is MaskedTextBox) {
                    control.ResetText();
                }
            }
        }

        private void txtCep_TextChanged(object sender, EventArgs e)
        {
            string cepText = txtCep.Text.ToString();
            try {
                int inputSize = txtCep.Text.ToString().Length;

                if(inputSize == 9) {
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
            } catch(Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Validate val = new Validate();

                bool validateName = val.onlyLetters(txtName, "Nome");
                bool validateSurname = val.onlyLetters(txtSurname, "Sobrenome");
                bool validateEmail = val.Required(txtEmail, "Email");
                bool validateEmailSyntax = val.email(txtEmail, "Email");
                bool validateBirthdate = val.date(txtBirthday, "Data de nascimento");
                bool validateCpf = val.validateCpf(txtCpf, "CPF");
                bool validateCep = val.required(txtCep, "CEP");
                bool validateNumero = val.Required(txtNumber, "Número");

                if(validateName && validateSurname && validateEmail && validateEmailSyntax && validateBirthdate && validateCpf && validateCep && validateNumero) {
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

                    if(cityReader.HasRows) {
                        if (cityReader.Read()) {
                            codigo_cidade = cityReader.GetInt32(0);
                            codigo_estado = cityReader.GetInt32(1);
                        }
                    } else {
                        // Se não encontrar a cidade na tabela, então pega a informação recebida da API e adiciona.
                        string sqlState = "SELECT * FROM tb_estados WHERE lower(nome)='"+ estado.ToLower() + "'";
                        SqlCommand commandState = new SqlCommand(sqlState, conn);

                        SqlDataReader stateReader = commandState.ExecuteReader();

                        if(stateReader.HasRows) {
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


                    string sqlInsert = "INSERT INTO tb_clientes (codigo_pais, codigo_estado, codigo_cidade, nome, sobrenome, email, telefone, celular, data_nascimento, idade, endereco, cpf, bairro, numero, cep)" +
                        " VALUES(30, @codigo_estado, @codigo_cidade, @nome, @sobrenome, @email, @telefone, @celular, @data_nascimento, @idade, @endereco, @cpf, @bairro, @numero, @cep)";

                    SqlCommand insertClient = new SqlCommand(sqlInsert, conn);

                    insertClient.Parameters.AddWithValue("@codigo_estado", codigo_estado);
                    insertClient.Parameters.AddWithValue("@codigo_cidade", codigo_cidade);
                    insertClient.Parameters.AddWithValue("@nome", nome);
                    insertClient.Parameters.AddWithValue("@sobrenome", sobrenome);
                    insertClient.Parameters.AddWithValue("@email", email);
                    insertClient.Parameters.AddWithValue("@telefone", telefone);
                    insertClient.Parameters.AddWithValue("@celular", celular);
                    insertClient.Parameters.AddWithValue("@data_nascimento", data_nascimento);
                    insertClient.Parameters.AddWithValue("@idade", idade);
                    insertClient.Parameters.AddWithValue("@endereco", endereco);
                    insertClient.Parameters.AddWithValue("@cpf", cpf);
                    insertClient.Parameters.AddWithValue("@bairro", bairro);
                    insertClient.Parameters.AddWithValue("@numero", numero);
                    insertClient.Parameters.AddWithValue("@cep", cep);


                    int result = insertClient.ExecuteNonQuery();

                    if (result == 1) {
                        MessageBox.Show("Cliente \"" + nome + " " + sobrenome + "\" inserido com sucesso.");

                        this.clearFields();
                    } else {
                        MessageBox.Show("Alguns campos foram preenchidos incorretamente.");
                    }
                } else {
                    MessageBox.Show(val.getErrors(), "Erro na validação dos campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void txtBirthday_TextChanged(object sender, EventArgs e)
        {
            string birthdate = txtBirthday.Text;

            if(birthdate.Length == 10)
            {
                dynamic birthday = Basics.getBirthdate(birthdate);
                int age = Basics.calculateAge(new DateTime(birthday.year, birthday.month, birthday.day));

                txtAge.Text = age.ToString();
            }
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }
    }
}
