using EmailDominios.Data;
using EmailDominios.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailDisparoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailContext _context;

        public EmailController(EmailContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            EnviarEmail email = this._context.EnviarEmail.Where(d => d.Status.Equals("N")).FirstOrDefault();

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


            return Ok();
        }
    }
}
