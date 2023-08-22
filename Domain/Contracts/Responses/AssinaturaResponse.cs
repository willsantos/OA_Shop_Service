using Domain.Entities;

namespace Domain.Contracts.Responses
{
    public class AssinaturaResponse : BaseResponse
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool RenovacaoAutomatica { get; set; }
        public bool Ativa { get; set; }
        public Guid CursoId { get; set; }
        public Guid UsuarioId { get; set; }
        public TransacaoResponse Transacao { get; set; }
    }
}
