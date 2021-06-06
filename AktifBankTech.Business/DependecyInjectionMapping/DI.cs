using AktifBankTech.Business.Engines.DepositsEngines;
using AktifBankTech.Business.Engines.InvoicesEngines;
using AktifBankTech.Business.Engines.RolesEngines;
using AktifBankTech.Business.Engines.SubscriptionsEngines;
using AktifBankTech.Business.Engines.SubscriptionTypesEngines;
using AktifBankTech.Business.Engines.UsersEngines;
using AktifBankTech.Business.IEngines.IDepositsEngines;
using AktifBankTech.Business.IEngines.IInvoicesEngines;
using AktifBankTech.Business.IEngines.IRolesEngines;
using AktifBankTech.Business.IEngines.ISubscriptionsEngines;
using AktifBankTech.Business.IEngines.ISubscriptionTypesEngines;
using AktifBankTech.Business.IEngines.IUsersEngines;
using AktifBankTech.Data.Context;
using AktifBankTech.Data.Interfaces.DepositsInterfaces;
using AktifBankTech.Data.Interfaces.InvoicesInterfaces;
using AktifBankTech.Data.Interfaces.RolesInterfaces;
using AktifBankTech.Data.Interfaces.SubscriptionsInterfaces;
using AktifBankTech.Data.Interfaces.SubscriptionTypesInterfaces;
using AktifBankTech.Data.Interfaces.UsersInterfaces;
using AktifBankTech.Data.Repositories.DepositsRepositories;
using AktifBankTech.Data.Repositories.InvoicesRepositories;
using AktifBankTech.Data.Repositories.RolesRepositories;
using AktifBankTech.Data.Repositories.SubscriptionsRepositories;
using AktifBankTech.Data.Repositories.SubscriptionTypesRepositories;
using AktifBankTech.Data.Repositories.UsersRepositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AktifBankTech.Business.DependecyInjectionMapping
{
    public class DI
    {
        public static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IUsersRepository>().To<UsersRepository>();
            kernel.Bind<IUsersEngine>().To<UsersEngine>();

            kernel.Bind<ISubscriptionTypesRepository>().To<SubscriptionTypesRepository>();
            kernel.Bind<ISubscriptionTypesEngine>().To<SubscriptionTypesEngine>();

            kernel.Bind<ISubscriptionsRepository>().To<SubscriptionsRepository>();
            kernel.Bind<ISubscriptionsEngine>().To<SubscriptionsEngine>();

            kernel.Bind<IRolesRepository>().To<RolesRepository>();
            kernel.Bind<IRolesEngine>().To<RolesEngine>();

            kernel.Bind<IInvoicesRepository>().To<InvoicesRepository>();
            kernel.Bind<IInvoicesEngine>().To<InvoicesEngine>();

            kernel.Bind<IDepositsRepository>().To<DepositsRepository>();
            kernel.Bind<IDepositsEngine>().To<DepositsEngine>();

            kernel.Bind<DbContext>().To<AktifBankTechContext>();

            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }
}
