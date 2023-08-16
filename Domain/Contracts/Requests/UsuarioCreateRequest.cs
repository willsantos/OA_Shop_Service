using System.ComponentModel.DataAnnotations;

namespace Domain.Contracts.Requests
{
    public class UsuarioCreateRequest : BaseRequest
    {
        [Required(ErrorMessage ="O campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage ="Email inválido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$",
        ErrorMessage ="A senha deve ter pelo menos 8 caracteres e um número.")]
        public string Senha { get; set; }
    }
}
