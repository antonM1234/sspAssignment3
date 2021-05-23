using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sspAssignment3.Models
{
    public class NurseSQLRepository : INurseRepository
    {
        private IEnumerable<Nurse> nurses;

        public NurseSQLRepository()
        {
            nurses = new List<Nurse>()
            {
                new Nurse() { ID= 1, Name="aaa", Email="aaa@a.com", Section="first"},
                new Nurse() { ID= 2, Name="bbb", Email="bbb@a.com", Section="Second"},
                new Nurse() { ID= 3, Name="ccc", Email="ccc@a.com", Section="Third"}
            };
        }

        public Nurse GetNurse(int ID)
        {
            return nurses.Where(e => e.ID == ID).FirstOrDefault();
        }

        public IEnumerable<Nurse> ShowAllNurses()
        {
            return nurses;
        }

        //Add(Nurse n), Delete(int id) and Update(Nurse n) methods:

        public Nurse AddNurse(Nurse n) 
        {
            n.ID = nurses.Max(e => e.ID) + 1;
            ((List<Nurse>)nurses).Add(n);
            return n;
        }
        public Nurse DeleteNurse(int ID)
        {
            Nurse n = nurses.FirstOrDefault(e => e.ID == ID);
            if(n != null)
            {
                ((List<Nurse>)nurses).Remove(n);
            }
            return n;
        }

        public Nurse UpdateNurse(Nurse n)
        {
            Nurse nTemp = nurses.FirstOrDefault(e => e.ID == n.ID);
            if (nTemp != null)
            {
                nTemp.Name = n.Name;
                nTemp.Email = n.Email;
                nTemp.Section = n.Section;
            }
            return nTemp;
        }

    }
}
