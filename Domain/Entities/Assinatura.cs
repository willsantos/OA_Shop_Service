namespace Domain.Entities;

public partial class Assinatura : Entidade
{
    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public bool RenovacaoAutomatica { get; set; } = true;
    public bool Ativa { get; set; } 

    public Guid CursoId { get; set; }

    public virtual Curso Curso { get; set; }

    public Guid UsuarioId { get; set; }

    public virtual Usuario Usuario { get; set; }

    public Guid? TransacaoId { get ; set; }
    public virtual Transacao? Transacao { get; set; }
}
