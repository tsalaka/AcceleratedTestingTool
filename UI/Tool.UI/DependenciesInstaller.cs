using System.Configuration;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Kronos.AcceleratedTool.Commands;
using Kronos.AcceleratedTool.DataAccess.Common;
using Kronos.AcceleratedTool.DataAccess.Common.Dapper;
using Kronos.AcceleratedTool.DataAccess.Common.DataContext;
using Kronos.AcceleratedTool.DataBaseAccess;
using Kronos.AcceleratedTool.ExcelDocument.OpenXml;
using Kronos.AcceleratedTool.Jobs;
using Kronos.AcceleratedTool.Jobs.JobStatusTracking;
using Kronos.AcceleratedTool.Jobs.Logs;
using Kronos.AcceleratedTool.License;
using Kronos.AcceleratedTool.UI.Cryphography;
using Kronos.AcceleratedTool.UI.Validation;
using Kronos.AcceleratedTool.XmlApi;
using Kronos.AcceleratedTool.XmlApi.XmlApiService;
using static Castle.MicroKernel.Registration.AllTypes;

namespace Kronos.AcceleratedTool.UI
{
    public class DependenciesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(FromAssemblyContaining<IJob>()
                .Where(type => type.IsPublic && type != typeof(OutputDirectory) && type != typeof(JobStatusNotifier) && type != typeof(ILogger) && type != typeof(Logger))
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Component.For<JobStatusNotifier>().LifestyleSingleton());
            container.Register(Component.For<ILogger>().ImplementedBy<Logger>().DependsOn(Dependency.OnValue("name", "AcceleratedTool")).LifestyleSingleton());

            container.Register(FromAssemblyContaining<ICommand>()
                .Where(type => type.IsPublic)
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Component
             .For<ICommandFactory>()
             .AsFactory());
            container.Register(Component
             .For<IQueryFactory>()
             .AsFactory());

            container.Register(FromAssemblyContaining<ExcelWriter>()
                .Where(type => type.IsPublic)
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(FromAssemblyContaining<IXmlApiProxy>()
              .Where(type => type.IsPublic && type != typeof(XmlApiSettings) && type != typeof(IWebRequest) && type != typeof(WebRequestAdapter))
              .WithServiceAllInterfaces()
              .LifestyleTransient());

            int timeout;
            int.TryParse(ConfigurationManager.AppSettings["ApiTimeout"], out timeout);
            container.Register(Component.For<IWebRequest>().ImplementedBy<WebRequestAdapter>().DependsOn(Dependency.OnValue("timeout", timeout)).LifestyleTransient());

            container.Register(FromAssemblyContaining<IQuery>()
              .Where(type => type.IsPublic && type != typeof(DatabaseSettings) && type != typeof(IDataContext) && type != typeof(DapperDataContext) && type != typeof(SqlProvider) && type != typeof(OracleProvider) && type != typeof(IDbProvider))
              .WithServiceAllInterfaces()
              .LifestyleTransient());

            container.Register(FromAssemblyContaining<IQueryExecutor>()
              .Where(type => type.IsPublic)
              .WithServiceAllInterfaces()
              .LifestyleTransient());

            // set up directory path
            var outputDirectorySettings = new OutputDirectory
            {
                Path = ConfigurationManager.AppSettings["OutputDirectory"],
                ExcelFolder = ConfigurationManager.AppSettings["ExcelFolder"],
                SourceFolder = ConfigurationManager.AppSettings["SourceDirectory"]
            };
            container.Register(Component.For<OutputDirectory>().Instance(outputDirectorySettings).LifestyleSingleton());

            container.Register(FromAssemblyContaining<IUiValidator>()
              .Where(type => type.IsPublic)
              .WithServiceAllInterfaces()
              .LifestyleTransient());

            container.Register(FromAssemblyContaining<ILicenseChecker>()
              .Where(type => type.IsPublic)
              .WithServiceAllInterfaces()
              .LifestyleTransient());

            container.Register(FromAssemblyContaining<CryphographyService>()
              .Where(type => type.IsPublic)
              .WithServiceAllInterfaces()
              .LifestyleSingleton());
        }
    }
}
