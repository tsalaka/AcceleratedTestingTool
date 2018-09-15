using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Castle.Windsor;

namespace Kronos.AcceleratedTool.UI
{
    public static class Program
    {
        private static IWindsorContainer _container;

        public static IWindsorContainer Container
        {
            get { return _container; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            _container = ContainerBuilder.Build();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AcceleratedTestingToolLogin());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }
    }
}
