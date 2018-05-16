using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProjectClasses;
using FinalProjectClasses.GymMngmnt;

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
    }
}