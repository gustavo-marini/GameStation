using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GameStation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClientsRegistration clientsRegistration = new ClientsRegistration();
                clientsRegistration.Show();
            }
            catch
            {
                //
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                CitiesRegistration citiesRegistration = new CitiesRegistration();
                citiesRegistration.Show();
            } catch {

            }
        }

        private void novoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductsRegistration productsRegistration = new ProductsRegistration();
            productsRegistration.Show();
        }

        private void cadastrarGêneroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Genders genders = new Genders();
            genders.Show();
        }

        private void cadastrarDesenvolvedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Developer developers = new Developer();
            developers.Show();
        }

        private void disponibilidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Availability availability = new Availability();
            availability.Show();
        }

        private void todosOsProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllProducts allProducts = new AllProducts();
            allProducts.Show();
        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProductsReport productsReport = new ProductsReport();
            productsReport.Show();
        }
    }
}
