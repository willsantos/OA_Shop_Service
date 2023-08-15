namespace Domain.Entities;

public partial class Assinatura : Entidade
{
    public DateTime? DataInicio { get; set; }

    public DateTime? DataFim { get; set; }

    public ulong? RenovacaoAutomatica { get; set; }

    public Guid? CursoId { get; set; }

    public Guid? UsuarioId { get; set; }

    public virtual Curso? Curso { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
