using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProjectClasses;
using FinalProjectClasses.GymMngmnt;

namespace FinalYearProject.Controllers
{
    public class HomeController : Controller
    {
        Dbcontext db = new Dbcontext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Monday(int val)
        {
            Video video = new VideoHandler().GetVideoByValue(Convert.ToString(val));
            return View(video);
        }

        public ActionResult Tuesday(int val)
        {
            Video video = new VideoHandler().GetVideoByValue(Convert.ToString(val));
            return View(video);
        }

        public ActionResult Wednesday(int val)
        {
            Video video = new VideoHandler().GetVideoByValue(Convert.ToString(val));
            return View(video);
        }

        public ActionResult Thursday(int val)
        {
            Video video = new VideoHandler().GetVideoByValue(Convert.ToString(val));
            return View(video);
        }

        public ActionResult Friday(int val)
        {
            Video video = new VideoHandler().GetVideoByValue(Convert.ToString(val));
            return View(video);
        }

        public ActionResult Saturday(int val)
        {
            Video video = new VideoHandler().GetVideoByValue(Convert.ToString(val));
            return View(video);
        }

        public ActionResult Sunday(int val)
        {
            Video video = new VideoHandler().GetVideoByValue(Convert.ToString(val));
            return View(video);
        }
    }
}