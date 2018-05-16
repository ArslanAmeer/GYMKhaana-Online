using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectClasses.GymMngmnt
{
    public class AttandanceHandler
    {
        public List<Attandance> GetAttandances()
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                return (from c in db.Attandances
                    .Include(m => m.AttandanceDdl)
                    .Include(m => m.Member)
                        select c).ToList();
            }
        }

        public List<AttandanceDDL> GetDDL()
        {
            using (Dbcontext db = new Dbcontext())
            {
                return (from c in db.AttandanceDdls select c).ToList();
            }
        }

    }
}
