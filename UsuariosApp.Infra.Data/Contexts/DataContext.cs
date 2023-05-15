using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Models;
using UsuariosApp.Infra.Data.Configurations;

namespace UsuariosApp.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        // USED ONLY FOR ON MEMORY DATABASE
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase(databaseName: "UsuariosApp");
        //}
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }

        public DbSet<Usuario>? Usuarios { get; set; }
    }
}
