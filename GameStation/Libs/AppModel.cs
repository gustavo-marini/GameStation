using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStation.Libs
{
    public class AppModel
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;

        public AppModel()
        {
            try {
                conn = new SqlConnection(connectionString);
                conn.Open();
            } catch (Exception ex) {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        public SqlConnection getConn()
        {
            return conn;
        }
    }
}
