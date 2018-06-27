using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStation.Libs
{
    class Produto : AppModel
    {
        public int codigo, codigo_desenvolvedor, codigo_disponibilidade, estoque;
        public double preco;
        public string nome, descricao;

        public override string ToString()
        {
            return nome;
        }

        public bool inStock()
        {
            string sql = "SELECT estoque FROM tb_produtos WHERE codigo = @cod";
            SqlCommand comm = new SqlCommand(sql, base.getConn());
            comm.Parameters.AddWithValue("@cod", this.codigo);

            try {
                int estoque = Convert.ToInt32(comm.ExecuteScalar());

                return estoque > 0;
            } catch {
                return false;
            }
        }

        public bool available()
        {
            string sql = "SELECT codigo_disponibilidade FROM tb_produtos WHERE codigo = @cod";
            SqlCommand comm = new SqlCommand(sql, base.getConn());
            comm.Parameters.AddWithValue("@cod", this.codigo);

            try {
                int disp = Convert.ToInt32(comm.ExecuteScalar());

                return disp != 9;
            } catch {
                return false;
            }
        }

        public string getNome()
        {
            string sql = "SELECT nome FROM tb_produtos WHERE codigo = @cod";
            SqlCommand comm = new SqlCommand(sql, base.getConn());
            comm.Parameters.AddWithValue("@cod", this.codigo);

            try {
                string nome = comm.ExecuteScalar().ToString();

                return nome;
            } catch {
                return "";
            }
        }

        public double getPreco()
        {
            string sql = "SELECT preco FROM tb_produtos WHERE codigo = @cod";
            SqlCommand comm = new SqlCommand(sql, base.getConn());
            comm.Parameters.AddWithValue("@cod", this.codigo);

            try {
                double preco = Convert.ToDouble(comm.ExecuteScalar());

                return preco;
            } catch {
                return 0;
            }
        }

        public Produto setEstoque(int estoque)
        {
            string sql = "UPDATE tb_produtos SET estoque = @estoque WHERE codigo = @cod";
            SqlCommand comm = new SqlCommand(sql, base.getConn());
            comm.Parameters.AddWithValue("@estoque", estoque);
            comm.Parameters.AddWithValue("@cod", this.codigo);

            try {
                comm.ExecuteNonQuery();

                return this;
            } catch {
                return this;
            }
        }

        public int getEstoque()
        {
            string sql = "SELECT estoque FROM tb_produtos WHERE codigo = @cod";
            SqlCommand comm = new SqlCommand(sql, base.getConn());
            comm.Parameters.AddWithValue("@cod", this.codigo);

            try {
                int estoque = Convert.ToInt32(comm.ExecuteScalar());

                return estoque;
            } catch {
                return 0;
            }
        }
    }
}
