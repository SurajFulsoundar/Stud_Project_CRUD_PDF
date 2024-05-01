using Microsoft.EntityFrameworkCore;
using Stud_Project_CRUD_PDF.Models;

namespace Stud_Project_CRUD_PDF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Student> Stud { get; set; }
    }
}
