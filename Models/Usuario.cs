using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspApi.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Nome obrigatorio")]
        public string firstName { get; set; }
        public string lastName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime birth { get; set; }
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Insira um endereço de email valido")]
        [Required(ErrorMessage = "Email obrigatorio")]
        public string mail { get; set; }
        public string passwords { get; set; }
        public IList<Agenda> Agendas { get; set; }
    }
}