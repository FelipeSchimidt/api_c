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


    }
}