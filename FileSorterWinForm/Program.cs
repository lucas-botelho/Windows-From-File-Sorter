using FileSorterWinForm.Patterns.Factory.Implementations;
using FileSorterWinForm.Patterns.Factory.Interfaces;
using FileSorterWinForm.Repositories.Implementations;
using FileSorterWinForm.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSorterWinForm
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IFileRepository, FileRepository>();
            services.AddTransient<IFormRepository, FormRepository>();
            services.AddTransient<ICustomFileFactory, CustomFileFactory>();
            ServiceProvider = services.BuildServiceProvider();
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            Application.Run(new Form1());
        }
    }
}
