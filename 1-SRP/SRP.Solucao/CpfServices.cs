using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._1_SRP.SRP.Solucao
{
    class CpfServices
    {
        internal static bool IsValid(string cpf)
        {
            if (cpf.Length != 11)
            {
                return false;
            }

            return true;
        }
    }
}
