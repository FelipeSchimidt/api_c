using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using aspApi.Models;
using aspApi.Database;

namespace aspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {

        private ApiDBContext context;

        public AgendaController(ApiDBContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agenda>>> GetAgendas()
        {
            var agenda = await context.Agendas.ToListAsync();
            if (agenda == null)
            {
                return NotFound();
            }
            return agenda;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agenda>> GetAgenda(int id)
        {
            var agenda = await context.Agendas.FindAsync(id);
            if (agenda == null)
            {
                return NotFound();
            }
            return agenda;
        }

        [HttpPost]
        public async Task<ActionResult<Agenda>> CreateAgenda(Agenda agenda)
        {
            var usuario = context.Usuarios.FirstAsync(x => x.id == agenda.UsuarioId);
            if (usuario == null)
            {
                return NotFound();
            }
            var evento = context.Eventos.FirstAsync(x => x.id == agenda.EventoId);
            if (evento == null)
            {
                return NotFound();
            }

            context.Agendas.Add(agenda);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAgenda), agenda);
        }

    }
}