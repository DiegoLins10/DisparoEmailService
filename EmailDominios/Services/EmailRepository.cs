using EmailDominios.Data;
using EmailDominios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailDominios.Services
{
    public class EmailRepository : Repository<EnviarEmail>, IEmailRepository
    {

        public EmailRepository(EmailContext db) : base(db)
        {
        }

        public async Task VerificandoEmailsPendentes()
        {
            //var emails = this.Db.EnviarEmail
            //    .Where(d => d.Status.Equals("N", StringComparison.CurrentCultureIgnoreCase));
            
            var emails = this.Db.EnviarEmail
                .Where(d => d.Status.Equals("N"));

            var teste = emails;

            if (emails.Count() > 0)
            {
                foreach (var e in emails)
                {
                   await ProcessarEnvioEmail(e);
                }

            }
        }

        public async Task ProcessarEnvioEmail(EnviarEmail email)
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

            await AtualizarEmail(email);
        }

        public async Task AtualizarEmail(EnviarEmail email)
        {
            email.Status = "S";
            await this.Db.SaveChangesAsync();
        }
    }
}
