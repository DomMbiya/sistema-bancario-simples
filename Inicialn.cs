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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace Sistma_Bancario
{
    public partial class Inicialn : Form
    {
        string cx = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=sis_banco;Data Source=DOM-MBIYA";
        String varNumConta;
        public Inicialn()
        {
            InitializeComponent();
            gunaAnimateWindow1.Start();
            txt_conta.KeyPress += new KeyPressEventHandler(txt_conta_KeyPress);
            //txt_valor.KeyPress += new KeyPressEventHandler(txt_valor_KeyPress);
            txtconta.KeyPress += new KeyPressEventHandler(txtconta_KeyPress);
            txtdest.KeyPress += new KeyPressEventHandler(txtdest_KeyPress);
            //txtvalor.KeyPress += new KeyPressEventHandler(txtvalor_KeyPress);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Inicialn_Load(object sender, EventArgs e)
        {
            
        }

        private void xuiCustomToolstrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void xuiButton9_Click(object sender, EventArgs e)
        {
            ViClientes vc = new ViClientes();
            vc.ShowDialog();
        }

        private void xuiButton6_Click(object sender, EventArgs e)
        {
            Vimovimentos vf = new Vimovimentos();
            vf.ShowDialog();
        }

        private void xuiButton10_Click(object sender, EventArgs e)
        {
            Usuario vu = new Usuario();
            vu.ShowDialog();
        }

        private void xuiButton11_Click(object sender, EventArgs e)
        {
            Vimovimentos vc = new Vimovimentos();
            vc.ShowDialog();
        }

        private void xuiButton7_Click(object sender, EventArgs e)
        {
            CCliente cc = new CCliente();
            cc.ShowDialog();
        }

        private void xuiButton5_Click(object sender, EventArgs e)
        {
            CFuncionario cf = new CFuncionario();
            cf.ShowDialog();
        }

        private void xuiButton3_Click(object sender, EventArgs e)
        {
            obter_cliente();
        }
        //private void Add_Saldo() {

        
        ////    string proc = "atu_Depos_Saldo";
        ////    SqlConnection cn = new SqlConnection();
        ////    cn.ConnectionString = cx;
        ////    SqlCommand comando = new SqlCommand(proc, cn);
        ////    comando.Parameters.AddWithValue("@Saldo", txt_valor.Text);
        ////    comando.Parameters.AddWithValue("@Conta", txt_conta.Text);
        ////    comando.CommandType = System.Data.CommandType.StoredProcedure;
        ////    cn.Open();
        ////    comando.Parameters.Add(new SqlParameter("@retorno", SqlDbType.NVarChar, 100)).Direction = ParameterDirection.Output;
        ////    comando.ExecuteNonQuery();
        ////    String Ms = (string)comando.Parameters["@retorno"].Value;
        ////    cn.Close();
        ////    MessageBox.Show(Ms);   

 
        //}
       private void Levantar_Saldo()

        {
            string proc = "atu_levan_Saldo";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cx;
            SqlCommand comando = new SqlCommand(proc, cn);
            comando.Parameters.AddWithValue("@Saldo", txt_valor.Text);
            comando.Parameters.AddWithValue("@Conta", decimal.Parse(txt_conta.Text));
            comando.CommandType = CommandType.StoredProcedure;
            cn.Open();
            comando.Parameters.Add(new SqlParameter("@retorno", SqlDbType.NVarChar, 100)).Direction = ParameterDirection.Output;
            comando.ExecuteNonQuery();
            String Ms = (string)comando.Parameters["@retorno"].Value;
            cn.Close();
            MessageBox.Show(Ms);
            
    

        }
        private void xuiButton2_Click(object sender, EventArgs e)
        {
            if (cbx_tipo_movimento.Text == "Depósito")
            {
               
                Cls_Model_Deposito f = new Cls_Model_Deposito();
                Cls_Bll_Deposito g = new Cls_Bll_Deposito();
                f.Nu_Conta = Convert.ToInt32(txt_conta.Text);
                f.Valor = Decimal.Parse(txt_valor.Text);

                g.Salvar_Bll(f);
              

                comprovativo();
                return;
            }
            if (cbx_tipo_movimento.Text == "Levantamento")
            {
                Levantar_Saldo();
                comprovativo();
                return;
            }
            else { MessageBox.Show("Por favor, confirme os dados e verifique se selecionou uma operação!", "Aviso!"); ; }
        }
    

    private void obter_cliente()
    {
            if (txt_conta.Text == "") 
             { MessageBox.Show("Insira o numero de conta!", "Aviso!");
                return;
            }
            int nConta = Convert.ToInt32(txt_conta.Text);
            string proc = "dados_cliente";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cx;
         SqlCommand comando = new SqlCommand(proc, cn);
            comando.Parameters.AddWithValue("@Conta", nConta);
            comando.CommandType = CommandType.StoredProcedure;
            cn.Open();
         comando.Parameters.Add(new SqlParameter("@retorno", SqlDbType.NVarChar, 100)).Direction = ParameterDirection.Output;
         comando.ExecuteNonQuery();
         String Ms = (String)comando.Parameters["@retorno"].Value;
         MessageBox.Show(Ms);
         SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                txt_nome.Text = reader["Nome"].ToString();
                txt_debito.Text = reader["Saldo"].ToString();
                xuiButton2.Enabled = true;
                return;
            }
        cn.Close();
   }
    private void obter_cliente2()
    {
        if (txtconta.Text == "")
        {
            MessageBox.Show("Insira o numero de conta!", "Aviso!");
            return;
        }
        int nConta = Convert.ToInt32(txtconta.Text);
        string proc = "dados_cliente";
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = cx;
        SqlCommand comando = new SqlCommand(proc, cn);
        comando.Parameters.AddWithValue("@Conta", nConta);
        comando.CommandType = CommandType.StoredProcedure;
        cn.Open();
        comando.Parameters.Add(new SqlParameter("@retorno", SqlDbType.NVarChar, 100)).Direction = ParameterDirection.Output;
        comando.ExecuteNonQuery();
        String Ms = (String)comando.Parameters["@retorno"].Value;
        MessageBox.Show(Ms);
        SqlDataReader reader = comando.ExecuteReader();


        while (reader.Read())
        {
            txttitular.Text = reader["Nome"].ToString();
            xuiButton4.Enabled = true;
            return;
        } 
        cn.Close();
    }
    private void obter_cliente3()
    {
       
        if (txtdest.Text == "")
        {
            MessageBox.Show("Insira o numero de conta!", "Aviso!");
            return;
        }

        int dest = Convert.ToInt32(txtdest.Text);
        string proc = "dados_cliente";
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = cx;
        SqlCommand comando = new SqlCommand(proc, cn);
        comando.Parameters.AddWithValue("@Conta", dest);
        comando.CommandType = CommandType.StoredProcedure;
        cn.Open();
        comando.Parameters.Add(new SqlParameter("@retorno", SqlDbType.NVarChar, 100)).Direction = ParameterDirection.Output;
        comando.ExecuteNonQuery();
        String Ms = (String)comando.Parameters["@retorno"].Value;
        MessageBox.Show(Ms);
        SqlDataReader reader = comando.ExecuteReader();

        while (reader.Read())
        {
            txttitulardest.Text = reader["Nome"].ToString();
            xuiButton4.Enabled = true;
            return;
        }
        cn.Close();
    }


    private void materialTabSelector1_Click(object sender, EventArgs e)
    {

    }

    private void txt_nome_Click(object sender, EventArgs e)
    {

    }

    private void xuiButton1_Click(object sender, EventArgs e)
    {
        obter_cliente2();
        obter_cliente3();
    }

    private void tabPage1_Click(object sender, EventArgs e)
    {

    }

    private void xuiButton4_Click(object sender, EventArgs e)
    {
        string proc = "transferencia";
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = cx;
        SqlCommand comando = new SqlCommand(proc, cn);
        comando.Parameters.AddWithValue("@conta", txtconta.Text);
        comando.Parameters.AddWithValue("@valor", txtvalor.Text);
        comando.Parameters.AddWithValue("@dest", txtdest.Text);
        comando.CommandType = System.Data.CommandType.StoredProcedure;
        cn.Open();
        comando.Parameters.Add(new SqlParameter("@retorno", SqlDbType.NVarChar, 100)).Direction = ParameterDirection.Output;
        comando.ExecuteNonQuery();
        String Ms = (string)comando.Parameters["@retorno"].Value;
        cn.Close();
        MessageBox.Show(Ms);
        comprovativo_transferência();
    }

 
    private void txt_conta_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) 
        {
            e.Handled = true;

        }

    }

    private void txt_valor_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;

        }

    }

    private void txtconta_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;

        }
    }

    private void txtdest_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;

        }
    }

    private void txtvalor_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;

        }
    }

    private void comprovativo() {
      

    var doc =  new Document(PageSize.A7);
        
      
    PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\PC\Desktop\Projeto\ meu_comprovativo.pdf", FileMode.Create));

        doc.Open();
        doc.Add(new Paragraph("-------------------------"));
        doc.Add(new Paragraph("Comprovativo : " + cbx_tipo_movimento.Text ));
        doc.Add(new Paragraph("Cliente: " + txt_nome.Text + "\n"));
        doc.Add(new Paragraph("--------------------------"));
        doc.Add(new Paragraph("Nº Conta: " + txt_conta.Text + "\n"));
        doc.Add(new Paragraph("--------------------------"));
        doc.Add(new Paragraph("Valor: " + txt_valor.Text + "\n"));
        doc.Add(new Paragraph("Obrigado !!"));   
        doc.Close();
        
    }

        private void comprovativo_transferência() {
      

    var doc =  new Document(PageSize.A6);
      

    PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\PC\Desktop\Projeto\ meu_comprovativo.pdf", FileMode.Create));

        doc.Open();
        doc.Add(new Paragraph("-------------------------"));
        doc.Add(new Paragraph("Comprovativo : Transferência "  ));
        doc.Add(new Paragraph("Cliente: " + txtconta.Text + "\n"));
        doc.Add(new Paragraph("Nome : "+ txttitular.Text));
        doc.Add(new Paragraph("--------------------------"));
        doc.Add(new Paragraph("Destinatário: " + txtdest.Text + "\n"));
        doc.Add(new Paragraph("Nome: " + txttitulardest.Text));
        doc.Add(new Paragraph("--------------------------"));
        doc.Add(new Paragraph("Valor: " + txtvalor.Text + "\n"));
        doc.Add(new Paragraph("Obrigado !!"));   
        doc.Close();
        
    }

      

    private void cbx_tipo_movimento_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void txt_valor_Click(object sender, EventArgs e)
    {

    }

    private void txt_conta_Click(object sender, EventArgs e)
    {

    }

}
}
