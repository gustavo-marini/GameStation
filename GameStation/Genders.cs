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
    public partial class Genders : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;
        private List<Genero> generos = new List<Genero>();

        public Genders()
        {
            InitializeComponent();
        }

        private void feedGenderList()
        {
            try {
                string getGeneros = "SELECT * FROM tb_generos";
                SqlCommand commGeneros = new SqlCommand(getGeneros, conn);

                SqlDataReader gr = commGeneros.ExecuteReader();

                if (gr.HasRows) {
                    listGenders.Items.Clear();
                    while (gr.Read()) {
                        string[] row = { gr.GetInt32(0).ToString(), gr.GetString(1) };
                        ListViewItem item = new ListViewItem(row);
                        listGenders.Items.Add(item);
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        private void Genders_Load(object sender, EventArgs e)
        {
            try {
                conn = new SqlConnection(connectionString);
                conn.Open();

                feedGenderList();
            } catch(Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        private void Genders_FocusEnter(object sender, EventArgs e)
        {
            feedGenderList();
        }

        private void lstItems_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listGenders.Columns[e.ColumnIndex].Width;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                if(listGenders.SelectedItems.Count > 0) {
                    var selected = listGenders.SelectedItems[0];

                    int codeToDelete = Convert.ToInt32(selected.SubItems[0].Text);
                    string nameToDelete = selected.SubItems[1].Text;

                    DialogResult confirm = MessageBox.Show("Tem certeza que deseja remover o gênero \"" + nameToDelete + "\"?", "Remover gênero", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if(confirm == DialogResult.Yes) {
                        string sqlRemove = "DELETE FROM tb_generos WHERE codigo = @codigo";
                        SqlCommand commRemoveGender = new SqlCommand(sqlRemove, conn);
                        commRemoveGender.Parameters.AddWithValue("@codigo", codeToDelete);

                        int genderDeleted = commRemoveGender.ExecuteNonQuery();

                        if(genderDeleted > 0) {
                            feedGenderList();

                            string deleteRelationGender = "DELETE FROM tb_produtos_generos WHERE codigo_genero = @cod_gen";
                            SqlCommand commRemoveRelationGender = new SqlCommand(deleteRelationGender, conn);
                            commRemoveRelationGender.Parameters.AddWithValue("@cod_gen", codeToDelete);

                            int relationGenderDeleted = commRemoveRelationGender.ExecuteNonQuery();

                            if(relationGenderDeleted > 0) {
                                MessageBox.Show("Genêro \"" + nameToDelete + "\" deletado com sucesso!", "Gênero deletado");
                            } 
                        }
                    }
                } else {
                    MessageBox.Show("Selecione um gênero");
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (listGenders.SelectedItems.Count > 0) {
                    var selected = listGenders.SelectedItems[0];

                    int codeToDelete = Convert.ToInt32(selected.SubItems[0].Text);
                    string nameToDelete = selected.SubItems[1].Text;

                    EditGender editGender = new EditGender(codeToDelete, nameToDelete);
                    editGender.Show();
                } else {
                    MessageBox.Show("Selecione um gênero");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnNewGender_Click(object sender, EventArgs e)
        {
            try {
                if(txtNome.Text.Length > 0) {
                    string nome = txtNome.Text.ToString();

                    string sqlCheck = "SELECT * FROM tb_generos WHERE nome = @nome";
                    SqlCommand commandCheck = new SqlCommand(sqlCheck, conn);
                    commandCheck.Parameters.AddWithValue("@nome", nome);

                    SqlDataReader checkInsert = commandCheck.ExecuteReader();

                    if(!checkInsert.HasRows) {
                        string sqlInsert = "INSERT INTO tb_generos (nome) VALUES (@nome)";
                        SqlCommand commandInsert = new SqlCommand(sqlInsert, conn);
                        commandInsert.Parameters.AddWithValue("@nome", nome);

                        if(commandInsert.ExecuteNonQuery() > 0) {
                            MessageBox.Show("Gênero inserido com sucesso!");

                            feedGenderList();
                        }
                    } else {
                        MessageBox.Show("Um gênero com esse nome já existe.");
                    }
                    txtNome.Clear();
                } else {
                    MessageBox.Show("Digite o nome do gênero.");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
