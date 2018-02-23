using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._2_OCP.OCP.Solucao
{
    class DebitoContaInvestimento : DebitoConta
    {
        public override string Debitar(decimal valor, string conta)
        {
            //Debita Conta Investimento
            // Isentar Taxas

            return NumeroTransacao;
        }
    }
}
