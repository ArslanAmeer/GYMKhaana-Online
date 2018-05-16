using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectClasses.UserMgment
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Gender")]
        public string Name { get; set; }
    }
}
