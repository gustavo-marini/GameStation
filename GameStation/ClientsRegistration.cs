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
                bool validateEmail = val.email(txtEmail, "Email");
                bool validateBirthdate = val.date(txtBirthday, "Data de nascimento");
                bool validateCpf = val.validateCpf(txtCpf, "CPF");
                bool validateCep = val.required(txtCep, "CEP");

                if(validateName && validateSurname && validateEmail && validateBirthdate && validateCpf && validateCep) {
                    string nome = txtName.Text.ToString();
                    string sobrenome = txtSurname.Text.ToString();
                    string email = txtEmail.Text.ToString();
                    string telefone = txtCellphone.Text.ToString();
                    string celular = txtPhone.Text.ToString();
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
                        while (cityReader.Read()) {
                            Console.WriteLine("encontrou a cidade " + cidade);
                            codigo_cidade = cityReader.GetInt32(0);
                            codigo_estado = cityReader.GetInt32(1);
                            Console.WriteLine("passou a cidade");
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

                    insertClient.Parameters.Add("@codigo_estado", SqlDbType.Int).Value = codigo_estado;
                    insertClient.Parameters.Add("@codigo_cidade", SqlDbType.Int).Value = codigo_cidade;
                    insertClient.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
                    insertClient.Parameters.Add("@sobrenome", SqlDbType.VarChar).Value = sobrenome;
                    insertClient.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    insertClient.Parameters.Add("@telefone", SqlDbType.VarChar).Value = telefone;
                    insertClient.Parameters.Add("@celular", SqlDbType.VarChar).Value = celular;
                    insertClient.Parameters.Add("@data_nascimento", SqlDbType.VarChar).Value = data_nascimento;
                    insertClient.Parameters.Add("@idade", SqlDbType.Int).Value = idade;
                    insertClient.Parameters.Add("@endereco", SqlDbType.VarChar).Value = endereco;
                    insertClient.Parameters.Add("@cpf", SqlDbType.VarChar).Value = cpf;
                    insertClient.Parameters.Add("@bairro", SqlDbType.VarChar).Value = bairro;
                    insertClient.Parameters.Add("@numero", SqlDbType.Int).Value = numero;
                    insertClient.Parameters.Add("@cep", SqlDbType.VarChar).Value = cep;


                    int result = insertClient.ExecuteNonQuery();

                    if(result == 1) {
                        MessageBox.Show("Cliente \"" + nome + " " + sobrenome + "\" inserido com sucesso.");

                        this.clearFields();
                    } else {
                        MessageBox.Show("Alguns campos foram preenchidos incorretamente.");
                    }
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
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
    }
}
