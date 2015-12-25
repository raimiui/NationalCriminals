using Microsoft.Practices.Unity;
using Repositories;
using Repositories.Interfaces;
using Services;
using Services.Interfaces;
using Unity.Wcf;
using WCF.App_Start;
using WCF.Contracts;

namespace WCF {
    public class WcfServiceFactory : UnityServiceHostFactory 
    {
        protected override void ConfigureContainer(IUnityContainer container) {
            //container.LoadConfiguration();
            RegisterTypes(container);
            Bootstrapper.Initialize();
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            // Repositories
            container.RegisterType<IPersonRepository, PersonRepository>();

            // Services
            container.RegisterType<IPersonWebService, PersonWebService>();
            container.RegisterType<IPersonService, PersonService>();
            container.RegisterType<IDocumentService, DocumentService>();
            container.RegisterType<IMailService, MailService>();
        }
    }
}
