namespace Domain.Entities;

public partial class Transacao : Entidade
{
    public decimal? Valor { get; set; }

    public DateTime? Data { get; set; }

    public string? Status { get; set; }

    public string? MetodoPagamento { get; set; }

    public string? TokenPagamento { get; set; }

    public Guid? CursoId { get; set; }

    public Guid? UsuarioId { get; set; }

    public virtual Curso? Curso { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
