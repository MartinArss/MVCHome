using Microsoft.EntityFrameworkCore;
using MVCHome.Models;

namespace MVCHome.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Usuario> UsuarioDb { get; set; }
        public DbSet<Roles> RolDb { get; set; }
    }
}
