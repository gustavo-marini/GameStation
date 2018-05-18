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
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True";
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
                    string bairro = txtNeighborhood.Text.ToString();
                    int numero = Convert.ToInt32(txtNumber.Text.ToString());
                    string cep = txtCep.Text.ToString();

                    string sqlInsert = "INSERT INTO tb_clientes (codigo_pais, nome, sobrenome, email, telefone, celular, data_nascimento, idade, endereco, cpf, bairro, numero, cep)" +
                        " VALUES(30, '"+nome+"', '"+sobrenome+"', '"+email+"', '"+telefone+"', '"+celular+"', '"+data_nascimento+"', "+idade+", '"+endereco+"', '"+cpf+"', '"+bairro+"', "+numero+", '"+cep+"')";
                    Console.WriteLine(sqlInsert);
                    SqlCommand insertClient = new SqlCommand(sqlInsert, conn);
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
