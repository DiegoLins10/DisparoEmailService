using EmailDominios.Services;
using Ninject;
using System;
using System.Reflection;
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
            EventLog.WriteEntry("iniciando serviço 55", System.Diagnostics.EventLogEntryType.Warning);

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
            try
            {
                while (true)
                {
                    Thread.Sleep(5000);

                    using (var kernel = new StandardKernel())
                    {
                        kernel.Load(Assembly.GetExecutingAssembly());
                        var processo = kernel.Get<EmailProcesso>();

                        processo.Processar().Wait();

                    }
                }
            }
            catch(Exception e)
            {
                EventLog.WriteEntry(e.Message, System.Diagnostics.EventLogEntryType.Error);

            }

        }
    }
}
