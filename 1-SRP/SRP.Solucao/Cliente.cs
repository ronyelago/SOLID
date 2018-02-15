using System;

namespace SOLID._1_SRP.SRP.Solucao
{
    class Cliente
    {
        /*** SRP - Single Responsability Principle
         *** Princípio de Responsabilidade Única
         *** Uma classe deve ter um, e apenas um 
         *** motivo para ser modificada.
         ***/

        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataCadastro { get; set; }

        public bool IsValid()
        {
            return EmailServices.IsValid(Email) && CpfServices.IsValid(Cpf);
        }
    }
}
