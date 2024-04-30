using MySql.Data.MySqlClient;
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

namespace Sistma_Bancario
{
    public partial class CCliente : Form
    {
        string cx = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=sis_banco;Data Source=DOM-MBIYA";
        public CCliente()
        {
            InitializeComponent();
            txt_conta.KeyPress += new KeyPressEventHandler(txt_conta_KeyPress);
            txt_saldo.KeyPress += new KeyPressEventHandler(txt_saldo_KeyPress);
            txt_contacto.KeyPress += new KeyPressEventHandler(txt_contacto_KeyPress);

        }

        private void xuiButton4_Click(object sender, EventArgs e)
        {
            add_cliente();
        }
        private void add_cliente()
        {

            
            string proc = "add_cliente";
            SqlConnection Cn = new SqlConnection();
            Cn.ConnectionString = cx;
            SqlCommand comando = new SqlCommand(proc, Cn);
            comando.Parameters.AddWithValue("@Nome", txt_nome.Text);
            comando.Parameters.AddWithValue("@BI", txt_bi.Text);
            comando.Parameters.AddWithValue("@Conta", int.Parse(txt_conta.Text));
            comando.Parameters.AddWithValue("@Saldo", decimal.Parse(txt_saldo.Text));
            comando.Parameters.AddWithValue("@Contacto", int.Parse(txt_contacto.Text));
            comando.Parameters.AddWithValue("@Sexo", sexo);
            comando.Parameters.AddWithValue("@data_nasc", dateTimePicker1.Value);
            comando.CommandType = CommandType.StoredProcedure;
            Cn.Open();
            comando.Parameters.Add(new SqlParameter("@retorno", SqlDbType.NVarChar, 50)).Direction = ParameterDirection.Output;
            comando.ExecuteNonQuery();
            String Ms = (String)comando.Parameters["@retorno"].Value;
            Cn.Close();
            MessageBox.Show(Ms);
            
            
        }

        private void CCliente_Load(object sender, EventArgs e)
        {
            this.dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
            this.dateTimePicker1.MinDate = DateTimePicker.MinimumDateTime;
        }
        string sexo;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            sexo = "M";

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sexo = "F";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_conta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }

 

        private void txt_contacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void txt_saldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            txt_nome.Text = "";
            txt_bi.Text= "";
            txt_conta.Text = "";
            txt_contacto.Text = "";
            sexo = "";

        }
    }
}
