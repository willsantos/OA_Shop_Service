using System.ComponentModel.DataAnnotations;

namespace Domain.Contracts.Requests
{
    public class UsuarioEditRequest
    {
        public string? Nome { get; set; }
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string? Email { get; set; }
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$",
        ErrorMessage = "A senha deve ter pelo menos 8 caracteres e um número.")]
        public string? Senha { get; set; }
    }
}
