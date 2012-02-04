﻿using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using MetalMastery.Core.Data;
using MetalMastery.Core.Infrastructure;
using MetalMastery.Data;
using MetalMastery.Services;

namespace MetalMastery.Web
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerHttpRequest();

            builder.Register(c => new HttpContextWrapper(HttpContext.Current) as HttpContextBase)
                .As<HttpContextBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerHttpRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerHttpRequest();

            //services
            builder.RegisterType<FormAuthenticationService>().As<IAuthenticationService>().InstancePerHttpRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerHttpRequest();
            builder.RegisterType<EmailSender>().As<IEmailSender>().InstancePerHttpRequest();
        }
    }
}
