using GameStation.Libs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStation
{
    public partial class EditProduct : Form
    {
        private int codigo = -1;
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;

        // Controle de edição
        bool hasLoadedImage = false;
        bool loadNewImage = false;
        string globalImageName = "";

        public EditProduct(int pk_value)
        {
            InitializeComponent();

            codigo = pk_value;
        }

        private void EditProduct_Load(object sender, EventArgs e)
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
                        cmbDesenvolvedor.Items.Add(new Desenvolvedor { codigo = devRead.GetInt32(0), nome = devRead.GetString(1) });
                    }
                }

                // Alimenta combobox de disponibilidades
                string getDisp = "SELECT * FROM tb_disponibilidades";
                SqlCommand commDisp = new SqlCommand(getDisp, conn);

                SqlDataReader dispRead = commDisp.ExecuteReader();

                if (dispRead.HasRows) {
                    while (dispRead.Read()) {
                        cmbDisponibilidade.Items.Add(new Disponibilidade { codigo = dispRead.GetInt32(0), dias = dispRead.GetInt32(1), descricao = dispRead.GetString(2) });
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

                    string sqlGenerosChecados = "SELECT * FROM tb_produtos_generos WHERE codigo_produto = @cod";
                    SqlCommand commandCheck = new SqlCommand(sqlGenerosChecados, conn);
                    commandCheck.Parameters.AddWithValue("@cod", codigo);
                    SqlDataReader readerCheck = commandCheck.ExecuteReader();

                    List<int> checkedIds = new List<int>();

                    if (readerCheck.HasRows) {
                        while (readerCheck.Read()) {
                            checkedIds.Add(readerCheck.GetInt32(2));
                        }
                    }


                    foreach (Genero genero in generos) {
                        bool check = checkedIds.Contains(genero.codigo);
                        checkListGeneros.Items.Add(genero, check);
                    }
                }


                // Completa os campos de edição
                string sqlProduct = "SELECT * FROM tb_produtos WHERE codigo = @codigo";
                SqlCommand prodCommand = new SqlCommand(sqlProduct, conn);
                prodCommand.Parameters.AddWithValue("@codigo", codigo);

                SqlDataReader pr = prodCommand.ExecuteReader();

                if (pr.HasRows) {
                    while (pr.Read()) {
                        txtNome.Text = pr.GetString(3);

                        // seta combobox do desenvolvedor
                        int codigo_dev = pr.GetInt32(1);
                        foreach(Desenvolvedor row in cmbDesenvolvedor.Items) {
                            if(row.codigo == codigo_dev) {
                                cmbDesenvolvedor.SelectedIndex = cmbDesenvolvedor.Items.IndexOf(row);
                            }
                        }

                        // seta combobox do disponibilidade
                        int codigo_disp = pr.GetInt32(2);
                        foreach (Disponibilidade row in cmbDisponibilidade.Items) {
                            if (row.codigo == codigo_disp) {
                                cmbDisponibilidade.SelectedIndex = cmbDisponibilidade.Items.IndexOf(row);
                            }
                        }

                        mskEstoque.Text = pr.GetInt32(4).ToString();
                        txtPreco.Text = pr.GetDecimal(5).ToString();
                        txtDescricao.Text = pr.GetString(6);

                        // carrega a imagem cadastrada para o produto
                        string sqlImagem = "SELECT * FROM tb_arquivos WHERE codigo_item = @codigo AND tabela = 'tb_produtos'";
                        SqlCommand commImagem = new SqlCommand(sqlImagem, conn);
                        commImagem.Parameters.AddWithValue("@codigo", codigo);
                        SqlDataReader readImagem = commImagem.ExecuteReader();

                        string path = @".\tb_produtos";
                        string product_path = path + "/" + codigo + "/";
                        string image_link = "";

                        if (readImagem.HasRows) {
                            if (readImagem.Read()) {
                                image_link = product_path + readImagem.GetString(3);
                                productImageBox.BackgroundImage = Image.FromFile(image_link);
                                hasLoadedImage = true;
                            }
                        } else {
                            hasLoadedImage = false;
                        }
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void saveEdit_Click(object sender, EventArgs e)
        {
            try {
                string nome = txtNome.Text;
                Desenvolvedor dev_item = cmbDesenvolvedor.SelectedItem as Desenvolvedor;
                int codigo_dev = dev_item.codigo;
                Disponibilidade disp_item = cmbDisponibilidade.SelectedItem as Disponibilidade;
                int codigo_disp = disp_item.codigo;
                int estoque = Convert.ToInt32(mskEstoque.Text);
                double preco = Convert.ToDouble(txtPreco.Text);
                string descricao = txtDescricao.Text;

                string updateProduto = "UPDATE tb_produtos SET codigo_desenvolvedor = @cod_dev, codigo_disponibilidade = @cod_disp, nome = @nome, estoque = @estoque, preco = @preco, descricao = @descricao WHERE codigo = @codigo";
                SqlCommand commandProduto = new SqlCommand(updateProduto, conn);
                commandProduto.Parameters.AddWithValue("@cod_dev", codigo_dev);
                commandProduto.Parameters.AddWithValue("@cod_disp", codigo_disp);
                commandProduto.Parameters.AddWithValue("@nome", nome);
                commandProduto.Parameters.AddWithValue("@estoque", estoque);
                commandProduto.Parameters.AddWithValue("@preco", preco);
                commandProduto.Parameters.AddWithValue("@descricao", descricao);
                commandProduto.Parameters.AddWithValue("@codigo", codigo);


                // Verifica se a imagem foi alterada e seta uma nova
                if (loadNewImage && globalImageName.Length > 0) {
                    // limpa imagens da pasta
                    string path = @".\tb_produtos";
                    string product_path = path + "/" + codigo + "/";
                    string image_link = "";
                    DirectoryInfo di = new DirectoryInfo(product_path);

                    foreach (FileInfo file in di.GetFiles()) {
                        try {
                            file.Delete();
                        } catch(Exception ex) {
                            Console.WriteLine("Image delete throw: " + ex.Message);
                        }
                    }

                    string iName = openImageDialog.SafeFileName;
                    string filepath = openImageDialog.FileName;

                    File.Copy(filepath, product_path + iName);


                    // Salvar imagem no banco
                    string sqlImagem = "SELECT * FROM tb_arquivos WHERE codigo_item = @cod_item AND tabela = 'tb_produtos'";
                    SqlCommand commImagem = new SqlCommand(sqlImagem, conn);
                    commImagem.Parameters.AddWithValue("@cod_item", codigo);

                    var checkImageExists = commImagem.ExecuteScalar();

                    if (checkImageExists != null) {
                        int codigoArquivo = Convert.ToInt32(checkImageExists);

                        string sqlUptArquivo = "UPDATE tb_arquivos SET arquivo = @arquivo, nome = @nome WHERE codigo_item = @codigo";
                        SqlCommand updateCommand = new SqlCommand(sqlUptArquivo, conn);
                        updateCommand.Parameters.AddWithValue("@arquivo", iName);
                        updateCommand.Parameters.AddWithValue("@nome", iName);
                        updateCommand.Parameters.AddWithValue("@codigo", codigo);

                        updateCommand.ExecuteNonQuery();
                    } else {
                        string sqlIstArquivo = "INSERT INTO tb_arquivos (codigo_item, nome, arquivo, tabela) VALUES (@cod_item, @nome, @arquivo, @tabela)";
                        SqlCommand insertCommand = new SqlCommand(sqlIstArquivo, conn);
                        insertCommand.Parameters.AddWithValue("@cod_item", codigo);
                        insertCommand.Parameters.AddWithValue("@nome", iName);
                        insertCommand.Parameters.AddWithValue("@arquivo", iName);
                        insertCommand.Parameters.AddWithValue("@tabela", "tb_produtos");

                        insertCommand.ExecuteNonQuery();
                    }
                }

                // Limpa todos os gêreros para o produto e coloca os selecionados (gambiarra mode)
                try {
                    string deleteGeneros = "DELETE FROM tb_produtos_generos WHERE codigo_produto = @codigo";
                    SqlCommand deleteCommand = new SqlCommand(deleteGeneros, conn);
                    deleteCommand.Parameters.AddWithValue("@codigo", codigo);
                    deleteCommand.ExecuteNonQuery();

                    foreach (Genero item in checkListGeneros.CheckedItems) {
                        int codigoItem = item.codigo;

                        string sqlGender = "INSERT INTO tb_produtos_generos (codigo_produto, codigo_genero) VALUES (@cod_prod, @cod_gen)";
                        SqlCommand comNewGender = new SqlCommand(sqlGender, conn);
                        comNewGender.Parameters.AddWithValue("@cod_prod", codigo);
                        comNewGender.Parameters.AddWithValue("@cod_gen", codigoItem);

                        comNewGender.ExecuteNonQuery();
                    }

                } catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }


                commandProduto.ExecuteNonQuery();

                AllProducts allProducts = new AllProducts();
                allProducts.Focus();
                this.Close();

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void loadImage_Click(object sender, EventArgs e)
        {
            try {
                openImageDialog.Title = "Carregar imagem do produto";
                openImageDialog.Filter = "Arquivo de imagem|*.bmp;*.png;*.jpg;*.jpeg;*.gif";

                if (openImageDialog.ShowDialog() == DialogResult.OK) {
                    string fileName = openImageDialog.FileName;

                    if (fileName != "") {
                        globalImageName = fileName;

                        productImageBox.BackgroundImage.Dispose();
                        productImageBox.BackgroundImage = Image.FromFile(fileName);

                        loadNewImage = true;
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
