﻿using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Contracts.Requests
{
    public class AssinaturaRequest : BaseRequest
    {
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataFim { get; set; }
        [Required]
        public bool RenovacaoAutomatica { get; set; }
        [Required]
        public Guid CursoId { get; set; }
        [Required]
        public Guid UsuarioId { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public MetodoPagamento MetodoPagamento { get; set; }
        [Required]
        public string TokenPagamento { get; set; }
    }
}
