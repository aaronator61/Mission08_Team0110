using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

namespace Mission08_Team0110.Models
{
    public class TimeManagement : DbContext
    {
        
        public TimeManagement(DbContextOptions<TimeManagement> options): base(options)
        {
            
        }
        public DbSet<ApplicationResponse> responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { Id = 1, CatName = "Home" },
                new Category { Id = 2, CatName = "School" },
                new Category { Id = 3, CatName = "Work" },
                new Category { Id = 4, CatName = "Church" }

                );
        }
    }
}
