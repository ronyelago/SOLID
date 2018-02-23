using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._2_OCP.OCP.Violacao
{
    class DebitoConta
    {
        public void Deletar(decimal valor, string conta, TipoConta tipoConta)
        {
            if (tipoConta == TipoConta.Corrente)
            {
                // Debita Conta Corrente
            }

            if (tipoConta == TipoConta.Poupanca)
            {
                // Valida aniversário da conta
                // Debita conta poupança
            }
        }
    }
}
