using EmailDisparoAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailDisparoAPI.Data
{
    public class SeedingService
    {
        private EmailContext _context;

        public SeedingService(EmailContext context)
        {
            _context = context;
        }

        public void Seed()
        {

            if (!_context.EnviarEmail.Any())
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
                _context.EnviarEmail.AddRange(email, email2);
                _context.SaveChanges();
            }
        }
    }
}
