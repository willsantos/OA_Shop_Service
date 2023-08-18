using Domain.Entities.Enums;

namespace Domain.Contracts.Responses
{
    public class TransacaoResponse : BaseResponse
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public Status Status { get; set; }
        public MetodoPagamento MetodoPagamento { get; set; }
        public string TokenPagamento { get; set; }
        public Guid CursoId { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
