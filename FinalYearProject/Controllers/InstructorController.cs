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
    public class InstructorController : Controller
    {
        // GET: Instructor
        public ActionResult Index()
        {
            List<Instructer> instructers = new PaymentHandler().GeInstructerList();
            return View(instructers);
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

        public int GetInstrCount()
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                return (from c in db.Instructers select c).Count();

            }
        }
        [HttpGet]
        public ActionResult UpdateInstructor(int id)
        {
            Instructer instructer = new PaymentHandler().GetInstructerById(id);
            return View(instructer);
        }
        [HttpPost]
        public ActionResult UpdateInstructor(Instructer instructer)
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                db.Entry(instructer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Instructor");
            }
        }

        public ActionResult Delete(int id)
        {
            Dbcontext db = new Dbcontext();
            Instructer p = (from c in db.Instructers
                            where c.Id == id
                            select c).FirstOrDefault();
            db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();
            return Json("Delete", JsonRequestBehavior.AllowGet);
        }
    }
}
