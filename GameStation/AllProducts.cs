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
using static System.Windows.Forms.CheckedListBox;

namespace GameStation
{
    public partial class AllProducts : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;
        private Carrinho Cart;

        public AllProducts()
        {
            InitializeComponent();
        }

        private void AllProducts_Load(object sender, EventArgs e)
        {
            try {
                conn = new SqlConnection(connectionString);
                conn.Open();


                // Alimenta toda a lista de produtos
                string getProdutos = "SELECT * FROM tb_produtos";
                SqlCommand commDisponibilidades = new SqlCommand(getProdutos, conn);

                SqlDataReader prodRead = commDisponibilidades.ExecuteReader();

                if (prodRead.HasRows) {
                    listProdutos.Items.Clear();
                    while (prodRead.Read()) {
                        string nome_dev = Desenvolvedor.getNameById(prodRead.GetInt32(1), conn);
                        string desc_disp = Disponibilidade.getNameById(prodRead.GetInt32(2), conn);

                        string[] row = {
                            prodRead.GetInt32(0).ToString(),
                            prodRead.GetString(3),
                            nome_dev,
                            desc_disp,
                            prodRead.GetInt32(4).ToString(),
                            "R$ " + prodRead.GetDecimal(5).ToString("#.##")
                        };
                        ListViewItem item = new ListViewItem(row);
                        listProdutos.Items.Add(item);
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        private void txtEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void listProdutos_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listProdutos.Columns[e.ColumnIndex].Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void addToCart_Click(object sender, EventArgs e)
        {
            try {
                if(listProdutos.SelectedItems.Count > 0) {
                    ListViewItem selected = listProdutos.SelectedItems[0];

                    CarrinhoItem itemCart = new CarrinhoItem();
                    int codigo = Convert.ToInt32(selected.SubItems[0].Text);
                    itemCart.setCodigo(codigo);
                    itemCart.setQuantidade(1); // Caso seja feito um método para add mais itens de uma vez

                    Cart.addToCart(itemCart);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            try {
                if (listProdutos.SelectedItems.Count > 0) {
                    var selected = listProdutos.SelectedItems[0];

                    int codeToDelete = Convert.ToInt32(selected.SubItems[0].Text);
                    string nameToDelete = selected.SubItems[1].Text;

                    DialogResult confirm = MessageBox.Show("Tem certeza que deseja remover o produto \"" + nameToDelete + "\"?", "Remover produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (confirm == DialogResult.Yes) {
                        string sqlRemove = "DELETE FROM tb_produtos WHERE codigo = @codigo";
                        SqlCommand commRemove = new SqlCommand(sqlRemove, conn);
                        commRemove.Parameters.AddWithValue("@codigo", codeToDelete);

                        int genderDeleted = commRemove.ExecuteNonQuery();

                        if (genderDeleted > 0) {
                            string getProdutos = "SELECT * FROM tb_produtos";
                            SqlCommand commDisponibilidades = new SqlCommand(getProdutos, conn);

                            SqlDataReader prodRead = commDisponibilidades.ExecuteReader();

                            if (prodRead.HasRows) {
                                listProdutos.Items.Clear();
                                while (prodRead.Read()) {
                                    string nome_dev = Desenvolvedor.getNameById(prodRead.GetInt32(1), conn);
                                    string desc_disp = Disponibilidade.getNameById(prodRead.GetInt32(2), conn);

                                    string[] row = {
                                        prodRead.GetInt32(0).ToString(),
                                        prodRead.GetString(3),
                                        nome_dev,
                                        desc_disp,
                                        prodRead.GetInt32(4).ToString(),
                                        "R$ " + prodRead.GetDecimal(5).ToString("#.##")
                                    };
                                    ListViewItem item = new ListViewItem(row);
                                    listProdutos.Items.Add(item);
                                }
                            }

                            MessageBox.Show("Produto \"" + nameToDelete + "\" deletado com sucesso!", "Produto deletado");
                        }
                    }
                } else {
                    MessageBox.Show("Selecione um produto");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (listProdutos.SelectedItems.Count > 0) {
                var selected = listProdutos.SelectedItems[0];

                int codeToEdit = Convert.ToInt32(selected.SubItems[0].Text);
                EditProduct editProduct = new EditProduct(codeToEdit);
                editProduct.Show();
            } else {
                MessageBox.Show("Selecione um produto");
            }
        }

        private void AllProducts_FocusEnter(object sender, EventArgs e)
        {
            string getProdutos = "SELECT * FROM tb_produtos";
            SqlCommand commDisponibilidades = new SqlCommand(getProdutos, conn);

            SqlDataReader prodRead = commDisponibilidades.ExecuteReader();

            if (prodRead.HasRows) {
                listProdutos.Items.Clear();
                while (prodRead.Read()) {
                    string nome_dev = Desenvolvedor.getNameById(prodRead.GetInt32(1), conn);
                    string desc_disp = Disponibilidade.getNameById(prodRead.GetInt32(2), conn);

                    string[] row = {
                            prodRead.GetInt32(0).ToString(),
                            prodRead.GetString(3),
                            nome_dev,
                            desc_disp,
                            prodRead.GetInt32(4).ToString(),
                            "R$ " + prodRead.GetDecimal(5).ToString("#.##")
                        };
                    ListViewItem item = new ListViewItem(row);
                    listProdutos.Items.Add(item);
                }
            }
        }

        private void addNewProduct_Click(object sender, EventArgs e)
        {
            ProductsRegistration productsRegistration = new ProductsRegistration();
            productsRegistration.Show();
            this.Close();
        }
    }
}
