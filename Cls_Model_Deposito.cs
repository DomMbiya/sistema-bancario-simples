using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistma_Bancario
{
    class Cls_Model_Deposito
    {
        private int nu_conta;
        private decimal valor;

        public int Nu_Conta
        {
            set { nu_conta = value; } //escreva
            get { return nu_conta; } //leia
        }

        public decimal Valor
        {
            set { valor = value; }
            get { return valor; }
        }


    }
}
