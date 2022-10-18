using Microsoft.EntityFrameworkCore;
using proyectoMVC.Models;

namespace proyectoMVC.Context
{
    public class AppContext : DbContext
    { 
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }


        public DbSet<User> users { get; set; }
        public DbSet<Mascota> mascotas { get; set; }
        public DbSet<Dador> dadores { get; set; }
      
    }
}
