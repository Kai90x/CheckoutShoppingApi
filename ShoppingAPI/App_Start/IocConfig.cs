using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ShoppingAPI.Managers;
using ShoppingAPI.Managers.Interfaces;

namespace ShoppingAPI.App_Start
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            builder.RegisterType<ShoppingManager>().As<IShoppingManager>().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}