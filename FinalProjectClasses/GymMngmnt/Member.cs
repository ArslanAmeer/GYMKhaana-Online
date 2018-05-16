using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProjectClasses.UserMgment;

namespace FinalProjectClasses.GymMngmnt
{
    public class Member
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public long CNIC { get; set; }
        public long MobileNo { get; set; }
        public string FullAddress { get; set; }
        public DateTime DateofBirth { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public float Fee { get; set; }
        [Required]
        public DateTime SubmissionDate { get; set; }
        [Required]
        public DateTime CurrentDate { get; set; }
        [Required]
        public int RollNo { get; set; }
        [Required]
        public string SubmitTo { get; set; }
        public virtual Gender Gender { get; set; }


    }
}
