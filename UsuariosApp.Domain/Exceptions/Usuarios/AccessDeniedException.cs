using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Exceptions.Usuarios
{
    /// <summary>
    /// Exception made for unauthorized accesses
    /// </summary>
    public class AccessDeniedException : Exception
    {
        public override string Message
            => "Access denied. Invalid user.";
    }
}
