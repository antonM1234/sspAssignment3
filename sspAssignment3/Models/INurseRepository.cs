using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sspAssignment3.Models
{
    public interface INurseRepository
    {
        public IEnumerable<Nurse> ShowAllNurses();

        public Nurse GetNurse(int ID);

        public Nurse AddNurse(Nurse n);

        public Nurse DeleteNurse(int ID);

        public Nurse UpdateNurse(Nurse n);

    }
}
