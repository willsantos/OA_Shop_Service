using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public virtual ICollection<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();

        public virtual ICollection<CursoCategoria> CursoCategoria { get; set; } = new List<CursoCategoria>();

        public virtual ICollection<Transacao> Transacaos { get; set; } = new List<Transacao>();
    }
}
