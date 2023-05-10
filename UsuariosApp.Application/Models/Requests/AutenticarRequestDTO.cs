using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Application.Models.Requests
{
    public class AutenticarRequestDTO
    {
        [EmailAddress(ErrorMessage ="Endereco de email inválido.")]
        [Required(ErrorMessage ="Informe o email.")]
        public string? Email { get; set; }
        
        [MinLength(8, ErrorMessage = "Senha deve conter pelo menos {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Senha deve conter, no máximo, {1} caracteres")]
        [Required(ErrorMessage = "Informe a senha.")]
        public string? Senha { get; set; }
    }
}
