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
    public partial class EditGender : Form
    {
        private int code_to_edit;
        private string name_to_edit;
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;

        public EditGender(int code, string name)
        {
            this.code_to_edit = code;
            this.name_to_edit = name;

            InitializeComponent();
        }

        private void EditGender_Load(object sender, EventArgs e)
        {
            try {
                if(name_to_edit.Length > 0) {
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
                string updateGender = "UPDATE tb_generos SET nome = @nome WHERE codigo = @codigo";
                SqlCommand updCommand = new SqlCommand(updateGender, conn);
                updCommand.Parameters.AddWithValue("@nome", txtName.Text.ToString());
                updCommand.Parameters.AddWithValue("@codigo", code_to_edit);

                updCommand.ExecuteNonQuery();

                Genders gendersForm = new Genders();
                gendersForm.Focus();
                this.Close();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
