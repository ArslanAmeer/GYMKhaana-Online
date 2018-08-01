using FinalProjectClasses;
using FinalProjectClasses.GymMngmnt;
using FinalYearProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace FinalYearProject.Controllers
{
    public class AttandanceController : Controller
    {
        // GET: Attandance
        public ActionResult Index()
        {
            AttandanceHandler ah = new AttandanceHandler();
            List<Attandance> p = ah.GetAttandances();
            return View(p);
        }
        [HttpGet]
        public ActionResult MarkAttandance(int id, Member member)
        {
            AttandanceHandler aHandler = new AttandanceHandler();
            ViewBag.id = member.Id;
            ViewBag.OSList = ModelHelper.ToSelectItemList(aHandler.GetDDL());
            return View();
        }

        public ActionResult MarkAttandance(FormCollection data)
        {
            AttandanceHandler aHandler = new AttandanceHandler();
            Dbcontext db = new Dbcontext();
            try
            {
                if (ModelState.IsValid)
                {
                    Attandance attandance = new Attandance();

                    attandance.AttandanceDdl = new AttandanceDDL { Id = Convert.ToInt32(data["os"]) };
                    attandance.DateTime = Convert.ToDateTime(data["DateTime"]);

                    attandance.Member = new Member { Id = Convert.ToInt32(data["Id"]) };

                    db.Attandances.Add(attandance);
                    db.Entry(attandance.AttandanceDdl).State = EntityState.Unchanged;
                    db.Entry(attandance.Member).State = EntityState.Unchanged;
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            catch (Exception e)
            {
                ViewBag.OSList = ModelHelper.ToSelectItemList(aHandler.GetAttandances());
                Console.WriteLine(e);
                throw;

            }

            return RedirectToAction("Error");

        }
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult SearchStudent()
        {
            using (Dbcontext db = new Dbcontext())
            {
                var data = db.Members.Include(m => m.Gender).OrderBy(x => x.FullName).ToList();
                return View(data);
            }

        }

        public ActionResult DeleteAttandance(int id)
        {
            Dbcontext db = new Dbcontext();
            Attandance p = (from c in db.Attandances
                            where c.Id == id
                            select c).FirstOrDefault();
            db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();
            return Json("Delete", JsonRequestBehavior.AllowGet);
        }

    }
}
//List<Member> members = new List<Member>();
////List<Member> m = new MemberHandler().GetMembers();
//List<MemberViewModel> memberViewModels = new List<MemberViewModel>();
//foreach (Member member in members)
//{
//    MemberViewModel mvm = new MemberViewModel();
//    mvm.FullName = member.FullName;
//    mvm.DateofBirth = member.DateofBirth;
//    mvm.Fee = member.Fee;
//    mvm.MobileNo = member.MobileNo;
//    mvm.RollNo = member.RollNo;
//    memberViewModels.Add(mvm);
//}
//public ActionResult SearchData()
//{
//    using (Dbcontext db = new Dbcontext())
//    {
//        var data = db.Members.Include(m => m.Gender).OrderBy(x => x.FullName).ToList();
//        return Json(new { data = data }, JsonRequestBehavior.AllowGet);
//    }

//}
