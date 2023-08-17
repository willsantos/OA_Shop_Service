namespace Domain.Contracts.Requests
{
    public class CursoEditRequest : BaseRequest
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = null!;

        public string? Descricao { get; set; }

        public decimal? Preco { get; set; }

        public int? Duracao { get; set; }

        public string Autor { get; set; } = null!;

        public string? Imagem { get; set; }

    }
}
