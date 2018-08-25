using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectClasses.UserMgment
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"\\A[^\\W\\d_]+\\z", ErrorMessage = "Your Name did'nt consist of No...!")]
        public string Fullname { get; set; }
        [Required]
        public string Loginid { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "CNIC")]
        public long Cnic { get; set; }
        [Required]
        public string Shift { get; set; }
        public DateTime DateofBirth { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public long MobileNo { get; set; }
        [Required]
        public string FullAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }

        public virtual Gender Gender { get; set; }
        public Role Role { get; set; }
        public bool IsInRole(int id)
        {
            return (Role != null && Role.Id == id);
        }
    }
}
