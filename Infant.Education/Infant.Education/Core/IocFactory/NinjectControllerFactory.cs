using Infant.Education.Framework;
using Infant.Education.IProvider;
using Infant.Education.Provider;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Infant.Education.Core.IocFactory
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel Kernel;

        public NinjectControllerFactory()
        {
            Kernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)Kernel.Get(controllerType);
        }

        private void AddBindings()
        {
            Kernel.Bind<IUnitOfWork>().To<EfUnitOfWorkContext>();
            Kernel.Bind(typeof(IRepository<>)).To(typeof(EfRepositoryBaseOfDbContext<>));

            Kernel.Bind<ISysAdminProvider>().To<SysAdminProvider>();
            
        }
    }
}