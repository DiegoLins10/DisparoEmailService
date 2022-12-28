using System.ComponentModel.DataAnnotations;

namespace EmailDominios.Models
{
    public class EnviarEmail
    {
        [Key]
        public int IdEnviarEmail { get; set; }
        public string EmailOrigem { get; set; }
        public string EmailDestino { get; set; }
        public string NomeOrigem { get; set; }
        public string NomeDestino { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public string Status { get; set; }
    }
}
