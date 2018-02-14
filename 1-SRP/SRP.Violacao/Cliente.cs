using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public string Cpf { get; set; }
        public DateTime DataCadastro { get; set; }

        public string AdicionarCliente()
        {
            if (!Email.Contains("@"))
            {
                return "Email inválido";
            }

            if (Cpf.Length != 11)
            {
                return "CPF inválido!";
            }

            using (var connection = new SqlConnection())
            {
                using (var command = new SqlCommand())
                {
                    connection.ConnectionString = @"MinhaConnectionString";
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO CLIENTE (NOME, EMAIL, CPF, DATACADASTRO VALUES(@nome, @email, @cpf, @dataCadastro)";

                    command.Parameters.AddWithValue("nome", Nome);
                    command.Parameters.AddWithValue("email", Email);
                    command.Parameters.AddWithValue("cpf", Cpf);
                    command.Parameters.AddWithValue("dataCadastro", DataCadastro);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
