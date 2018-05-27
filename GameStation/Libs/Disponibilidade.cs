using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStation.Libs
{
    class Disponibilidade
    {
        public int codigo, dias;
        public string descricao;

        public override string ToString()
        {
            return descricao;
        }

        public static int getIdByName(string descricao, SqlConnection conn)
        {
            string sql = "SELECT codigo FROM tb_disponibilidades WHERE descricao = @descricao";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@descricao", descricao);

            try {
                int codigo = Convert.ToInt32(command.ExecuteScalar());

                return codigo;
            } catch {
                return -1;
            }
        }
    }
}
