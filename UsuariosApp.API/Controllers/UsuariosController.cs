using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UsuariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Autenticação de usuários
        /// </summary>
        [HttpPost]
        [Route("autenticar")]
        public IActionResult Autenticar()
        {
            return Ok();        
        }

        /// <summary>
        /// Criação de conta de usuários
        /// </summary>
        [HttpPost]
        [Route("criar-conta")]
        public IActionResult CriarConta()
        {
            return Ok();
        }
    }
}
