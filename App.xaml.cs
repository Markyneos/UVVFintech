using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using UvvFintech.Data;
using UvvFintech.Data.Repositories;
using UvvFintech.Controller.Services;

namespace UvvFintech
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider serviceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();

            services.AddSingleton<AppDbContext>();

            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IClienteService, ClienteService>();

            serviceProvider = services.BuildServiceProvider();

            var main = serviceProvider.GetRequiredService<MainWindow>();
            main.Show();

            base.OnStartup(e);
        }
    }

}
