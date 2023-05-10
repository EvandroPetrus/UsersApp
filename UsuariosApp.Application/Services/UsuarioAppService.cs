using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Application.Interfaces;
using UsuariosApp.Application.Models.Requests;
using UsuariosApp.Application.Models.Responses;

namespace UsuariosApp.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        AutenticarResponseDTO IUsuarioAppService.Autenticar(AutenticarRequestDTO dto)
        {
            throw new NotImplementedException();
        }

        CriarContaResponseDTO IUsuarioAppService.CriarConta(CriarContaRequestDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
