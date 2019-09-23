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
    public class UsuarioController : ControllerBase
    {
        private ApiDBContext context;

        public UsuarioController(ApiDBContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await context.Usuarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();

            /** 
            * CreatedAtAction
            * 1º - Retorna STATUSCODE = 201 e adiciona ao Location a resposta
            * 2º - Refencia a ação GetUsuario
            * 3º - retorna usuário no qual usuario.include == id
            */
            return CreatedAtAction(nameof(GetUsuario),
                new { id = usuario.id },
                usuario
                );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> UpdateUsuario(int id, [FromBody]Usuario usuario)
        {
            if (id != usuario.id)
            {
                return BadRequest();
            }

            /**
            * Especifica uma entitdade que tera seu estado alterado
            */
            context.Entry(usuario).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (context.Usuarios.Find(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return usuario;

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var user = await context.Usuarios.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            context.Usuarios.Remove(user);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}