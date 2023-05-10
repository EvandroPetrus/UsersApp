using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository? UsuarioRepository { get; }
        void SaveChanges();
    }
}
