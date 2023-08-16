using Domain.Contracts.Requests;

namespace Test.Service
{
    internal class CursoRequest : CursoCreateRequest
    {
        public string Nome { get; set; }
    }
}