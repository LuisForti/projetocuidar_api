using Microsoft.EntityFrameworkCore;
using ProjetoCuidar_API.Models;

namespace ProjetoCuidar_API.Data
{
    public class CuidarContext: DbContext
    {
        public CuidarContext(DbContextOptions<CuidarContext> options): base (options)
        {
        }
        public DbSet<Usuario> Usuario {get; set;}
    }
}