using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sspAssignment3.Models
{
    public class NurseSQLRepository : INurseRepository
    {
        
        //This injection is used to access the CRUD methods in the DbContext class
        private NurseDbContext context;
        public NurseSQLRepository(NurseDbContext context)
        {
            this.context = context;
        }

        public Nurse GetNurse(int ID)
        {
            return context.Nurses.Find(ID);
        }

        public IEnumerable<Nurse> ShowAllNurses()
        {
            return context.Nurses;
        }

        //Add(Nurse n), Delete(int id) and Update(Nurse n) methods:

        public Nurse AddNurse(Nurse n) 
        {
            
            context.Nurses.Add(n);
            context.SaveChanges();
            return n;
        }
        public Nurse DeleteNurse(int ID)
        {
            //Making sure the nurse we're deleting actually exists
            Nurse n = context.Nurses.Find(ID);
            
            //Making sure we do not delete a null object
            if (n != null)
            {
                context.Nurses.Remove(n); 
                context.SaveChanges();
            }
            return n;

        }

        public Nurse UpdateNurse(Nurse n)
        {
            var tempN = context.Nurses.Attach(n);
            tempN.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return n;
        }

    }
}
