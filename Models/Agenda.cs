namespace aspApi.Models
{
    public class Agenda
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdEvento { get; set; }
        public string Observacao { get; set; }
    }
}