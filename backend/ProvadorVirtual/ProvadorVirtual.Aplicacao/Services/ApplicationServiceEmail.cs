using Microsoft.Extensions.Configuration;
using ProvadorVirtual.Aplicacao.Interfaces.Administracao;
using System.Net;
using System.Net.Mail;

namespace ProvadorVirtual.Aplicacao.Services
{
    public class ApplicationServiceEmail : IApplicationServiceEmail
    {
        public void EnviarEmail(string destinatario, string assunto, string mensagem)
        {

            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                          .AddJsonFile("appsettings.json")
                                                          .Build();

            var email = configuration.GetSection("email").Value;
            var senha = configuration.GetSection("senhaEmail").Value;

            MailAddress to = new MailAddress(destinatario);
            MailAddress from = new MailAddress(email);
            MailMessage emailAdress = new MailMessage(from, to);

            emailAdress.Subject = assunto;
            emailAdress.Body = mensagem;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(email, senha);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;

            try
            {
                smtpClient.Send(emailAdress);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
