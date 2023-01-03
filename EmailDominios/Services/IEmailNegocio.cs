using EmailDominios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailDominios.Services
{
    public interface IEmailNegocio
    {
        void VerificandoEmailsPendentes();
        void ProcessarEnvioEmail(EnviarEmail email);
        void AtualizarEmail(EnviarEmail email);

    }
}
