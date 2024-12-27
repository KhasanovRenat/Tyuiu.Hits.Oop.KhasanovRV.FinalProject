using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        // Список проектов
        public virtual DbSet<Project> Projects { get; set; }

        // Список задач
        public virtual DbSet<TaskItem> Tasks { get; set; }
    }
}
