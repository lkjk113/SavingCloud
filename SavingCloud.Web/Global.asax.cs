using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SavingCloud
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);



            //跨域设置
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //GlobalConfiguration.Configuration.EnableCors(cors);

            var builder = new ContainerBuilder();

            //注册数据仓储
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>));
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            //注册webapi
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //注册api事务
            GlobalConfiguration.Configuration.Filters.Add(new UnitOfWorkFilter());

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("SavingCloud"));

            var autoMapAssyemblies = new string[] { "DomainService", "Web", "Infrastructure", "Core" };//需要创建map的程序集
            foreach (var assembly in assemblies)
            {
                //注册常规实例IOC
                builder.RegisterAssemblyTypes(assembly)
                    .Where(t => typeof(ITransientDependency)
                    .IsAssignableFrom(t))
                    .AsImplementedInterfaces();
                
                //注册单例IOC
                builder.RegisterAssemblyTypes(assembly)
                    .Where(t => typeof(ISingletonDependency)
                    .IsAssignableFrom(t))
                    .AsImplementedInterfaces().SingleInstance();

                //设置程序集里的对象automapper
                if (autoMapAssyemblies.Any(name => assembly.FullName.Contains(name)))
                {
                    assembly.NeedAutoMap();
                }
            }

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            AutoMapExtensions.CreateMapping();
        }
    }
}
