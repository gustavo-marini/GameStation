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
    public partial class EditAvailability : Form
    {
        private int code_to_edit, days_to_edit;
        private string description_to_edit;
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=db_gamestation;Integrated Security=True;MultipleActiveResultSets=true;";
        private SqlConnection conn;

        public EditAvailability(int code, int days, string name)
        {
            this.code_to_edit = code;
            this.days_to_edit = days;
            this.description_to_edit = name;

            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try {
                string updateAvailability = "UPDATE tb_disponibilidades SET dias = @dias, descricao = @descricao WHERE codigo = @codigo";
                SqlCommand updCommand = new SqlCommand(updateAvailability, conn);
                updCommand.Parameters.AddWithValue("@dias", Convert.ToInt32(txtDias.Text.ToString()));
                updCommand.Parameters.AddWithValue("@descricao", txtDescricao.Text.ToString());
                updCommand.Parameters.AddWithValue("@codigo", code_to_edit);

                updCommand.ExecuteNonQuery();

                Availability availabilityForm = new Availability();
                availabilityForm.Focus();
                this.Close();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void EditAvailability_Load(object sender, EventArgs e)
        {
            try {
                txtDias.Text = days_to_edit.ToString();

                if (description_to_edit.Length > 0) {
                    txtDescricao.Text = description_to_edit;
                }

                conn = new SqlConnection(connectionString);
                conn.Open();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }
    }
}
