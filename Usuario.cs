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
    public partial class Usuario : Form
    {
        string cx = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=sis_banco;Data Source=DOM-MBIYA";
        public Usuario()
        {
            InitializeComponent();
            gunaAnimateWindow1.Start();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            ver_Usuario();
        }
        private void ver_Usuario()
        {
            string proc = "ver_usuarioGeral";
            SqlConnection Cn = new SqlConnection();
            Cn.ConnectionString = cx;
            SqlCommand comando = new SqlCommand(proc, Cn);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            Cn.Open();
            comando.ExecuteNonQuery();
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable tabela = new DataTable();
            adaptador.Fill(tabela);
            visor.DataSource = tabela;
            Cn.Close();

        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {

        }

        private void visor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_inserir_Click(object sender, EventArgs e)
        {
            salvardados();
        }
        private void salvardados()
        {

            string proc = "inserir_dgv";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cx;
            cn.Open();

                for (int i = 0; i < visor.Rows.Count - 1; i++)
                {
                    SqlCommand cm = new SqlCommand(proc, cn);
                    cm.Parameters.AddWithValue("@ID_func", visor.Rows[i].Cells[0].Value);
                    cm.Parameters.AddWithValue("@Senha", visor.Rows[i].Cells[1].Value);
                    cm.Parameters.AddWithValue("@N_A", visor.Rows[i].Cells[2].Value);
                    cm.Parameters.AddWithValue("@BI", visor.Rows[i].Cells[3].Value);
                    cm.Parameters.AddWithValue("@BI1", visor.Rows[i].Cells[4].Value);
                    cm.Parameters.AddWithValue("@Nome", visor.Rows[i].Cells[5].Value);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.ExecuteNonQuery();

                }
             cn.Close();
             MessageBox.Show("Dados inseridos com sucesso");

            
        }
    }
}