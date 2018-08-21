using FinalProjectClasses;
using FinalProjectClasses.GymMngmnt;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace FinalYearProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            List<Contact> contact = new MemberHandler().GetAllMessages();
            return View(contact);
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

        public ActionResult DeleteContact(int id)
        {
            Dbcontext db = new Dbcontext();
            Contact p = (from c in db.Contacts
                         where c.Id == id
                         select c).FirstOrDefault();
            db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();
            return Json("Delete", JsonRequestBehavior.AllowGet);
        }
    }
}
