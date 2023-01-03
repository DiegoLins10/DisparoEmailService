using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailDominios.Services
{
    public class EmailProcesso : IEmailProcesso
    {
        private readonly IEmailRepository emailRepository;

        public EmailProcesso(IEmailRepository emailRepository)
        {
            this.emailRepository = emailRepository;
        }


        public async Task Processar()
        {
            await emailRepository.VerificandoEmailsPendentes();
        }

        public void Dispose()
        {
            emailRepository?.Dispose();
        }
    }
}
