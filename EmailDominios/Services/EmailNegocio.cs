using EmailDominios.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using EmailDominios.Models;

namespace EmailDominios.Services
{
    public class EmailNegocio
    {
        private EmailContext _context;

        public EmailNegocio(EmailContext context)
        {
            _context = context;
        }

        public void VerificandoEmailsPendentes()
        {
            var emails = this._context.EnviarEmail
                .Where(d => d.Status.Equals("N", StringComparison.CurrentCultureIgnoreCase))
                .Take(100);

            var teste = emails;


            foreach(var e in emails)
            {
                this.ProcessarEnvioEmail(e);

            }

        }

        private void ProcessarEnvioEmail(EnviarEmail email)
        {
            MailAddress origem = new MailAddress(email.EmailOrigem, email.NomeOrigem);
            MailAddress destino = new MailAddress(email.EmailDestino, email.NomeDestino);

            MailMessage mensagem = new MailMessage(origem, destino);
            mensagem.Subject = email.Assunto;
            mensagem.Body = email.Mensagem;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new NetworkCredential(origem.Address, "123!456");
            smtp.Send(mensagem);
        }
    }
}
