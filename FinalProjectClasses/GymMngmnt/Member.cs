using FinalProjectClasses.UserMgment;
using System;
using System.ComponentModel.DataAnnotations;

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
        public int TotalPaidAmount { get; set; }
        public virtual Gender Gender { get; set; }
        public Instructer Instructer { get; set; }


    }
}
