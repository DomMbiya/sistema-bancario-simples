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
    public partial class Vimovimentos : Form
    {
        string cx = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=sis_banco;Data Source=DOM-MBIYA";
      
        public Vimovimentos()
        {
            InitializeComponent();
            gunaAnimateWindow1.Start();
            ver_movimento();
        }

        private void ViFincionario_Load(object sender, EventArgs e)
        {
          

          
        }
        private void ver_movimento()
        {
           
            string proc = "ver_movimento";
            SqlConnection Cn = new SqlConnection();
            Cn.ConnectionString = cx;
            SqlCommand comando = new SqlCommand(proc, Cn);
            comando.CommandType = CommandType.StoredProcedure;
            Cn.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tabela = new DataTable();
            adaptador.Fill(tabela);
            visor.DataSource = tabela;
            Cn.Close();
            
                }

        private void xuiButton2_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField6_Click(object sender, EventArgs e)
        {

        }

        private void visor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}