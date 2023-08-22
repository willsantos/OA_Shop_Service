namespace Domain.Entities;

public partial class Endereco : Entidade
{
    public string Rua { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public string? Complemento { get; set; }

    public string Bairro { get; set; }

    public string Cidade { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Cep { get; set; } = null!;

    public bool Principal { get; set; }

    public Guid UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; }
}
