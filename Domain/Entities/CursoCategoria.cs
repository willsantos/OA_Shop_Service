namespace Domain.Entities;

public partial class CursoCategoria : Entidade
{
    public Guid CursoId { get; set; }

    public Guid CategoriaId { get; set; }

    public virtual Categoria Categoria { get; set; }

    public virtual Curso Curso { get; set; }
}
