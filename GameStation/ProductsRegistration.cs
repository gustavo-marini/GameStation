using GameStation.Libs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GameStation
{
    public partial class ProductsRegistration : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;
        private List<Desenvolvedor> desenvolvedores = new List<Desenvolvedor>();
        private List<Disponibilidade> disponibilidades = new List<Disponibilidade>();
        private List<Genero> generos = new List<Genero>();
        private string globalImageName = "";

        public ProductsRegistration()
        {
            InitializeComponent();
        }

        private void ProductsRegistration_Load(object sender, EventArgs e)
        {
            try {
                conn = new SqlConnection(connectionString);
                conn.Open();

                string sqlDesenvolvedor = "SELECT * FROM tb_desenvolvedor";
                SqlCommand commandDes = new SqlCommand(sqlDesenvolvedor, conn);
                SqlDataReader er = commandDes.ExecuteReader();

                if (er.HasRows) {
                    while (er.Read()) {
                        Desenvolvedor desenvolvedor = new Desenvolvedor {
                            codigo = er.GetInt32(0),
                            nome = er.GetString(1).ToString()
                        };
                        desenvolvedores.Add(desenvolvedor);
                    }

                    desenvolvedores = desenvolvedores.OrderBy(o => o.nome).ToList();

                    foreach (Desenvolvedor desenvolvedor in desenvolvedores) {
                        cmbDesenvolvedor.Items.Add(desenvolvedor);
                    }
                }



                string sqlDisponibilidade = "SELECT * FROM tb_disponibilidades";
                SqlCommand commandDis = new SqlCommand(sqlDisponibilidade, conn);
                SqlDataReader dr = commandDis.ExecuteReader();

                if (dr.HasRows) {
                    while (dr.Read()) {
                        Disponibilidade disponibilidade = new Disponibilidade {
                            codigo = dr.GetInt32(0),
                            dias = dr.GetInt32(1),
                            descricao = dr.GetString(2).ToString()
                        };
                        disponibilidades.Add(disponibilidade);
                    }

                    //disponibilidades = disponibilidades.OrderBy(o => o.descricao).ToList();

                    foreach (Disponibilidade disponibilidade in disponibilidades) {
                        cmbDisponibilidade.Items.Add(disponibilidade);
                    }
                }




                string sqlGeneros = "SELECT * FROM tb_generos";
                SqlCommand commandGeneros = new SqlCommand(sqlGeneros, conn);
                SqlDataReader gr = commandGeneros.ExecuteReader();

                if (gr.HasRows) {
                    while (gr.Read()) {
                        Genero genero = new Genero {
                            codigo = gr.GetInt32(0),
                            nome = gr.GetString(1).ToString()
                        };
                        generos.Add(genero);
                    }

                    generos = generos.OrderBy(o => o.nome).ToList();

                    for (int i=0; i<generos.Count-1; i++) {
                        checkListGeneros.Items.Add(generos[i]);
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }


        string str = "";
        private void txtPreco_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            int KeyCode = e.KeyValue;

            if (!IsNumeric(KeyCode)) {
                e.Handled = true;
                return;
            } else {
                e.Handled = true;
            }
            if (((KeyCode == 8) || (KeyCode == 46)) && (str.Length > 0)) {
                str = str.Substring(0, str.Length - 1);
            } else if (!((KeyCode == 8) || (KeyCode == 46))) {
                str = str + Convert.ToChar(KeyCode);
            }
            if (str.Length == 0) {
                txtPreco.Text = "";
            }
            if (str.Length == 1) {
                txtPreco.Text = "0.0" + str;
            } else if (str.Length == 2) {
                txtPreco.Text = "0." + str;
            } else if (str.Length > 2) {
                txtPreco.Text = str.Substring(0, str.Length - 2) + "." +
                                str.Substring(str.Length - 2);
            }
        }

        private bool IsNumeric(int Val)
        {
            return ((Val >= 48 && Val <= 57) || (Val == 8) || (Val == 46));
        }

        private void txtPreco_KeyPress(object sender,
                System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            try {
                Validate val = new Validate();

                bool validateNome = val.Required(txtNome, "Nome");
                bool validateDes = (cmbDesenvolvedor.SelectedItem != null);
                bool validateDisp = (cmbDisponibilidade.SelectedItem != null);
                bool validateEstoque = mskEstoque.Text.Length != 0;
                bool validatePreco = txtPreco.Text.Length != 0;

                if(validateNome && validateDes && validateDisp && validateEstoque && validatePreco) {

                    // Before insert
                    Desenvolvedor desSelect = cmbDesenvolvedor.SelectedItem as Desenvolvedor;
                    Disponibilidade dispSelect = cmbDisponibilidade.SelectedItem as Disponibilidade;

                    int codigo_desenvolvedor = desSelect.codigo;
                    int codigo_disponibilidade = dispSelect.codigo;
                    string nome = txtNome.Text.ToString();
                    int estoque = Convert.ToInt32(mskEstoque.Text.ToString());
                    double preco = Convert.ToDouble(txtPreco.Text.ToString().Replace(".", ","));
                    string descricao = txtDescricao.Text.ToString();


                    string sqlInsert = "INSERT INTO tb_produtos (codigo_desenvolvedor, codigo_disponibilidade, nome, estoque, preco, descricao) OUTPUT INSERTED.codigo VALUES (@cod_des, @cod_disp, @nome, @estoque, @preco, @descricao)";
                    SqlCommand commandProduto = new SqlCommand(sqlInsert, conn);
                    commandProduto.Parameters.AddWithValue("@cod_des", codigo_desenvolvedor);
                    commandProduto.Parameters.AddWithValue("@cod_disp", codigo_disponibilidade);
                    commandProduto.Parameters.AddWithValue("@nome", nome);
                    commandProduto.Parameters.AddWithValue("@estoque", estoque);
                    commandProduto.Parameters.AddWithValue("@preco", preco);
                    commandProduto.Parameters.AddWithValue("@descricao", descricao);

                    var codigoInserido = commandProduto.ExecuteScalar();

                    // After insert
                    if (codigoInserido != null) {

                        codigoInserido = Convert.ToInt32(codigoInserido);


                        // Inserir gêneros
                        List<int> checkedItems = new List<int>();

                        foreach(object item in checkListGeneros.CheckedItems) {
                            int codigoItem = Genero.getIdByName(item.ToString(), conn);

                            string sqlGender = "INSERT INTO tb_produtos_generos (codigo_produto, codigo_genero) VALUES (@cod_prod, @cod_gen)";
                            SqlCommand comNewGender = new SqlCommand(sqlGender, conn);
                            comNewGender.Parameters.AddWithValue("@cod_prod", codigoInserido);
                            comNewGender.Parameters.AddWithValue("@cod_gen", codigoItem);

                            comNewGender.ExecuteNonQuery();
                        }


                        // Salvar imagem do produto
                        if (globalImageName != "") {
                            string path = @".\tb_produtos";
                            string product_path = path + "/" + codigoInserido + "/";

                            if (!Directory.Exists(path)) {
                                Directory.CreateDirectory(path);
                            }
                            if (!Directory.Exists(product_path)) {
                                Directory.CreateDirectory(product_path);
                            }

                            try {
                                string iName = openImageDialog.SafeFileName;
                                string filepath = openImageDialog.FileName;
                                
                                File.Copy(filepath, product_path + iName);


                                // Salvar imagem no banco
                                string sqlImagem = "SELECT * FROM tb_arquivos WHERE codigo_item = @cod_item AND tabela = 'tb_produtos'";
                                SqlCommand commImagem = new SqlCommand(sqlImagem, conn);
                                commImagem.Parameters.AddWithValue("@cod_item", codigoInserido);

                                var checkImageExists = commImagem.ExecuteScalar();

                                if(checkImageExists != null) {
                                    int codigoArquivo = Convert.ToInt32(checkImageExists);

                                    string sqlUptArquivo = "UPDATE tb_arquivos SET arquivo = @arquivo, nome = @nome";
                                    SqlCommand updateCommand = new SqlCommand(sqlUptArquivo, conn);
                                    updateCommand.Parameters.AddWithValue("@arquivo", iName);
                                    updateCommand.Parameters.AddWithValue("@nome", iName);

                                    updateCommand.ExecuteNonQuery();
                                } else {
                                    string sqlIstArquivo = "INSERT INTO tb_arquivos (codigo_item, nome, arquivo, tabela) VALUES (@cod_item, @nome, @arquivo, @tabela)";
                                    SqlCommand insertCommand = new SqlCommand(sqlIstArquivo, conn);
                                    insertCommand.Parameters.AddWithValue("@cod_item", codigoInserido);
                                    insertCommand.Parameters.AddWithValue("@nome", iName);
                                    insertCommand.Parameters.AddWithValue("@arquivo", iName);
                                    insertCommand.Parameters.AddWithValue("@tabela", "tb_produtos");

                                    insertCommand.ExecuteNonQuery();
                                }
                            } catch(Exception ex) {
                                Console.WriteLine("Erro: " + ex.Message);
                            }
                            
                        }
                    }
                }

            } catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void loadImage_Click(object sender, EventArgs e)
        {
            try {
                openImageDialog.Title = "Carregar imagem do produto";
                openImageDialog.Filter = "Arquivo de imagem|*.bmp;*.png;*.jpg;*.jpeg;*.gif";
                
                if(openImageDialog.ShowDialog() == DialogResult.OK) {
                    string fileName = openImageDialog.FileName;

                    if(fileName != "") {
                        globalImageName = fileName;

                        productImageBox.BackgroundImage = Image.FromFile(fileName);
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
