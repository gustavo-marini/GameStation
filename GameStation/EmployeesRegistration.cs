using GameStation.Libs;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GameStation
{
    public partial class EmployeesRegistration : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;
        public EmployeesRegistration()
        {
            InitializeComponent();
        }

        private void EmployeesRegistration_Load(object sender, EventArgs e)
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
                bool validateEmail = val.email(txtEmail, "Email");
                bool validateBirthdate = val.date(txtBirthday, "Data de nascimento");
                bool validateCpf = val.validateCpf(txtCpf, "CPF");
                bool validateCep = val.required(txtCep, "CEP");

                if (validateName && validateSurname && validateEmail && validateBirthdate && validateCpf && validateCep) {
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
                    string login = txtLogin.Text.ToString();
                    string senha = txtPassword.Text.ToString();
                    double salario = Convert.ToDouble(txtSalary.Text.ToString());


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


                    string sqlInsert = "INSERT INTO tb_funcionarios (codigo_pais, codigo_estado, codigo_cidade, nome, sobrenome, email, telefone, celular, data_nascimento, idade, endereco, cpf, bairro, numero, cep, login, senha, salario)" +
                        " VALUES(30, @codigo_estado, @codigo_cidade, @nome, @sobrenome, @email, @telefone, @celular, @data_nascimento, @idade, @endereco, @cpf, @bairro, @numero, @cep, @login, @senha, @salario)";

                    SqlCommand insertEmployee = new SqlCommand(sqlInsert, conn);

                    insertEmployee.Parameters.AddWithValue("@codigo_estado", codigo_estado);
                    insertEmployee.Parameters.AddWithValue("@codigo_cidade", codigo_cidade);
                    insertEmployee.Parameters.AddWithValue("@nome", nome);
                    insertEmployee.Parameters.AddWithValue("@sobrenome", sobrenome);
                    insertEmployee.Parameters.AddWithValue("@email", email);
                    insertEmployee.Parameters.AddWithValue("@telefone", telefone);
                    insertEmployee.Parameters.AddWithValue("@celular", celular);
                    insertEmployee.Parameters.AddWithValue("@data_nascimento", data_nascimento);
                    insertEmployee.Parameters.AddWithValue("@idade", idade);
                    insertEmployee.Parameters.AddWithValue("@endereco", endereco);
                    insertEmployee.Parameters.AddWithValue("@cpf", cpf);
                    insertEmployee.Parameters.AddWithValue("@bairro", bairro);
                    insertEmployee.Parameters.AddWithValue("@numero", numero);
                    insertEmployee.Parameters.AddWithValue("@cep", cep);
                    insertEmployee.Parameters.AddWithValue("@login", login);
                    insertEmployee.Parameters.AddWithValue("@senha", senha);
                    insertEmployee.Parameters.AddWithValue("@salario", salario);


                    int result = insertEmployee.ExecuteNonQuery();

                    if (result == 1) {
                        MessageBox.Show("Funcionário \"" + nome + " " + sobrenome + "\" inserido com sucesso.");

                        this.clearFields();
                    } else {
                        MessageBox.Show("Alguns campos foram preenchidos incorretamente.");
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void txtBirthday_TextChanged(object sender, EventArgs e)
        {
            string birthdate = txtBirthday.Text;

            if (birthdate.Length == 10) {
                dynamic birthday = Basics.getBirthdate(birthdate);
                int age = Basics.calculateAge(new DateTime(birthday.year, birthday.month, birthday.day));

                txtAge.Text = age.ToString();
            }
        }

        string str = "";
        private void txtSalary_KeyDown(object sender, KeyEventArgs e)
        {
            int KeyCode = e.KeyValue;

            if (!IsNumeric(KeyCode)) {
                e.Handled = true;
                return;
            } else {
                e.Handled = true;
            }
            if (((KeyCode == 8) || (KeyCode == 46)) && (str.Length > 0)) {
                str = str.Substring(0, str.Length - 1);
            } else if (!((KeyCode == 8) || (KeyCode == 46))) {
                str = str + Convert.ToChar(KeyCode);
            }
            if (str.Length == 0) {
                txtSalary.Text = "";
            }
            if (str.Length == 1) {
                txtSalary.Text = "0.0" + str;
            } else if (str.Length == 2) {
                txtSalary.Text = "0." + str;
            } else if (str.Length > 2) {
                txtSalary.Text = str.Substring(0, str.Length - 2) + "." +
                                str.Substring(str.Length - 2);
            }
        }

        private bool IsNumeric(int Val)
        {
            return ((Val >= 48 && Val <= 57) || (Val == 8) || (Val == 46));
        }

        private void txtSalary_KeyPress(object sender,
                System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
