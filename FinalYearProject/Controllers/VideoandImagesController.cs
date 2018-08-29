using FinalProjectClasses;
using FinalProjectClasses.GymMngmnt;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
        [HttpGet]
        public ActionResult AddImages()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddImages(Image images)
        {
            Dbcontext db = new Dbcontext();
            int counter = 0;
            long uno = DateTime.Now.Ticks;

            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];
                if (!string.IsNullOrEmpty(file.FileName))
                {
                    string abc = uno + "_" + ++counter +
                                 file.FileName.Substring(file.FileName.LastIndexOf("."));
                    string url = "~/Content/GalleryImages/" + abc;
                    string path = Request.MapPath(url);
                    images.ImageUrl = abc;
                    file.SaveAs(path);
                }
            }

            using (db)
            {
                db.Images.Add(images);
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult Gallery()
        {
            List<Image> images = new VideoHandler().GetAllImages();
            return View(images);
        }


    }
}
