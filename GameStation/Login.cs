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
    public partial class Login : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;
        private List<Usuario> users = new List<Usuario>();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string sqlAdmin = "SELECT * FROM tb_usuarios";
                SqlCommand admComm = new SqlCommand(sqlAdmin, conn);
                SqlDataReader admRead = admComm.ExecuteReader();

                if (admRead.HasRows) {
                    while (admRead.Read()) {
                        Usuario adm = new Usuario();
                        adm.codigo = admRead.GetInt32(0);
                        adm.codigo_acesso = 1;
                        adm.nome = admRead.GetString(1);
                        adm.login = admRead.GetString(2);
                        adm.senha = admRead.GetString(3);
                        users.Add(adm);
                    }
                }

                string sqlFunc = "SELECT codigo, CONCAT(nome, ' ', sobrenome) as nome, login, senha FROM tb_funcionarios";
                SqlCommand funComm = new SqlCommand(sqlFunc, conn);
                SqlDataReader funRead = funComm.ExecuteReader();

                if (funRead.HasRows) {
                    while (funRead.Read()) {
                        Usuario adm = new Usuario();
                        adm.codigo = funRead.GetInt32(0);
                        adm.codigo_acesso = 2;
                        adm.nome = funRead.GetString(1);
                        adm.login = funRead.GetString(2);
                        adm.senha = funRead.GetString(3);
                        users.Add(adm);
                    }
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try {
                Validate val = new Validate();
                bool validateLogin = val.Required(txtLogin, "Login");
                bool validateSenha = val.Required(txtSenha, "Senha");

                if(validateLogin && validateSenha) {
                    string login = txtLogin.Text.ToString();
                    string senha = txtSenha.Text.ToString();

                    bool canLogin = false;
                    Usuario returnUser = null;

                    foreach(Usuario user in users) {
                        if(user.login == login && Basics.GetHashMd5(senha) == user.senha) {
                            canLogin = true;
                            returnUser = user;
                            break;
                        }
                    }

                    if (canLogin) {
                        MainForm form = new MainForm(returnUser);
                        this.Hide();
                        form.ShowDialog();
                        this.Close();
                    } else {
                        MessageBox.Show("Usuário ou senha inválidos.", "Erro no login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    MessageBox.Show(val.getErrors(), "Erro na validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
