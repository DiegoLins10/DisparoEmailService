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
            //esse metodo aponta para o metodo verificaremail
            ThreadStart start = new ThreadStart(VerificarEmailPendente);

            // cria a thread com uma instancia da threadstart
            Thread thread = new Thread(start);

            //manda a thread executar
            thread.Start();
        }

        protected override void OnStop()
        {
        }

        public void VerificarEmailPendente()
        {
            while (true)
            {
                Thread.Sleep(5000);


            }
        }
    }
}
