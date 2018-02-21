using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class AccountController : Controller
    {
        private VisitorLogContext vl = new VisitorLogContext();
        // GET: Account
        public ActionResult Index()
        {
            return View(vl.Activities);
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
           

            // search users by password
            var userpasswords = vl.Users.Where(u => u.Password == user.Password);

            if (userpasswords!=null)
            {
                Activity activity = new Activity();
                activity.ActivityName = "LoggedIn";
                activity.ActivityDate = DateTime.Now;
                activity.IpAddress = Request.UserHostAddress;
                vl.Activities.Add(activity);
                vl.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            else
                return View("Login");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            return RedirectToAction("PasswordGenerator");
        }

        [HttpGet]
        public ActionResult PasswordGenerator()
        {    
          
            return View();
        }

 


 /**
  * Store temporary user in Session during account creation
  */
        private User GetTempUser()
        {
            if (Session["tempUser"] == null)
            {
                Session["tempUser"] = new User();
            }
            return (User)Session["tempUser"];
        }

        private void FlushTempUser()
        {
            Session.Remove("tempUser");
        }


    }
}