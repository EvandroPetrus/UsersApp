using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Models;

namespace UsuariosApp.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService : IDisposable
    {
        Usuario Autenticar(string email, string senha);
        void CriarConta(Usuario usuario);
        Usuario RecuperarSenha(string email);

    }
}
