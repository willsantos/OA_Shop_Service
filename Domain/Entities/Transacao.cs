using Domain.Entities.Enums;

namespace Domain.Entities;

public partial class Transacao : Entidade
{
    public decimal Valor { get; set; }

    public DateTime Data { get; set; } = DateTime.Now;

    public Status Status { get; set; } = Status.Pendente;

    public MetodoPagamento MetodoPagamento { get; set; }

    public string TokenPagamento { get; set; }

    public Guid? AssinaturaId { get; set; }
    public virtual Assinatura? Assinatura { get; set; }
}
