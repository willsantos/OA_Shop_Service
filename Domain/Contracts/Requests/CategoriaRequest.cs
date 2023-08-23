using System.ComponentModel.DataAnnotations;

namespace Domain.Contracts.Requests
{
    public class CategoriaRequest : BaseRequest
    {
        [Required]
        public string Nome { get; set; }
    }
}
