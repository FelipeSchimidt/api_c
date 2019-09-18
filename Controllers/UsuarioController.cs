using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Usuario> Get()
        {
            return context.Usuarios.ToList();
        }

        [HttpPost]
        public Usuario Post(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();

            return usuario;
        }
    }
}