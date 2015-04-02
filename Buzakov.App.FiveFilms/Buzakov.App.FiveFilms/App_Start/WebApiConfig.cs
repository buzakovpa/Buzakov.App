using Microsoft.Owin.Security.OAuth;
using Ninject;
using Ninject.Activation;
using Ninject.Syntax;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Ninject.Parameters;
using Buzakov.App.Mappers;

namespace Buzakov.App.FiveFilms
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var kernel = (IKernel)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IKernel));

            config.DependencyResolver = new NinjectResolver(kernel);
            
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication( );
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes( );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = System.Web.Http.RouteParameter.Optional }
            );
        }
    }

    public class NinjectResolver : NinjectScope, IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectResolver(IKernel kernel)
            : base(kernel)
        {
            _kernel = kernel;
        }
        public IDependencyScope BeginScope( )
        {
            return new NinjectScope(_kernel.BeginBlock( ));
        }
    }

    public class NinjectScope : IDependencyScope
    {
        protected IResolutionRoot resolutionRoot;
        public NinjectScope(IResolutionRoot kernel)
        {
            resolutionRoot = kernel;
        }
        public object GetService(Type serviceType)
        {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolutionRoot.Resolve(request).SingleOrDefault( );
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolutionRoot.Resolve(request).ToList( );
        }
        public void Dispose( )
        {
            IDisposable disposable = (IDisposable)resolutionRoot;
            if (disposable != null)
                disposable.Dispose( );
            resolutionRoot = null;
        }
    }
}