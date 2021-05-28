using Microsoft.EntityFrameworkCore;
using ProjetoCuidar_API.Models;

namespace ProjetoCuidar_API.Data
{
    public class CuidarContext: DbContext
    {
        public CuidarContext(DbContextOptions<CuidarContext> options): base (options)
        {
        }
        public DbSet<Usuario> usuario {get; set;}
        public DbSet<Pet> pet {get; set;}
        public DbSet<Funcionario> funcionario {get; set;}
        public DbSet<UsuarioPet> usuarioPet {get; set;}
        public DbSet<UsuarioFuncionario> usuarioFuncionario {get; set;}
    }
}