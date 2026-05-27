using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using StackGestaoDeHospital.DataBase;

public class HospitalDbContextFactory : IDesignTimeDbContextFactory<HospitalDbContext>
{
    public HospitalDbContext CreateDbContext(string[] args)
    {
        var solutionPath = Directory.GetCurrentDirectory();

        Env.Load(Path.Combine(solutionPath, ".env"));

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(solutionPath, "StackGestaoDeHospital.View"))
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

        connectionString = connectionString!
            .Replace("{DB_PASSWORD}", dbPassword);

        var options = new DbContextOptionsBuilder<HospitalDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        return new HospitalDbContext(options);
    }
}