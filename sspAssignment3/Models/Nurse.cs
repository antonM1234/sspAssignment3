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
        public SectionEnum Section { get; set; }
    }
}
