using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProjectClasses;
using FinalProjectClasses.GymMngmnt;

namespace FinalYearProject.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            List<Payment> payments = new PaymentHandler().GetPaymentList();
            return View(payments);
        }
        [HttpGet]
        public ActionResult SubmitPayment(Member member)
        {
            ViewBag.id = member.Id;

            return View();
        }

        [HttpPost]
        public ActionResult SubmitPayment(FormCollection formdata)
        {
            Dbcontext db = new Dbcontext();
            Payment payment = new Payment();
            if (ModelState.IsValid)
            {
                payment.Name = formdata["Name"];
                payment.FeeDate = Convert.ToDateTime(formdata["FeeDate"]);
                payment.PaidAmount = Convert.ToInt32(formdata["PaidAmount"]);
                payment.Member = new Member { Id = Convert.ToInt32(formdata["Id"]) };
                payment.RollNo = Convert.ToInt32(formdata["RollNo"]);
                db.Payments.Add(payment);
                db.Entry(payment.Member).State = EntityState.Unchanged;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult UpdatePayment(int id)
        {
            Payment payment = new PaymentHandler().GetPaymentById(id);
            return View(payment);

        }
        [HttpPost]
        public ActionResult UpdatePayment(Payment payment)
        {
            Dbcontext db = new Dbcontext();
            using (db)
            {
                if (payment?.Id != null)
                {
                    db.Entry(payment).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult DeletePayment(int id)
        {

            Dbcontext db = new Dbcontext();
            using (db)
            {
                Payment payment = (from c in db.Payments
                                   where c.Id == id
                                   select c).FirstOrDefault();
                db.Entry(payment).State = EntityState.Deleted;
                db.SaveChanges();
            }

            return Json("Delete", JsonRequestBehavior.AllowGet);
        }
    }
}