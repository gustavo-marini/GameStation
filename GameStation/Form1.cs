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
using GameStation.Libs;

namespace GameStation
{
    public partial class MainForm : Form
    {
        public static Usuario loggedUser = null;
        public static Carrinho Cart = null;

        public MainForm(Usuario user)
        {
            loggedUser = user;
            InitializeComponent();
        }
        

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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

        private void novoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientsRegistration clientsRegistration = new ClientsRegistration();
            clientsRegistration.Show();
        }

        private void todosOsClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllClients allClients = new AllClients();
            allClients.Show();
        }

        private void novoFuncionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeesRegistration employeesRegistration = new EmployeesRegistration();
            employeesRegistration.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text += loggedUser.nome + (loggedUser.codigo_acesso == 1? " (Administrador)": " (Funcionário)");
            Cart = new Carrinho();

            if(loggedUser.codigo_acesso == 2) {
                funcionáriosToolStripMenuItem.Visible = false;
                funcionáriosToolStripMenuItem1.Visible = false;
            }
        }

        private void novaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales();
            sales.Show();
        }

        private void funcionáriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EmployessReport employessReport = new EmployessReport();
            employessReport.Show();
        }

        private void novaCidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CitiesRegistration citiesRegistration = new CitiesRegistration();
            citiesRegistration.Show();
        }

        private void todasAsCidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllCities allCities = new AllCities();
            allCities.Show();
        }
    }
}
