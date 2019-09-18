using Microsoft.EntityFrameworkCore;
using aspApi.Models;

namespace aspApi.Database
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}