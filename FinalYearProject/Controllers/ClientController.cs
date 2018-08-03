using FinalProjectClasses.GymMngmnt;
using FinalProjectClasses.UserMgment;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FinalYearProject.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            User u = (User)Session[WebUtils.Current_User];
            if (u != null)
            {
                if (u.IsInRole(WebUtils.Admin))
                {
                    RedirectToAction("Index", "Admin");
                }
            }

            return View();
        }

        public ActionResult PaymentDetails()
        {
            List<Payment> payments = new PaymentHandler().GetPaymentList();
            return View(payments);
        }

        public ActionResult AttandanceDetails()
        {
            List<Attandance> attandances = new AttandanceHandler().GetAttandances();
            return View(attandances);
        }

    }
}
