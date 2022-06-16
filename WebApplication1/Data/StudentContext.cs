using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext (DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPI.StudentModel>? StudentModel { get; set; }
        public DbSet<UniversityModel>? UniversityModel { get; set; }
    }
}
