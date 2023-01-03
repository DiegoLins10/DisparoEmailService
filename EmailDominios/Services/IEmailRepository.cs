using EmailDominios.Data;
using EmailDominios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailDominios.Services
{
    public interface IEmailRepository : IRepository<EnviarEmail>
    {
        Task VerificandoEmailsPendentes();
        Task ProcessarEnvioEmail(EnviarEmail email);
        void AtualizarEmail(EnviarEmail email);
    }
}
