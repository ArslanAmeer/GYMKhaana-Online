using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        public List<Attandance> GetAttandancebyRollNo(int rollNo)
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                return (from c in db.Attandances.Include(m => m.Member).Include(m => m.AttandanceDdl) where c.Member.RollNo == rollNo select c).ToList();
            }
        }

        public List<Contact> GetAllMessages()
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                return (from c in db.Contacts select c).ToList();
            }
        }
    }
}
