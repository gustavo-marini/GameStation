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
    public partial class AllClients : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;

        public AllClients()
        {
            InitializeComponent();
        }

        private void AllClients_Load(object sender, EventArgs e)
        {
            try {
                conn = new SqlConnection(connectionString);
                conn.Open();


                // Alimenta toda a lista de clientes
                string getClientes = "SELECT * FROM tb_clientes";
                SqlCommand commClientess = new SqlCommand(getClientes, conn);

                SqlDataReader cliRead = commClientess.ExecuteReader();

                if (cliRead.HasRows) {
                    listClientes.Items.Clear();
                    while (cliRead.Read()) {
                        string nomeCidade = Cidade.getNameById(cliRead.GetInt32(3), conn);
                        string nomeEstado = Estado.getNameById(cliRead.GetInt32(2), conn);

                        string[] row = {
                            cliRead.GetInt32(0).ToString(),
                            cliRead.GetString(4) + (cliRead.GetString(5)!=""? " " + cliRead.GetString(5): ""),
                            cliRead.GetString(6),
                            cliRead.GetString(7),
                            cliRead.GetString(9),
                            nomeCidade,
                            nomeEstado
                        };
                        ListViewItem item = new ListViewItem(row);
                        listClientes.Items.Add(item);
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        private void listClientes_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listClientes.Columns[e.ColumnIndex].Width;
        }

        private void addNewClient_Click(object sender, EventArgs e)
        {
            ClientsRegistration clientsRegistration = new ClientsRegistration();
            clientsRegistration.Show();
            this.Close();
        }

        private void btnRemoveClient_Click(object sender, EventArgs e)
        {
            try {
                if (listClientes.SelectedItems.Count > 0) {
                    var selected = listClientes.SelectedItems[0];

                    int codeToDelete = Convert.ToInt32(selected.SubItems[0].Text);
                    string nameToDelete = selected.SubItems[1].Text;

                    DialogResult confirm = MessageBox.Show("Tem certeza que deseja remover o cliente \"" + nameToDelete + "\"?", "Remover produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (confirm == DialogResult.Yes) {
                        string sqlRemove = "DELETE FROM tb_clientes WHERE codigo = @codigo";
                        SqlCommand commRemove = new SqlCommand(sqlRemove, conn);
                        commRemove.Parameters.AddWithValue("@codigo", codeToDelete);

                        int clientRemove = commRemove.ExecuteNonQuery();

                        if (clientRemove > 0) {
                            string getClientes = "SELECT * FROM tb_clientes";
                            SqlCommand commClientes = new SqlCommand(getClientes, conn);

                            SqlDataReader cliRead = commClientes.ExecuteReader();

                            listClientes.Items.Clear();
                            if (cliRead.HasRows) {
                                while (cliRead.Read()) {
                                    string nomeCidade = Cidade.getNameById(cliRead.GetInt32(3), conn);
                                    string nomeEstado = Estado.getNameById(cliRead.GetInt32(2), conn);

                                    string[] row = {
                                        cliRead.GetInt32(0).ToString(),
                                        cliRead.GetString(4) + (cliRead.GetString(5)!=""? " " + cliRead.GetString(5): ""),
                                        cliRead.GetString(6),
                                        cliRead.GetString(7),
                                        cliRead.GetString(9),
                                        nomeCidade,
                                        nomeEstado
                                    };
                                    ListViewItem item = new ListViewItem(row);
                                    listClientes.Items.Add(item);
                                }
                            }

                            MessageBox.Show("Cliente \"" + nameToDelete + "\" deletado com sucesso!", "Cliente deletado");
                        }
                    }
                } else {
                    MessageBox.Show("Selecione um cliente");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }


        private void btnEditClient_Click(object sender, EventArgs e)
        {
            if (listClientes.SelectedItems.Count > 0) {
                var selected = listClientes.SelectedItems[0];

                int codeToEdit = Convert.ToInt32(selected.SubItems[0].Text);
                EditClient editClient = new EditClient(codeToEdit);
                editClient.Show();
            } else {
                MessageBox.Show("Selecione um produto");
            }
        }

        private void AllProducts_FocusEnter(object sender, EventArgs e)
        {
            string getClientes = "SELECT * FROM tb_clientes";
            SqlCommand commClientes = new SqlCommand(getClientes, conn);

            SqlDataReader cliRead = commClientes.ExecuteReader();

            listClientes.Items.Clear();
            if (cliRead.HasRows) {
                while (cliRead.Read()) {
                    string nomeCidade = Cidade.getNameById(cliRead.GetInt32(3), conn);
                    string nomeEstado = Estado.getNameById(cliRead.GetInt32(2), conn);

                    string[] row = {
                        cliRead.GetInt32(0).ToString(),
                        cliRead.GetString(4) + (cliRead.GetString(5)!=""? " " + cliRead.GetString(5): ""),
                        cliRead.GetString(6),
                        cliRead.GetString(7),
                        cliRead.GetString(9),
                        nomeCidade,
                        nomeEstado
                    };
                    ListViewItem item = new ListViewItem(row);
                    listClientes.Items.Add(item);
                }
            }
        }
    }
}
