using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStation.Libs
{
    class Desenvolvedor
    {
        public int codigo;
        public string nome;

        public override string ToString()
        {
            return nome;
        }

        public static int getIdByName(string name, SqlConnection conn)
        {
            string sql = "SELECT codigo FROM tb_desenvolvedor WHERE nome = @nome";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@nome", name);

            try {
                int codigo = Convert.ToInt32(command.ExecuteScalar());

                return codigo;
            } catch {
                return -1;
            }
        }
    }
}
