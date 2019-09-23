using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http;
using aspApi.Database;
using aspApi.Models;

namespace aspApi.Controllers
{
    public class EventoController : ControllerBase
    {
        private ApiDBContext context;

        public EventoController(ApiDBContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
        {
            return await context.Eventos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var evento = await context.Eventos.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }
            return evento;
        }
    }
}