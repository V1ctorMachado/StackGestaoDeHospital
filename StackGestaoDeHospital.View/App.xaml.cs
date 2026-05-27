using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackGestaoDeHospital.DataBase;
using System.IO;
using System.Windows;

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
        }

        private void ConfigureDBContext()
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

            connectionString = connectionString.Replace("{DB_PASSWORD}", dbPassword);

            var options = new DbContextOptionsBuilder<HospitalDbContext>()
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
    }

}
