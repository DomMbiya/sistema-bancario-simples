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
    public partial class CFuncionario : Form
    {
        string cx = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=sis_banco;Data Source=DOM-MBIYA";
        public CFuncionario()
        {
            InitializeComponent();
        }

        private void xuiButton4_Click(object sender, EventArgs e)
        {
            add_Funcionario();
        }
        private void add_Funcionario()
        {
            string proc = "add_funcionario";
            SqlConnection Cn = new SqlConnection();
            Cn.ConnectionString = cx;
            SqlCommand comando = new SqlCommand(proc, Cn);
            comando.Parameters.AddWithValue("@Nome", txt_nome.Text);
            comando.Parameters.AddWithValue("@IB", txt_bi.Text);
            comando.Parameters.AddWithValue("@Senha", txt_senha.Text);
            comando.Parameters.AddWithValue("@Nivel",txt_nivel.Text);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            Cn.Open();
            comando.ExecuteNonQuery();
            Cn.Close();
            MessageBox.Show("Funcionário cadastrado com sucesso!", "Aviso!");

        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            txt_nome.Text = "";
            txt_bi.Text = "";
            txt_senha.Text = "";
            txt_nivel.Text = "";
        }
    }
}
