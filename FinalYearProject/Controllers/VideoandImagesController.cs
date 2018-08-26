using FinalProjectClasses;
using FinalProjectClasses.GymMngmnt;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace FinalYearProject.Controllers
{
    public class VideoandImagesController : Controller
    {
        // GET: VideoandImages
        public ActionResult Index()
        {
            List<Video> videos = new VideoHandler().GetAllVideos();
            return View(videos);
        }
        [HttpGet]
        public ActionResult AddVideos()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVideos(FormCollection data, Video video)
        {
            video.AddDays = data["AddDays"];
            Dbcontext db = new Dbcontext();

            using (db)
            {
                db.Videos.Add(video);
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult DeleteVideo(int id)
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                Video video = (from c in db.Videos where c.Id == id select c).FirstOrDefault();
                db.Entry(video).State = EntityState.Deleted;
                db.SaveChanges();
            }
            return Json("Delete", JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddImages()
        {
            return View();
        }

    }
}
