using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        // ������ ��������
        public virtual DbSet<Project> Projects { get; set; }

        // ������ �����
        public virtual DbSet<TaskItem> Tasks { get; set; }
    }
}
