using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Application.Models.Requests
{
    public class CriarContaRequestDTO
    {
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{8,150}$",
            ErrorMessage = "Informe um nome válido de 8 a 150 caracteres.")]
        [Required(ErrorMessage = "Informe o nome do usuário")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Endereço de email inválido.")]
        [Required(ErrorMessage = "Informe o email.")]
        public string? Email { get; set; }

        [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$",
            ErrorMessage = "Informe uma senha forte com no mínimo 8 caracteres.")]
        [Required(ErrorMessage = "Informe a senha.")]
        public string? Senha { get; set; }
    }
}



