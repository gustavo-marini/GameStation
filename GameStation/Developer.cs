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
    public partial class Developer : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;

        public Developer()
        {
            InitializeComponent();
        }

        private void feedDevelopersList()
        {
            try {
                string getGeneros = "SELECT * FROM tb_desenvolvedor";
                SqlCommand commGeneros = new SqlCommand(getGeneros, conn);

                SqlDataReader gr = commGeneros.ExecuteReader();

                if (gr.HasRows) {
                    listDevelopers.Items.Clear();
                    while (gr.Read()) {
                        string[] row = { gr.GetInt32(0).ToString(), gr.GetString(1) };
                        ListViewItem item = new ListViewItem(row);
                        listDevelopers.Items.Add(item);
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        private void Developer_Load(object sender, EventArgs e)
        {
            try {
                conn = new SqlConnection(connectionString);
                conn.Open();

                feedDevelopersList();
            } catch (Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        private void Developers_FocusEnter(object sender, EventArgs e)
        {
            feedDevelopersList();
        }

        private void lstItems_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listDevelopers.Columns[e.ColumnIndex].Width;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try {
                if (listDevelopers.SelectedItems.Count > 0) {
                    var selected = listDevelopers.SelectedItems[0];

                    int codeToDelete = Convert.ToInt32(selected.SubItems[0].Text);
                    string nameToDelete = selected.SubItems[1].Text;

                    DialogResult confirm = MessageBox.Show("Tem certeza que deseja remover o desenvolvedor \"" + nameToDelete + "\"?", "Remover desenvolvedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (confirm == DialogResult.Yes) {
                        string sqlRemove = "DELETE FROM tb_desenvolvedor WHERE codigo = @codigo";
                        SqlCommand commRemoveGender = new SqlCommand(sqlRemove, conn);
                        commRemoveGender.Parameters.AddWithValue("@codigo", codeToDelete);

                        int genderDeleted = commRemoveGender.ExecuteNonQuery();

                        if (genderDeleted > 0) {
                            feedDevelopersList();

                            MessageBox.Show("Desenvolvedor \"" + nameToDelete + "\" deletado com sucesso!", "Desenvolvedor deletado");
                        }
                    }
                } else {
                    MessageBox.Show("Selecione um desenvolvedor");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try {
                if (listDevelopers.SelectedItems.Count > 0) {
                    var selected = listDevelopers.SelectedItems[0];

                    int codeToDelete = Convert.ToInt32(selected.SubItems[0].Text);
                    string nameToDelete = selected.SubItems[1].Text;

                    EditDeveloper editDeveloper = new EditDeveloper(codeToDelete, nameToDelete);
                    editDeveloper.Show();
                } else {
                    MessageBox.Show("Selecione um gênero");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnNewDeveloper_Click(object sender, EventArgs e)
        {
            try {
                if (txtNome.Text.Length > 0) {
                    string nome = txtNome.Text.ToString();

                    string sqlCheck = "SELECT * FROM tb_desenvolvedor WHERE nome = @nome";
                    SqlCommand commandCheck = new SqlCommand(sqlCheck, conn);
                    commandCheck.Parameters.AddWithValue("@nome", nome);

                    SqlDataReader checkInsert = commandCheck.ExecuteReader();

                    if (!checkInsert.HasRows) {
                        string sqlInsert = "INSERT INTO tb_desenvolvedor (nome) VALUES (@nome)";
                        SqlCommand commandInsert = new SqlCommand(sqlInsert, conn);
                        commandInsert.Parameters.AddWithValue("@nome", nome);

                        if (commandInsert.ExecuteNonQuery() > 0) {
                            MessageBox.Show("Desenvolvedor inserido com sucesso!");

                            feedDevelopersList();
                        }
                    } else {
                        MessageBox.Show("Um desenvolvedor com esse nome já existe.");
                    }
                    txtNome.Clear();
                } else {
                    MessageBox.Show("Digite o nome do desenvolvedor.");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
