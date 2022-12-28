using EmailDominios.Data;
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

        }
    }
}
