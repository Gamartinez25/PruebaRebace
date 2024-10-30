using CQRS.PRACTICA.PATRON.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRS.PRACTICA.PATRON.Persistencia
{
    public class ContextoTarea : DbContext
    {
        public ContextoTarea(DbContextOptions<ContextoTarea> options) : base(options) { }
        public DbSet<TaskItem> TaskItem { get; set; } 

        
    }
}
