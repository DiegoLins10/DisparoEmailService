using EmailDominios.Data;
using EmailDominios.Models;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            var emails = this.Db.EnviarEmail
                .Where(d => d.Status.Equals("N"));


            if (emails.Count() > 0)
            {
                foreach (var e in emails)
                {
                    await ProcessarEnvioEmail(e);
                }
                this.Db.SaveChanges();
            }
            else
            {
                Seed();
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

            smtp.Credentials = new NetworkCredential(origem.Address, "weedwtbddkojwycz");
            smtp.Send(mensagem);

            AtualizarEmail(email);
        }

        public void AtualizarEmail(EnviarEmail email)
        {
            email.Status = "S";
        }


        public void Seed()
        {
            EnviarEmail email = new EnviarEmail()
            {
                EmailOrigem = "diegofernandeslins@gmail.com",
                EmailDestino = "diegofernandeslins@gmail.com",
                NomeOrigem = "CasaDiego",
                NomeDestino = "NamoCasa",
                Assunto = "Vamos casar",
                Mensagem = "Você irá casar comigo nos proximos anos",
                Status = "N"
            };

            EnviarEmail email2 = new EnviarEmail()
            {
                EmailOrigem = "diegofernandeslins@gmail.com",
                EmailDestino = "Dede.cecy2002@gmail.com",
                NomeOrigem = "CasaDiego",
                NomeDestino = "NamoCasa",
                Assunto = "Vamos casar",
                Mensagem = "Você irá casar comigo nos proximos anos",
                Status = "N"
            };

            this.Db.EnviarEmail.AddRange(email, email2);
            this.Db.SaveChanges();

        }
    }
}
