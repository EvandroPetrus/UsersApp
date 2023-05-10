using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Models;

namespace UsuariosApp.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario, Guid>
    {

    }
}
