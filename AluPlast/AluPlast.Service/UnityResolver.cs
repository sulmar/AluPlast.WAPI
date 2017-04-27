using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace AluPlast.Service
{
    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer container;

        public object GetService(Type serviceType)
        {
            try
            {

                var service = container.Resolve(serviceType);

                return service;
            }
            catch(ResolutionFailedException e)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                var services = container.ResolveAll(serviceType);

                return services;
            }
            catch (ResolutionFailedException e)
            {
                return new List<object>();
            }
        }


        public UnityResolver(IUnityContainer container)
        {
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();

            return new UnityResolver(child);
        }

        public void Dispose()
        {
            container.Dispose();
        }

      
    }
}
