using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._1_SRP.SRP.Solucao
{
    class ClienteRepository
    {

        // Este método ainda não está perfeito pois ele 
        // não deveria conhecer o banco de dados.
        public void AdicionaCliente(Cliente cliente)
        {
            using (var connection = new SqlConnection())
            {
                using (var command = new SqlCommand())
                {
                    connection.ConnectionString = @"MinhaConnectionString";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO CLIENTE (NOME, EMAIL, CPF, DATACADASTRO VALUES(@nome, @email, @cpf, @dataCadastro)";

                    command.Parameters.AddWithValue("nome", cliente.Nome);
                    command.Parameters.AddWithValue("email", cliente.Email);
                    command.Parameters.AddWithValue("cpf", cliente.Cpf);
                    command.Parameters.AddWithValue("dataCadastro", cliente.DataCadastro);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
