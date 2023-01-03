﻿using EmailDominios.Data;
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
    public class EmailNegocio : IEmailNegocio
    {
        private readonly EmailContext _context;

        public EmailNegocio(EmailContext context) 
        {
            _context = context;
        }

        public EmailNegocio()
        {
        }

        public void VerificandoEmailsPendentes()
        {
            var emails = this._context.EnviarEmail
                .Where(d => d.Status.Equals("N", StringComparison.CurrentCultureIgnoreCase));

            var teste = emails;

            if(emails.Count() > 0){
                foreach (var e in emails)
                {
                    ProcessarEnvioEmail(e);
                }

            }

            
        }

        public void ProcessarEnvioEmail(EnviarEmail email)
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

            AtualizarEmail(email);
        }

        public void AtualizarEmail(EnviarEmail email)
        {
            email.Status = "S";
            this._context.SaveChanges();
        }

      
    }
}