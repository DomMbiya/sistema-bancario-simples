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
    public partial class Form1 : Form
    {
        bool tem = false;
        string cx = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=sis_banco;Data Source=DOM-MBIYA";
        public Form1()
        {
            InitializeComponent();
            gunaAnimateWindow1.Start();
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {

            obter_cliente();

        }
        private void obter_cliente()
        {

       
            if (txt_user.Text == "" || txt_senha.Text =="")
            {
                MessageBox.Show("Insira os dados de login!", "Aviso!");
                return;
            }
            string proc = "login";
            SqlConnection Cn = new SqlConnection();
            Cn.ConnectionString = cx;
            SqlCommand comando = new SqlCommand(proc, Cn);
            comando.Parameters.AddWithValue("@Nome", txt_user.Text);
            comando.Parameters.AddWithValue("@Senha", txt_senha.Text);
            comando.CommandType = CommandType.StoredProcedure;
            Cn.Open();
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                tem = true;

            }
            if (tem == true)
            {
                MessageBox.Show(" Login feito com sucesso");
            }
            else
            {
                MessageBox.Show("Erro");
            }

           
            while (reader.Read())
            {
                String nivelAcess = reader["Nivel_de_acesso"].ToString();
                if (nivelAcess == "Adm")
                {
                    Inicialn incial = new Inicialn();
                    incial.Show();
                   
                    txt_user.Text = "" ;
                    txt_senha.Text = "" ;
                   
                }
                return;

            }

            Cn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {
                 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Aviso")== System.Windows.Forms.DialogResult.OK)
             {
this.Close();
        }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void xuiCheckBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
