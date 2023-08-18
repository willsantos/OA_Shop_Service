using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Contracts.Requests
{
    public class TransacaoRequest : BaseRequest
    {
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public MetodoPagamento MetodoPagamento { get; set; }
        [Required]
        public string TokenPagamento { get; set; }
    }
}
