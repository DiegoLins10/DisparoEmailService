using System.ServiceProcess;
using System.Threading;

namespace DisparoEmail
{
    public partial class DisparandoEmail : ServiceBase
    {
        public DisparandoEmail()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }

        public void VerificarEmailPendente()
        {

        }
    }
}
