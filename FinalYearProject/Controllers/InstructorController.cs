using FinalProjectClasses;
using FinalProjectClasses.GymMngmnt;
using System;
using System.Web;
using System.Web.Mvc;

namespace FinalYearProject.Controllers
{
    public class InstructorController : Controller
    {
        // GET: Instructor
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult HireInstructor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HireInstructor(Instructer instructer)
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
                    string url = "~/Content/InstructorImages/" + abc;
                    string path = Request.MapPath(url);
                    instructer.ImageUrl = abc;
                    file.SaveAs(path);
                }
            }
            using (db)
            {
                db.Instructers.Add(instructer);
                db.SaveChanges();
            }
            return View();
        }
    }
}
