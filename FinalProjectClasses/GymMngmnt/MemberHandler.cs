using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectClasses.GymMngmnt
{
    public class MemberHandler
    {
        Dbcontext db = new Dbcontext();
        public List<Member> GetMembers()
        {
            using (db)
            {
                return (from c in db.Members.Include(m => m.Gender) select c).ToList();
            }
        }

        public Member GetMemberById(int id)
        {
            using (db)
            {
                return (from c in db.Members.Include(v => v.Gender) where c.Id == id select c).FirstOrDefault();
            }
        }
        public Member GetUserByRollNo(int rollno)
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                return (from c in db.Members where c.RollNo == rollno select c).FirstOrDefault();
            }
        }
    }
}
