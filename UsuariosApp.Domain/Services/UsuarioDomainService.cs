using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Models;

namespace UsuariosApp.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUnitOfWork? _unitOfWork;

        public UsuarioDomainService(IUnitOfWork? unitOfWork)        
            => _unitOfWork = unitOfWork;
        

        public void CriarConta(Usuario usuario)
        {
            _unitOfWork?.UsuarioRepository?.Add(usuario);
            _unitOfWork?.SaveChanges();
        }

        public void Dispose()        
            => _unitOfWork?.Dispose();        
    }
}
