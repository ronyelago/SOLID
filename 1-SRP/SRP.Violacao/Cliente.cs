using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._1_SRP.SRP.Violacao
{
    class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Cpf { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
