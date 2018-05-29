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
    public partial class AllProducts : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;

        public AllProducts()
        {
            InitializeComponent();
        }

        private void AllProducts_Load(object sender, EventArgs e)
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
    }
}
