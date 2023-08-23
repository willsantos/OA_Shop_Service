using Domain.Entities.Enums;

namespace Domain.Contracts.Responses
{
    public class TransacaoResponse : BaseResponse
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Pendente;
        public MetodoPagamento MetodoPagamento { get; set; }
        public string TokenPagamento { get; set; }
    }
}
