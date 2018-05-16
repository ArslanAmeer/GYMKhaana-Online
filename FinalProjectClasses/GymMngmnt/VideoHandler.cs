using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectClasses.GymMngmnt
{
    public class VideoHandler
    {
        Dbcontext db = new Dbcontext();
        public Video GetVideoByValue(string value)
        {
            using (db)
            {
                return (from c in db.Videos where c.AddDays == value select c).FirstOrDefault();

            }

        }
        public List<Video> GetAllVideos()
        {
            using (db)
            {
                return (from c in db.Videos select c).ToList();
            }
        }
    }
}
