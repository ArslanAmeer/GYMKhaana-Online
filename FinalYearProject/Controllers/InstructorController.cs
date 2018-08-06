using FinalProjectClasses;
using FinalProjectClasses.GymMngmnt;
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
            using (db)
            {
                db.Instructers.Add(instructer);
                db.SaveChanges();
            }
            return View();
        }
    }
}
