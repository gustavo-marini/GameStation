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
    public partial class Sales : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;

        public Sales()
        {
            InitializeComponent();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            try {
                conn = new SqlConnection(connectionString);
                conn.Open();

                // Alimenta toda a lista de produtos
                string getProdutos = "SELECT * FROM tb_produtos";
                SqlCommand commProd = new SqlCommand(getProdutos, conn);

                SqlDataReader prodRead = commProd.ExecuteReader();

                if (prodRead.HasRows) {
                    listProdutos.Items.Clear();
                    while (prodRead.Read()) {
                        string nome_dev = Desenvolvedor.getNameById(prodRead.GetInt32(1), conn);
                        string desc_disp = Disponibilidade.getNameById(prodRead.GetInt32(2), conn);

                        string[] row = {
                            prodRead.GetInt32(0).ToString(),
                            prodRead.GetString(3),
                            prodRead.GetInt32(4).ToString(),
                            desc_disp,
                            "R$ " + prodRead.GetDecimal(5).ToString("#.##")
                        };
                        ListViewItem item = new ListViewItem(row);
                        listProdutos.Items.Add(item);
                    }
                }


                // Alimenta lista do carrinho
                List<CarrinhoItem> items = MainForm.Cart.getItems();

                int totalItens = 0;
                double totalPreco = 0.0;

                foreach(CarrinhoItem item in items) {
                    Produto produto = new Produto();
                    produto.codigo = item.getCodigo();

                    string[] rowCart = {
                        item.getCodigo().ToString(),
                        produto.getNome(),
                        item.getQuantidade().ToString(),
                        "R$ " + produto.getPreco().ToString("#.##")
                    };
                    ListViewItem row = new ListViewItem(rowCart);
                    listCarrinho.Items.Add(row);

                    totalItens += item.getQuantidade();
                    totalPreco += (produto.getPreco() * item.getQuantidade());
                }

                txtTotalItems.Text = totalItens.ToString();
                txtTotalPrice.Text = "R$ " + totalPreco.ToString("#.##");
            } catch (Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }


        private void listProdutos_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listProdutos.Columns[e.ColumnIndex].Width;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 0) {
                string getProdutos = "SELECT * FROM tb_produtos";
                SqlCommand commProd = new SqlCommand(getProdutos, conn);

                SqlDataReader prodRead = commProd.ExecuteReader();

                if (prodRead.HasRows) {
                    listProdutos.Items.Clear();
                    while (prodRead.Read()) {
                        string nome_dev = Desenvolvedor.getNameById(prodRead.GetInt32(1), conn);
                        string desc_disp = Disponibilidade.getNameById(prodRead.GetInt32(2), conn);

                        string[] row = {
                            prodRead.GetInt32(0).ToString(),
                            prodRead.GetString(3),
                            prodRead.GetInt32(4).ToString(),
                            desc_disp,
                            "R$ " + prodRead.GetDecimal(5).ToString("#.##")
                        };
                        ListViewItem item = new ListViewItem(row);
                        listProdutos.Items.Add(item);
                    }
                } else {
                    listProdutos.Items.Clear();
                }
            } else {
                string getProdutos = "SELECT * FROM tb_produtos WHERE nome LIKE @nome";
                SqlCommand commProd = new SqlCommand(getProdutos, conn);
                commProd.Parameters.AddWithValue("@nome", "%" + textBox1.Text + "%");

                SqlDataReader prodRead = commProd.ExecuteReader();

                if (prodRead.HasRows) {
                    listProdutos.Items.Clear();
                    while (prodRead.Read()) {
                        string nome_dev = Desenvolvedor.getNameById(prodRead.GetInt32(1), conn);
                        string desc_disp = Disponibilidade.getNameById(prodRead.GetInt32(2), conn);

                        string[] row = {
                            prodRead.GetInt32(0).ToString(),
                            prodRead.GetString(3),
                            prodRead.GetInt32(4).ToString(),
                            desc_disp,
                            "R$ " + prodRead.GetDecimal(5).ToString("#.##")
                        };
                        ListViewItem item = new ListViewItem(row);
                        listProdutos.Items.Add(item);
                    }
                } else {
                    listProdutos.Items.Clear();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listProdutos.SelectedItems.Count > 0) {
                int codigo = Convert.ToInt32(listProdutos.SelectedItems[0].SubItems[0].Text);
                Produto prod = new Produto();
                prod.codigo = codigo;

                if (prod.inStock() && prod.available()) {
                    CarrinhoItem item = new CarrinhoItem();
                    item.setCodigo(prod.codigo);
                    item.setQuantidade(1);

                    MainForm.Cart.addToCart(item);


                    listCarrinho.Items.Clear();

                    // Alimenta lista do carrinho
                    List<CarrinhoItem> items = MainForm.Cart.getItems();

                    int totalItens = 0;
                    double totalPreco = 0.0;

                    foreach (CarrinhoItem cart_item in items) {
                        Produto produto = new Produto();
                        produto.codigo = cart_item.getCodigo();

                        string[] rowCart = {
                            cart_item.getCodigo().ToString(),
                            produto.getNome(),
                            cart_item.getQuantidade().ToString(),
                            "R$ " + produto.getPreco().ToString("#.##")
                        };
                        ListViewItem row = new ListViewItem(rowCart);
                        listCarrinho.Items.Add(row);

                        totalItens += cart_item.getQuantidade();
                        totalPreco += (produto.getPreco() * cart_item.getQuantidade());
                    }

                    txtTotalItems.Text = totalItens.ToString();
                    txtTotalPrice.Text = "R$ " + totalPreco.ToString("#.##");
                }
            } else {
                MessageBox.Show("Selecione um produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
