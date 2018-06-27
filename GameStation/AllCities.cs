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
    public partial class AllCities : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;

        public AllCities()
        {
            InitializeComponent();
        }

        private void AllCities_Load(object sender, EventArgs e)
        {
            try {
                conn = new SqlConnection(connectionString);
                conn.Open();

                // Alimenta toda a lista de cidades
                string getCidades = "SELECT TOP 100 * FROM tb_cidades";
                SqlCommand commCidades = new SqlCommand(getCidades, conn);

                SqlDataReader prodRead = commCidades.ExecuteReader();

                if (prodRead.HasRows) {
                    listCidades.Items.Clear();
                    while (prodRead.Read()) {

                        string[] row = {
                            prodRead.GetInt32(0).ToString(),
                            prodRead.GetString(2),
                            Estado.getNameById(prodRead.GetInt32(1), conn).ToString(),
                            prodRead.GetString(3)
                        };
                        ListViewItem item = new ListViewItem(row);
                        listCidades.Items.Add(item);
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        private void addNewCity_Click(object sender, EventArgs e)
        {
            CitiesRegistration citiesRegistration = new CitiesRegistration();
            citiesRegistration.Show();
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            try {
                if (listCidades.SelectedItems.Count > 0) {
                    var selected = listCidades.SelectedItems[0];

                    int codeToDelete = Convert.ToInt32(selected.SubItems[0].Text);
                    string nameToDelete = selected.SubItems[1].Text;

                    DialogResult confirm = MessageBox.Show("Tem certeza que deseja remover a cidade \"" + nameToDelete + "\"?", "Remover cidade", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (confirm == DialogResult.Yes) {
                        string sqlRemove = "DELETE FROM tb_cidades WHERE codigo = @codigo";
                        SqlCommand commRemove = new SqlCommand(sqlRemove, conn);
                        commRemove.Parameters.AddWithValue("@codigo", codeToDelete);

                        int genderDeleted = commRemove.ExecuteNonQuery();

                        if (genderDeleted > 0) {
                            string getCidades = "SELECT TOP 100 * FROM tb_cidades";
                            SqlCommand commCidades = new SqlCommand(getCidades, conn);

                            SqlDataReader prodRead = commCidades.ExecuteReader();

                            if (prodRead.HasRows) {
                                listCidades.Items.Clear();
                                while (prodRead.Read()) {

                                    string[] row = {
                                        prodRead.GetInt32(0).ToString(),
                                        prodRead.GetString(2),
                                        Estado.getNameById(prodRead.GetInt32(1), conn).ToString(),
                                        prodRead.GetString(3)
                                    };
                                    ListViewItem item = new ListViewItem(row);
                                    listCidades.Items.Add(item);
                                }
                            }

                            MessageBox.Show("Cidade \"" + nameToDelete + "\" deletada com sucesso!", "Cidade deletada");
                        }
                    }
                } else {
                    MessageBox.Show("Selecione uma cidade");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (listCidades.SelectedItems.Count > 0) {
                var selected = listCidades.SelectedItems[0];

                int codeToEdit = Convert.ToInt32(selected.SubItems[0].Text);
                EditCity editCity = new EditCity(codeToEdit);
                editCity.Show();
            } else {
                MessageBox.Show("Selecione um produto");
            }
        }
    }
}
