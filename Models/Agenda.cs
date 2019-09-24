using System.ComponentModel.DataAnnotations.Schema;

namespace aspApi.Models
{
    public class Agenda
    {
        public int Id { get; set; }
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        [ForeignKey("Evento")]
        public int EventoId { get; set; }
        public string Observacao { get; set; }
    }
}