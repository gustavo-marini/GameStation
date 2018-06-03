using GameStation.Libs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace GameStation
{
    public partial class ProductsReport : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;

        public ProductsReport()
        {
            InitializeComponent();
            this.listProdutos.ListViewItemSorter = new ListViewItemComparer();
        }

        private void ProductsReport_Load(object sender, EventArgs e)
        {
            try {
                conn = new SqlConnection(connectionString);
                conn.Open();

                // Alimenta combobox de desenvolvedores
                string getDev = "SELECT * FROM tb_desenvolvedor";
                SqlCommand commDevs = new SqlCommand(getDev, conn);

                SqlDataReader devRead = commDevs.ExecuteReader();

                if (devRead.HasRows) {
                    while (devRead.Read()) {
                        cmbDevFiltro.Items.Add(new Desenvolvedor { codigo = devRead.GetInt32(0), nome = devRead.GetString(1) });
                    }
                }

                // Alimenta combobox de disponibilidades
                string getDisp = "SELECT * FROM tb_disponibilidades";
                SqlCommand commDisp = new SqlCommand(getDisp, conn);

                SqlDataReader dispRead = commDisp.ExecuteReader();

                if (dispRead.HasRows) {
                    while (dispRead.Read()) {
                        cmbDispFiltro.Items.Add(new Disponibilidade { codigo = dispRead.GetInt32(0), dias = dispRead.GetInt32(1), descricao = dispRead.GetString(2) });
                    }
                }

                // Alimenta checklistbox de gêneros
                string sqlGeneros = "SELECT * FROM tb_generos";
                SqlCommand commandGeneros = new SqlCommand(sqlGeneros, conn);
                SqlDataReader gr = commandGeneros.ExecuteReader();

                if (gr.HasRows) {
                    List<Genero> generos = new List<Genero>();
                    while (gr.Read()) {
                        Genero genero = new Genero {
                            codigo = gr.GetInt32(0),
                            nome = gr.GetString(1).ToString()
                        };
                        generos.Add(genero);
                    }

                    generos = generos.OrderBy(o => o.nome).ToList();

                    for (int i = 0; i < generos.Count - 1; i++) {
                        checkListGenFiltro.Items.Add(generos[i]);
                    }
                }


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
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conditions = "";
            bool where = false;

            string filtroNome = "";
            int filtroDev = -1;
            int filtroDisp = -1;
            int filtroEstoque = -1;
            double filtroPreco = -1;
            List<int> checkedList = new List<int>();

            if (txtNomeFiltro.Text.Length > 0) {
                filtroNome = txtNomeFiltro.Text;
                conditions += " p.nome LIKE @nome AND ";
                where = true;
            }

            if (cmbDevFiltro.SelectedItem != null) {
                var item = cmbDevFiltro.SelectedItem as Desenvolvedor;
                filtroDev = item.codigo;
                conditions += " p.codigo_desenvolvedor = @cod_dev AND ";
                where = true;
            }

            if (cmbDispFiltro.SelectedItem != null) {
                var item = cmbDispFiltro.SelectedItem as Disponibilidade;
                filtroDisp = item.codigo;
                conditions += " p.codigo_disponibilidade = @cod_disp AND ";
                where = true;
            }

            if (txtEstoqueFiltro.Text.Length > 0 && Convert.ToInt32(txtEstoqueFiltro.Text) >= 0) {
                filtroEstoque = Convert.ToInt32(txtEstoqueFiltro.Text);
                conditions += " p.estoque = @estoque AND ";
                where = true;
            }

            if (txtPrecoFiltro.Text.Length > 0 && Convert.ToDouble(txtPrecoFiltro.Text) >= 0) {
                filtroPreco = Convert.ToDouble(txtPrecoFiltro.Text);
                conditions += " p.preco = @preco AND ";
                where = true;
            }

            if (checkListGenFiltro.CheckedItems.Count > 0) {
                CheckedItemCollection checkedItems = checkListGenFiltro.CheckedItems;
                foreach (Genero item in checkedItems) {
                    int codigo = item.codigo;
                    checkedList.Add(codigo);
                }
                conditions += " p.codigo IN (SELECT pg.codigo_produto FROM tb_produtos_generos AS pg WHERE pg.codigo_genero IN (@generos_list)) AND ";
            }

            conditions = conditions.Trim();
            // Remove último 'AND' da string
            string[] tmp = conditions.Split(' ');
            conditions = String.Join(" ", tmp.Take(tmp.Length - 1).ToArray());


            string sqlFiltro = "SELECT * FROM tb_produtos AS p ";
            if (where) {
                sqlFiltro += " WHERE ";
                sqlFiltro += conditions;
            }

            SqlCommand commandFiltro = new SqlCommand(sqlFiltro, conn);
            if (filtroNome != "") commandFiltro.Parameters.AddWithValue("@nome", filtroNome + "%");
            if (filtroDev != -1) commandFiltro.Parameters.AddWithValue("@cod_dev", filtroDev);
            if (filtroDisp != -1) commandFiltro.Parameters.AddWithValue("@cod_disp", filtroDisp);
            if (filtroEstoque != -1) commandFiltro.Parameters.AddWithValue("@estoque", filtroEstoque);
            if (filtroPreco != -1) commandFiltro.Parameters.AddWithValue("@preco", filtroPreco);
            if (checkedList.Count > 0) commandFiltro.Parameters.AddWithValue("@generos_list", String.Join(", ", checkedList.ToArray()));

            try {
                SqlDataReader filtroReader = commandFiltro.ExecuteReader();

                if (filtroReader.HasRows) {
                    listProdutos.Items.Clear();

                    while (filtroReader.Read()) {
                        string codigo = filtroReader.GetInt32(0).ToString();
                        string nome = filtroReader.GetString(3);
                        string dev = Desenvolvedor.getNameById(filtroReader.GetInt32(1), conn);
                        string disp = Disponibilidade.getNameById(filtroReader.GetInt32(2), conn);
                        string estoque = filtroReader.GetInt32(4).ToString();
                        string preco = "R$ " + filtroReader.GetDecimal(5).ToString("#.##");

                        string[] row = { codigo, nome, dev, disp, estoque, preco };
                        ListViewItem item = new ListViewItem(row);
                        listProdutos.Items.Add(item);
                    }
                } else {
                    listProdutos.Items.Clear();
                }
            } catch (SqlException ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void listProdutos_ColumnClick(object o, ColumnClickEventArgs e)
        {
            ListViewItemComparer comparer = (ListViewItemComparer)listProdutos.ListViewItemSorter;

            if (e.Column == comparer.Column) {
                comparer.Order = comparer.Swap(comparer.Order);
            } else {
                comparer.Order = System.Windows.Forms.SortOrder.Ascending;
            }

            comparer.Column = e.Column;
            listProdutos.Sort();
        }
    }
}
