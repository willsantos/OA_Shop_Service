using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Requests
{
    public class CursoCreateRequest : BaseRequest
    {
        public string Nome { get; set; } = null!;

        public string? Descricao { get; set; }

        public decimal? Preco { get; set; }

        public int? Duracao { get; set; }

        public string Autor { get; set; } = null!;

        public string? Imagem { get; set; }
    }
}
