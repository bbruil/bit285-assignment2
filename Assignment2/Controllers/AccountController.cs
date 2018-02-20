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

        //[HttpPost]
        //public ActionResult Login(User user)
        //{   

        //    int id = Convert.ToInt32(Session["UserId"]);
        //    User currentuser = vl.Users.Single(u => u.UserID == id);

        //    vl.Users.Add(user);

        //    if (currentuser.Password == user.Password)
        //    {
        //        return View();
        //    } else
        //    return View();
        //}

        [HttpPost]
        public ActionResult Login(Activity activity)
        {
            
            activity.IpAddress = Request.UserHostAddress;
            activity.ActivityDate = DateTime.Now;
            vl.Activities.Add(activity);
            vl.SaveChanges();
            //need to verify if session username and password match the database
            //if (Session["password"] == activity. && Session["UserName"] == user.UserName)

            //if yes then redirect to the Home View Index View
            return RedirectToAction("Index", "Home");

            //if not successful then display error Redirect to Action Create

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

        [HttpPost]
        public ActionResult PasswordGenerator()
        {   
            return RedirectToAction("Login");
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