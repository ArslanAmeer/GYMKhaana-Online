using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectClasses.UserMgment;

namespace FinalProjectClasses.GymMngmnt
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public double PaidAmount { get; set; }
        public virtual Member Member { get; set; }
        public DateTime FeeDate { get; set; }

    }
}
