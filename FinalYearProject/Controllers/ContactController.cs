using FinalProjectClasses;
using FinalProjectClasses.GymMngmnt;
using System.Web.Mvc;

namespace FinalYearProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SubmitMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitMessage(Contact contact)
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("SuccessMessage", "Contact");
            }
        }

        public ActionResult SuccessMessage()
        {
            return View();
        }
    }
}
