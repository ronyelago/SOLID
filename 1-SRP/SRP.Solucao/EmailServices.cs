using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._1_SRP.SRP.Solucao
{
    class EmailServices
    {
        internal static bool IsValid(string email)
        {
            if (!email.Contains("@"))
            {
                return false;
            }

            return true;
        }

        internal static void Enviar(string de, string para, string assunto, string mensagem)
        {
            MailMessage mail = new MailMessage(de, para);
            SmtpClient client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };

            mail.Subject = assunto;
            mail.Body = mensagem;
            client.Send(mail);
        }
    }
}
