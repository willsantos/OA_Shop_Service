namespace Domain.Entities;

public partial class Categoria : Entidade
{
    public string Nome { get; set; } = null!;

    public virtual ICollection<CursoCategoria> CursoCategoria { get; set; } = new List<CursoCategoria>();
}
