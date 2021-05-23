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

    }
}

