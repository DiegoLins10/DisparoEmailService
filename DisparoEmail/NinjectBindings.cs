using EmailDominios.Data;
using EmailDominios.Services;
using System.Configuration;

namespace DisparoEmail
{
    public class NinjectBindings : Ninject.Modules.NinjectModule
    {
        private string _connectionString;

        public void LoadConfig()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EmailConnection"].ConnectionString;
        }

        public override void Load()
        {
            this.LoadConfig();

            Bind<EmailContext>().ToSelf().WithConstructorArgument("connectionString", _connectionString);

            Bind<IEmailProcesso>().To<EmailProcesso>();
            Bind<IEmailRepository>().To<EmailRepository>();

            //Bind<IEmailNegocio>().To<EmailNegocio>();
        }
    }
}
