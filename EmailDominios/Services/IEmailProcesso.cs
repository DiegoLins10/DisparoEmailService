using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailDominios.Services
{
    public interface IEmailProcesso : IProcessoBase
    {
        Task Processar();
    }
}
