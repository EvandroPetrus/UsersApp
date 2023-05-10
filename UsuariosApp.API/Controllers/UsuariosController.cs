using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApp.Application.Interfaces;
using UsuariosApp.Application.Models.Requests;
using UsuariosApp.Application.Models.Responses;

namespace UsuariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioAppService? _usuarioAppService;

        public UsuariosController(IUsuarioAppService? usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        /// <summary>
        /// Autenticação de usuários
        /// </summary>
        [HttpPost]
        [Route("autenticar")]
        [ProducesResponseType(typeof(AutenticarResponseDTO), 200)]
        public IActionResult Autenticar(AutenticarRequestDTO dto)
        {
            return Ok();        
        }

        /// <summary>
        /// Criação de conta de usuários
        /// </summary>
        [HttpPost]
        [Route("criar-conta")]
        [ProducesResponseType(typeof(CriarContaResponseDTO), 201)]
        public IActionResult CriarConta(CriarContaRequestDTO dto)
        {
            return Ok();
        }
    }
}
