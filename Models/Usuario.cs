using System;

namespace aspApi.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birth { get; set; }
        public string mail { get; set; }
        public string passwords { get; set; }
    }
}