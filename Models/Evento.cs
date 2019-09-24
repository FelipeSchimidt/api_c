using System;
using System.ComponentModel.DataAnnotations;

namespace aspApi.Models
{
    public class Evento
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Nome do evento obrigatório")]
        public string name { get; set; }
        public string description { get; set; }
        [Required(ErrorMessage = "Data do evento obrigatório")]
        public DateTime dateEvent { get; set; }

    }
}