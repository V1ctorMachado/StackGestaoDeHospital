using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackGestaoDeHospital.DataBase;
using StackGestaoDeHospital.View.Views.Handlers;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace StackGestaoDeHospital.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IConfiguration Configuration { get; private set; } = null!;
        public static HospitalDbContext DBContext { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Env.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", ".env"));

            ConfigureAppSettings();
            ConfigureDBContext();

            var mainWindow = new MainWindow();
            mainWindow.Show();

            DispatcherUnhandledException += HandleExcecao;
        }

        private void ConfigureDBContext()
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            var options = new DbContextOptionsBuilder<HospitalDbContext>()
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString)
                .Options;

            DBContext = new HospitalDbContext(options);
        }

        private void ConfigureAppSettings()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        private void HandleExcecao(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            ExceptionHandler.Show(e.Exception);
            e.Handled = true;
        }
    }

}
