namespace Domain.Contracts.Responses
{
    public class CategoriaResponse : BaseResponse
    {
        public string Nome { get; set; }
        public IEnumerable<Guid> Cursos { get; set; }
    }
}
