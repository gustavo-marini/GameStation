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
    public partial class Availability : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;

        public Availability()
        {
            InitializeComponent();
        }

        private void feedAvailabilityList()
        {
            try {
                string getDisponibilidades = "SELECT * FROM tb_disponibilidades";
                SqlCommand commDisponibilidades = new SqlCommand(getDisponibilidades, conn);

                SqlDataReader dr = commDisponibilidades.ExecuteReader();

                if (dr.HasRows) {
                    listAvailability.Items.Clear();
                    while (dr.Read()) {
                        string[] row = { dr.GetInt32(0).ToString(), dr.GetInt32(1).ToString(), dr.GetString(2).ToString() };
                        ListViewItem item = new ListViewItem(row);
                        listAvailability.Items.Add(item);
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        private void Availability_Load(object sender, EventArgs e)
        {
            try {
                conn = new SqlConnection(connectionString);
                conn.Open();

                feedAvailabilityList();
            } catch (Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void Availability_FocusEnter(object sender, EventArgs e)
        {
            feedAvailabilityList();
        }

        private void lstItems_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listAvailability.Columns[e.ColumnIndex].Width;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try {
                if (listAvailability.SelectedItems.Count > 0) {
                    var selected = listAvailability.SelectedItems[0];

                    int codeToDelete = Convert.ToInt32(selected.SubItems[0].Text);
                    string nameToDelete = selected.SubItems[1].Text;

                    DialogResult confirm = MessageBox.Show("Tem certeza que deseja remover a disponibilidade selecionada?", "Remover disponibilidade", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (confirm == DialogResult.Yes) {
                        string sqlRemove = "DELETE FROM tb_disponibilidades WHERE codigo = @codigo";
                        SqlCommand commRemoveDisp = new SqlCommand(sqlRemove, conn);
                        commRemoveDisp.Parameters.AddWithValue("@codigo", codeToDelete);

                        int dispDeleted = commRemoveDisp.ExecuteNonQuery();

                        if (dispDeleted > 0) {
                            feedAvailabilityList();

                            MessageBox.Show("Disponibilidade deletada com sucesso!", "Disponibilidade deletada");
                        }
                    }
                } else {
                    MessageBox.Show("Selecione uma disponibilidade");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try {
                if (listAvailability.SelectedItems.Count > 0) {
                    var selected = listAvailability.SelectedItems[0];

                    int codeToEdit = Convert.ToInt32(selected.SubItems[0].Text);
                    int dayToEdit = Convert.ToInt32(selected.SubItems[1].Text);
                    string nameToEdit = selected.SubItems[2].Text;

                    EditAvailability editAvailability = new EditAvailability(codeToEdit, dayToEdit, nameToEdit);
                    editAvailability.Show();
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
                if (txtDias.Text.Length > 0 && txtDescricao.Text.Length > 0) {
                    int dias = Convert.ToInt32(txtDias.Text.ToString());
                    string descricao = txtDescricao.Text.ToString();

                    string sqlCheck = "SELECT * FROM tb_disponibilidades WHERE descricao = @descricao";
                    SqlCommand commandCheck = new SqlCommand(sqlCheck, conn);
                    commandCheck.Parameters.AddWithValue("@descricao", descricao);

                    SqlDataReader checkInsert = commandCheck.ExecuteReader();

                    if (!checkInsert.HasRows) {
                        string sqlInsert = "INSERT INTO tb_disponibilidades (dias, descricao) VALUES (@dias, @descricao)";
                        SqlCommand commandInsert = new SqlCommand(sqlInsert, conn);
                        commandInsert.Parameters.AddWithValue("@dias", dias);
                        commandInsert.Parameters.AddWithValue("@descricao", descricao);

                        if (commandInsert.ExecuteNonQuery() > 0) {
                            MessageBox.Show("Disponibilidade inserida com sucesso!");

                            feedAvailabilityList();
                        }
                    } else {
                        MessageBox.Show("Uma disponibilidade com essa descrição já existe.");
                    }
                    txtDias.Clear();
                    txtDescricao.Clear();
                } else {
                    MessageBox.Show("Os campos são obrigatórios.");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
