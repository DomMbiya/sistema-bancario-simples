using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Sistma_Bancario
{
    class Cls_Dal_Deposito
    {
        public string cx = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=sis_banco;Data Source=DOM-MBIYA";

        public int Salvar_Dal(Cls_Model_Deposito g)
        {
            string proc = "atu_Depos_Saldo";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cx;
            SqlCommand comando = new SqlCommand(proc, cn);
            comando.Parameters.AddWithValue("@Saldo", g.Valor);
            comando.Parameters.AddWithValue("@Conta", g.Nu_Conta);
            comando.CommandType = CommandType.StoredProcedure;
            cn.Open();
            comando.Parameters.Add(new SqlParameter("@retorno", SqlDbType.NVarChar, 100)).Direction = ParameterDirection.Output;
             comando.ExecuteNonQuery();
            String Ms = (string)comando.Parameters["@retorno"].Value;
            cn.Close();
            MessageBox.Show (Ms);
            return 0;
        
        }

    }
}
