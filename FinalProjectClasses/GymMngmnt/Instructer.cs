using System.ComponentModel.DataAnnotations;

namespace FinalProjectClasses.GymMngmnt
{
    public class Instructer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Experience { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public string FullAddress { get; set; }
        [Required]
        public long PhoneNo { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Achivements { get; set; }

        public Member Member { get; set; }


    }
}
