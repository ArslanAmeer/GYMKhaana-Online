using System;
using System.ComponentModel.DataAnnotations;

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
