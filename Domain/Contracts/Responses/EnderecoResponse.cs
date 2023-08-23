namespace Domain.Contracts.Responses
{
    public class EnderecoResponse : BaseResponse
    {
        public string Rua { get; set; } 

        public string Numero { get; set; } 

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; } 

        public string Estado { get; set; } 

        public string Cep { get; set; } 

        public bool Principal { get; set; }

        public Guid UsuarioId { get; set; }
    }
}
