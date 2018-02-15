using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._1_SRP.SRP.Solucao
{
    class ClienteServices
    {
        public string AdicionarCliente(Cliente cliente)
        {
            // Testa a validade do objeto
            if (!cliente.IsValid())
            {
                return "Dados inválidos.";
            }

            var repository = new ClienteRepository();
            repository.AdicionaCliente(cliente);

            EmailServices.Enviar("empresa@empresa.com", cliente.Email, "Bem-Vindo", "Parabéns, você foi cadastrado(a)!");

            return "Cliente cadastrado com sucesso.";
        }
    }
}
