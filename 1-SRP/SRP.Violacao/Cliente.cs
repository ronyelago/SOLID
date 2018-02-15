using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
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

        // Este método não deveria estar nesta classe, pois 
        // uma classe não deve se adicionar ao banco de dados.
        // Além disso, como seu nome diz, ele deveria apenas adicionar 
        // um cliente no banco de dados.
        // 4 responsabilidades em um único método
        public string AdicionarCliente()
        {

            // Validação de email não deveria estar aqui
            if (!Email.Contains("@"))
            {
                return "Email inválido";
            }

            // Validação de CFP não deveria estar aqui
            if (Cpf.Length != 11)
            {
                return "CPF inválido!";
            }

            // Este método não deveria se conectar ao banco de dados
            // e nem saber qual bando está sendo utilizado
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

            // Este método não deveria saber como enviar emails
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };

            mail.Subject = "Bem-Vindo(a)!";
            mail.Body = "Parabéns, você está cadastrado(a)!";
            client.Send(mail);

            return "Cliente cadastrado com sucesso!";
        }
    }
}