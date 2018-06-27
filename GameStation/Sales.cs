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
                        "R$ " + (produto.getPreco() * item.getQuantidade()).ToString("#.##")
                    };
                    ListViewItem row = new ListViewItem(rowCart);
                    listCarrinho.Items.Add(row);

                    totalItens += item.getQuantidade();
                    totalPreco += (produto.getPreco() * item.getQuantidade());
                }

                txtTotalItems.Text = totalItens.ToString();
                txtTotalPrice.Text = "R$ " + totalPreco.ToString("#.##");



                // Alimenta select de clientes
                string sqlCli = "SELECT * FROM tb_clientes";
                SqlCommand cliComm = new SqlCommand(sqlCli, conn);

                SqlDataReader readCli = cliComm.ExecuteReader();

                if (readCli.HasRows) {
                    while (readCli.Read()) {
                        Cliente cliente = new Cliente {
                            codigo = readCli.GetInt32(0),
                            nome = readCli.GetString(4),
                            sobrenome = readCli.GetString(5)
                        };

                        comboBox1.Items.Add(cliente);
                    }
                }
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
                            "R$ " + (produto.getPreco() * cart_item.getQuantidade()).ToString("#.##")
                        };
                        ListViewItem row = new ListViewItem(rowCart);
                        listCarrinho.Items.Add(row);

                        totalItens += cart_item.getQuantidade();
                        totalPreco += (produto.getPreco() * cart_item.getQuantidade());
                    }

                    txtTotalItems.Text = totalItens.ToString();
                    txtTotalPrice.Text = "R$ " + totalPreco.ToString("#.##");
                } else {
                    MessageBox.Show("O produto escolhido está sem estoque ou indisponível");
                }
            } else {
                MessageBox.Show("Selecione um produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void listCarrinho_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                if (listCarrinho.FocusedItem.Bounds.Contains(e.Location) == true) {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listCarrinho.SelectedItems.Count > 0) {
                ListViewItem selected = listCarrinho.SelectedItems[0];

                int codigo = Convert.ToInt32(selected.SubItems[0].Text);

                MainForm.Cart.removeItem(codigo);

                // Alimenta lista do carrinho
                listCarrinho.Items.Clear();
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
                            "R$ " + (produto.getPreco() * cart_item.getQuantidade()).ToString("#.##")
                        };
                    ListViewItem row = new ListViewItem(rowCart);
                    listCarrinho.Items.Add(row);

                    totalItens += cart_item.getQuantidade();
                    totalPreco += (produto.getPreco() * cart_item.getQuantidade());
                }

                txtTotalItems.Text = totalItens.ToString();
                txtTotalPrice.Text = "R$ " + totalPreco.ToString("#.##");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                int codigo_funcionario = MainForm.loggedUser.codigo;
                int codigo_cliente = -1;
                if (comboBox1.SelectedItem.ToString() != "") {
                    Cliente c = comboBox1.SelectedItem as Cliente;
                    codigo_cliente = c.codigo;
                }
                double total = Convert.ToDouble(txtTotalPrice.Text.Replace("R$ ", "").Trim());


                string sqlVenda = "INSERT INTO tb_vendas (codigo_funcionario, codigo_cliente, data_venda, total) OUTPUT INSERTED.codigo VALUES (@codfun, @codcli, @data_venda, @total)";
                SqlCommand vendaComm = new SqlCommand(sqlVenda, conn);
                vendaComm.Parameters.AddWithValue("@codfun", codigo_funcionario);
                vendaComm.Parameters.AddWithValue("@codcli", codigo_cliente);
                vendaComm.Parameters.AddWithValue("@data_venda", DateTime.Now);
                vendaComm.Parameters.AddWithValue("@total", total);

                var result = vendaComm.ExecuteScalar();

                if (result != null) {
                    MessageBox.Show("Venda realizada sucesso.");

                    int codigo_venda = Convert.ToInt32(result);


                    foreach(CarrinhoItem item in MainForm.Cart.getItems()) {
                        int codigo = item.getCodigo();
                        int quantidade = item.getQuantidade();

                        Produto prod = new Produto();
                        prod.codigo = codigo;
                        double total_item = prod.getPreco() * quantidade;

                        string sqlItem = "INSERT INTO tb_itens_venda (codigo_produto, codigo_venda, quantidade, total) VALUES(@cp, @cv, @q, @t)";
                        SqlCommand itemComm = new SqlCommand(sqlItem, conn);
                        itemComm.Parameters.AddWithValue("@cp", codigo);
                        itemComm.Parameters.AddWithValue("@cv", codigo_venda);
                        itemComm.Parameters.AddWithValue("@q", quantidade);
                        itemComm.Parameters.AddWithValue("@t", total_item);

                        itemComm.ExecuteNonQuery();



                        // Retirar estoque do produto
                        prod.setEstoque(prod.getEstoque() - item.getQuantidade());

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
                                ListViewItem list_item = new ListViewItem(row);
                                listProdutos.Items.Add(list_item);
                            }
                        }
                    }
                } else {
                    MessageBox.Show("Alguns campos foram preenchidos incorretamente.");
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
