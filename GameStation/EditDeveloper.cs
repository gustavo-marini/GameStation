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
    public partial class EditDeveloper : Form
    {
        private int code_to_edit;
        private string name_to_edit;
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;

        public EditDeveloper(int code, string name)
        {
            this.code_to_edit = code;
            this.name_to_edit = name;

            InitializeComponent();
        }

        private void EditDeveloper_Load(object sender, EventArgs e)
        {
            try {
                if (name_to_edit.Length > 0) {
                    txtName.Text = name_to_edit;
                }

                conn = new SqlConnection(connectionString);
                conn.Open();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try {
                string updateDeveloper = "UPDATE tb_desenvolvedor SET nome = @nome WHERE codigo = @codigo";
                SqlCommand updCommand = new SqlCommand(updateDeveloper, conn);
                updCommand.Parameters.AddWithValue("@nome", txtName.Text.ToString());
                updCommand.Parameters.AddWithValue("@codigo", code_to_edit);

                updCommand.ExecuteNonQuery();

                Developer developersForm = new Developer();
                developersForm.Focus();
                this.Close();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
