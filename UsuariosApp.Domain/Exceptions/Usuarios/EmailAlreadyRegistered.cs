using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Exceptions.Usuarios
{
    public class EmailAlreadyRegistered : Exception
    {
        public override string Message
            => "The given email has already been registered.";
    }
}
