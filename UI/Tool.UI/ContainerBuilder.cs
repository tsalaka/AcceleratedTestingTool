using Castle.Facilities.TypedFactory;
using Castle.Windsor;

namespace Kronos.AcceleratedTool.UI
{
    public class ContainerBuilder
    {
        public static IWindsorContainer Build()
        {
            var container = new WindsorContainer();

            container.AddFacility<TypedFactoryFacility>();
            container.Install(new DependenciesInstaller());
            return container;
        }
    }
}
