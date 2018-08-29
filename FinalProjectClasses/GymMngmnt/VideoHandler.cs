using System.Collections.Generic;
using System.Linq;

namespace FinalProjectClasses.GymMngmnt
{
    public class VideoHandler
    {
        private Dbcontext _db = new Dbcontext();
        public Video GetVideoByValue(string value)
        {
            using (_db)
            {
                return (from c in _db.Videos where c.AddDays == value select c).FirstOrDefault();

            }

        }
        public List<Video> GetAllVideos()
        {
            using (_db)
            {
                return (from c in _db.Videos select c).ToList();
            }
        }

        public List<Image> GetAllImages()
        {
            using (_db)
            {
                return (from c in _db.Images select c).ToList();
            }
        }
    }
}
