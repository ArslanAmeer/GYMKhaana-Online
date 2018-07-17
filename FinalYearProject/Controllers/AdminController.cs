using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProjectClasses;
using FinalProjectClasses.UserMgment;

namespace FinalYearProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserDetails()
        {
            List<User> u = new UserHandler().GetUsers();
            return View(u);
        }
        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            User user = new UserHandler().GetUserById(id);
            return View(user);
        }

        public ActionResult UpdateUser(FormCollection formdata)
        {
            return View();
        }

        public JsonResult DeleteUesr(int id)
        {
            Dbcontext db = new Dbcontext();
            User p = (from c in db.Users
                .Include(x => x.Role)
                .Include(x => x.Gender)
                      where c.Id == id
                      select c).FirstOrDefault();
            db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();
            return Json("Delete", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AdminProfile(int id)
        {
            User u = new UserHandler().GetUserById(id);
            return View(u);
        }

    }
}