using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectClasses.GymMngmnt
{
    public class Attandance
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Member Member { get; set; }
        public virtual AttandanceDDL AttandanceDdl { get; set; }


    }
}
