using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace Sistma_Bancario
{
    public partial class ViClientes : Form
    {
        string cx = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=sis_banco;Data Source=DOM-MBIYA";
   
        
        public ViClientes()
        {
            InitializeComponent();
            gunaAnimateWindow1.Start();
            ver_cliente();
        }

        private void Visualizar_Load(object sender, EventArgs e)
        {
            
         
        }
        private void ver_cliente()
        {

            string proc = "ver_cliente";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cx;
            SqlCommand comando = new SqlCommand(proc, cn);
            comando.CommandType = CommandType.StoredProcedure;
            cn.Open();
       
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tabela = new DataTable();
            adaptador.Fill(tabela);
            gunaDataGridView1.DataSource = tabela;
            cn.Close();
                }


        private void xuiButton2_Click(object sender, EventArgs e)
        {
             string proc = "pesquisar_usuário";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cx;
            SqlCommand comando = new SqlCommand(proc, cn);
            comando.Parameters.AddWithValue("@conta", txtconta.Text);
            comando.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tabela = new DataTable();
            comando.Parameters.Add(new SqlParameter("@retorno", SqlDbType.NVarChar, 100)).Direction = ParameterDirection.Output;
            comando.ExecuteNonQuery();
            String Ms = (string)comando.Parameters["@retorno"].Value;
            cn.Close();
            MessageBox.Show(Ms);
            adaptador.Fill(tabela);
            gunaDataGridView1.DataSource = tabela;
            cn.Close();

         }
        }
}
