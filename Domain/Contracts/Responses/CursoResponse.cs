namespace Domain.Contracts.Responses
{
    public class CursoResponse : BaseResponse
    {
        public string Nome { get; set; } = null!;

        public string? Descricao { get; set; }

        public decimal? Preco { get; set; }

        public int? Duracao { get; set; }

        public string Autor { get; set; } = null!;

        public string? Imagem { get; set; }
        public ICollection<Guid> Categorias { get; set; }
    }
}
