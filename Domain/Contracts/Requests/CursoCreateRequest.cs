using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Contracts.Requests
{
    public class CursoCreateRequest : BaseRequest
    {
        [Required]
        public string Nome { get; set; } = null!;
        [Required]
        public string Descricao { get; set; }
        [Required]
        public decimal Preco { get; set; }
        [Required]
        public int Duracao { get; set; }
        [Required]
        public string Autor { get; set; } = null!;
        public string? Imagem { get; set; }
        [Required]
        [NotMapped]
        public IEnumerable<Guid> Categorias { get; set; }
    }
}
