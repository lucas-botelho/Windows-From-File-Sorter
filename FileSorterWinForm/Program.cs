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
            services.AddTransient<IFileDateRepository, FileDateRepository>();
            services.AddTransient<ISortActionFactory, SortActionFactory>();
            services.AddTransient<IFormManagerRepository, FormManagerRepository>();
            services.AddTransient<IFileSettingsRepository, FileSettingsRepository>();
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
