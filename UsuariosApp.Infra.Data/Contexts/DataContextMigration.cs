using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Infra.Data.Contexts
{
    public class DataContextMigration : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            // searching and reading appsettings.json
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            // Search for connectionstring on file
            var root = configurationBuilder.Build();
            var connectionString = root.GetConnectionString("UsuariosApp");

            // Independency Injection to appsettings.json
            var builder = new DbContextOptionsBuilder<DataContext>();            
            builder.UseSqlServer(connectionString);

            return new DataContext(builder.Options);

           // Migration conventions: InitialMigrations, AddX, AlterX, RemoveX 
        }
    }
}
