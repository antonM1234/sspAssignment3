using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sspAssignment3.Models
{
    public class NurseDbContext : DbContext
    {
        
        public NurseDbContext(DbContextOptions<NurseDbContext> options) : base(options)
        {

        }

        //This property is needed for DB operations
        public DbSet<Nurse> Nurses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nurse>().HasData(
                new Nurse
                {
                    ID = 1,
                    Name = "DefaultNurse1",
                    Email = "DefaultNurse1@gmail.com",
                    Section = SectionEnum.Section1
                },
                new Nurse
                {
                    ID = 2,
                    Name = "DefaultNurse2",
                    Email = "DefaultNurse2@hotmail.com",
                    Section = SectionEnum.Section2
                },
                new Nurse
                {
                    ID = 3,
                    Name = "DefaultNurse3",
                    Email = "DefaultNurse3@yahoo.com",
                    Section = SectionEnum.Section3
                }
             );
        }

    }
}

