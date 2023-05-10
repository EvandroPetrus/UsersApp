using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Infra.Data.Contexts;

namespace UsuariosApp.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext? _dataContext;

        public UnitOfWork(DataContext? dataContext)
            => _dataContext = dataContext;       

        public IUsuarioRepository? UsuarioRepository 
            => new UsuarioRepository(_dataContext);

        public void Dispose()
            => _dataContext?.Dispose();        

        public void SaveChanges()
            => _dataContext?.Dispose();        
    }
}
