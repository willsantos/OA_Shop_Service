namespace Domain.Entities;

public partial class Usuario : Entidade
{
    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public virtual ICollection<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();

    public virtual ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
}
