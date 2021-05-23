using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sspAssignment3.Models
{
    public class Nurse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        //This property is defined as enum since we assume we have a fixed number of sections
        public SectionEnum Section { get; set; }

    }
}
