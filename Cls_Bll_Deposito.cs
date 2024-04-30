using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistma_Bancario
{
    class Cls_Bll_Deposito
    {
        public int Salvar_Bll(Cls_Model_Deposito s)
        {
            Cls_Dal_Deposito Dal = new Cls_Dal_Deposito();
            return Dal.Salvar_Dal(s);
        }

    }
}
