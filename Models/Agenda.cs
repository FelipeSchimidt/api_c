using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspApi.Models
{
    public class Agenda
    {
        [Required(ErrorMessage = "Informe o id do Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [Required(ErrorMessage = "Informe o id do Evento")]
        public int EventoId { get; set; }
        public Evento evento { get; set; }
        public string observacao { get; set; }
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }
    }
}