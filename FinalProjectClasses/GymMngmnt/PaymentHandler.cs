using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectClasses.GymMngmnt
{
    public class PaymentHandler
    {
        Dbcontext db = new Dbcontext();
        public List<Payment> GetPaymentList()
        {
            using (db)
            {
                return (from v in db.Payments
                        .Include(m => m.Member)
                        select v).ToList();
            }
        }

        public Payment GetPaymentById(int id)
        {
            using (db)
            {
                return (from c in db.Payments where id == c.Id select c).FirstOrDefault();
            }
        }
        public List<Payment> GetPaymentbyRollNo(int rollNo)
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                return (from c in db.Payments.Include(m => m.Member) where c.Member.RollNo == rollNo select c).ToList();
            }
        }

    }
}
