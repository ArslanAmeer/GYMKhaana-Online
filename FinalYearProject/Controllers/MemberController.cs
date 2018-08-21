using FinalProjectClasses;
using FinalProjectClasses.GymMngmnt;
using FinalProjectClasses.UserMgment;
using FinalYearProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalYearProject.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            List<Member> m = new MemberHandler().GetMembers();

            return View(m);
        }
        [HttpGet]
        public ActionResult AddMember()
        {
            ViewBag.GenderList = ModelHelper.ToSelectItemList(new UserHandler().GetGender());
            ViewBag.Instructors = ModelHelper.ToSelectItemList(new PaymentHandler().GeInstructerList());
            return View();
        }

        [HttpPost]
        public ActionResult AddMember(FormCollection formdata)
        {
            Dbcontext dbcontext = new Dbcontext();
            Member member = new Member();
            if (ModelState.IsValid)
            {
                try
                {
                    member.FullName = formdata["FullName"];
                    member.CNIC = Convert.ToInt64(formdata["CNIC"]);
                    member.MobileNo = Convert.ToInt64(formdata["MobileNo"]);
                    member.Gender = new Gender { Id = Convert.ToInt32(formdata["Gender.Name"]) };
                    member.Instructer = new Instructer { Id = Convert.ToInt32(formdata["instructor"]) };
                    member.FullAddress = formdata["FullAddress"];
                    member.DateofBirth = Convert.ToDateTime(formdata["DateofBirth"]);
                    member.CurrentDate = Convert.ToDateTime(formdata["CurrentDate"]);
                    member.Fee = Convert.ToInt32(formdata["Fee"]);
                    member.SubmissionDate = Convert.ToDateTime(formdata["SubmissionDate"]);
                    member.SubmitTo = formdata["SubmitTo"];
                    member.RollNo = Convert.ToInt32(formdata["RollNo"]);
                    int counter = 0;
                    long uno = DateTime.Now.Ticks;

                    foreach (string fileName in Request.Files)
                    {
                        HttpPostedFileBase file = Request.Files[fileName];
                        if (!string.IsNullOrEmpty(file.FileName))
                        {
                            string abc = uno + "_" + ++counter +
                                         file.FileName.Substring(file.FileName.LastIndexOf("."));

                            string url = "~/Content/MemberPics/" + abc;
                            string path = Request.MapPath(url);
                            member.ImageUrl = abc;
                            file.SaveAs(path);
                        }
                    }
                    dbcontext.Members.Add(member);
                    dbcontext.Entry(member.Gender).State = EntityState.Unchanged;
                    dbcontext.Entry(member.Instructer).State = EntityState.Unchanged;
                    dbcontext.SaveChanges();
                    return RedirectToAction("Message");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult UpdateMember(int id)
        {
            Member member = new MemberHandler().GetMemberById(id);
            return View(member);
        }
        [HttpPost]
        public ActionResult UpdateMember(Member member)
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                if (member?.Id != null)
                {
                    db.Entry(member).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View();
            }
        }
        public ActionResult DeleteMember(int id)
        {
            Dbcontext db = new Dbcontext();
            Member member = (from c in db.Members
                    .Include(x => x.Gender)
                             where c.Id == id
                             select c).FirstOrDefault();
            db.Entry(member).State = EntityState.Deleted;
            db.SaveChanges();
            return Json("Delete", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Message()
        {
            return View();
        }

        public ActionResult MemberAttendanceDetail(int rollNo)
        {
            List<Attandance> attandance = new MemberHandler().GetAttandancebyRollNo(rollNo);
            return View(attandance);
        }


    }
}
