using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProjectClasses;
using FinalProjectClasses.UserMgment;
using FinalYearProject.Models;

namespace FinalYearProject.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Login()

        {
            HttpCookie myCookie = Request.Cookies["logsec"];
            if (myCookie != null)
            {
                User user = new UserHandler().GetUser(myCookie.Values["logid"], myCookie.Values["psd"]);
                if (user != null)
                {
                    myCookie.Expires = DateTime.Now.AddDays(7);
                    Session.Add(WebUtils.Current_User, user);
                }
            }
            ViewBag.Controller = Request.QueryString["ctl"];
            ViewBag.Action = Request.QueryString["act"];
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            User u = new UserHandler().GetUser(model.Loginid, model.Password);
            if (u != null)
            {
                if (model.Rememberme)
                {
                    HttpCookie cookie = new HttpCookie("logsec")
                    { Expires = DateTime.Now.AddDays(7) };
                    cookie.Values.Add("logid", u.Loginid);
                    cookie.Values.Add("psd", u.Password);
                    Response.SetCookie(cookie);
                }
                Session.Add(WebUtils.Current_User, u);
                string ctl = Request.QueryString["c"];
                string act = Request.QueryString["a"];
                if (!string.IsNullOrEmpty(ctl) && string.IsNullOrEmpty(act))
                {
                    return RedirectToAction(ctl, act);
                }

                if (u.IsInRole(WebUtils.Admin))
                {
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Index", "Client");
            }
            else
            {
                ViewBag.Error = "Your LoginId and Password are Wrong..Please try Again!";
            }
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            ViewBag.GenderList = ModelHelper.ToSelectItemList(new UserHandler().GetGender());
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(FormCollection formdata)
        {
            Dbcontext db = new Dbcontext();
            User u = new User();
            if (ModelState.IsValid)
            {
                try
                {
                    u.Fullname = Convert.ToString(formdata["Fullname"]);
                    u.Email = Convert.ToString(formdata["Email"]);
                    u.Loginid = Convert.ToString(formdata["Loginid"]);
                    u.DateofBirth = Convert.ToDateTime(formdata["DateofBirth"]);
                    u.Password = Convert.ToString(formdata["Password"]);
                    u.ConfirmPassword = Convert.ToString(formdata["ConfirmPassword"]);
                    u.State = Convert.ToString(formdata["State"]);
                    u.MobileNo = Convert.ToInt64(formdata["MobileNo"]);
                    u.City = formdata["City"];
                    u.Cnic = Convert.ToInt64(formdata["Cnic"]);
                    u.Gender = new Gender { Id = Convert.ToInt32(formdata["gender.Name"]) };
                    u.Role = new Role() { Id = 2 };
                    u.Shift = formdata["Shift"];
                    u.FullAddress = formdata["FullAddress"];
                    int counter = 0;
                    long uno = DateTime.Now.Ticks;

                    foreach (string fileName in Request.Files)
                    {
                        HttpPostedFileBase file = Request.Files[fileName];
                        if (!string.IsNullOrEmpty(file.FileName))
                        {
                            string abc = uno + "_" + ++counter +
                                         file.FileName.Substring(file.FileName.LastIndexOf("."));

                            string url = "~/Content/Images/" + abc;
                            string path = Request.MapPath(url);
                            u.ImageUrl = abc;
                            file.SaveAs(path);

                        }
                    }

                    db.Users.Add(u);
                    db.Entry(u.Gender).State = EntityState.Unchanged;
                    db.SaveChanges();
                    return RedirectToAction("Login", "Users");
                }


                catch (Exception exception)
                {
                    throw exception;
                }
            }
            else
            {
                return null;
            }

        }

        public ActionResult Logout()
        {
            Session.Abandon();
            HttpCookie hc = Request.Cookies["logsec"];
            if (hc != null)
            {
                hc.Expires = DateTime.Now;
                Response.SetCookie(hc);
            }
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            User user = new UserHandler().GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateUser(User user)
        {

            return View();
        }
    }
}