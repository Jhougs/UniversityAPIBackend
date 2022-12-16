using Microsoft.EntityFrameworkCore;
using UniversityAPIBackend.Models.DataModels;

namespace UniversityAPIBackend.DataAcess
{
    public class UniversityDBContext: DbContext
    {
        public UniversityDBContext( DbContextOptions<UniversityDBContext> options): base(options) 
        {
        
            
        
        }

        // Add Dbsets(Tables of our Data base)
        public DbSet<User>? Users { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }


    }
}
