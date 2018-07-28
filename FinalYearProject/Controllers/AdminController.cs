using FinalProjectClasses;
using FinalProjectClasses.UserMgment;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

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

        public int GetUserCount()
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                return (from c in db.Users select c).Count();
            }

        }
        public int GetMemberCount()
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                return (from c in db.Members select c).Count();
            }

        }
        public int GetPaymentCount()
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                return (from c in db.Members select c).Count();
            }

        }
        public int GetAttandanceCount()
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                return (from c in db.Attandances select c).Count();
            }

        }
        public int GetVideosCount()
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                return (from c in db.Videos select c).Count();
            }

        }



    }
}
