using System.ComponentModel.DataAnnotations;

namespace Domain.Contracts.Requests
{
    public class EnderecoRequest : BaseRequest
    {
        [Required]
        public string Rua { get; set; } = null!;
        [Required]
        public string Numero { get; set; } = null!;
        public string? Complemento { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; } = null!;
        [Required]
        public string Estado { get; set; } = null!;
        [Required]
        public string Cep { get; set; } = null!;
        [Required]
        public bool Principal { get; set; }
        [Required]
        public Guid UsuarioId { get; set; }
    }
}
