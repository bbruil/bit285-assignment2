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
            //find current user by id
            
            //int id = Convert.ToInt32(user.UserID);
            //var currentuser = vl.Users.Single(u => u.UserID == id);

            // search users by password
            var userpasswords = vl.Users.Where(u => u.Password == user.Password);

            if (user.Password!=null)
            {   
                //create a new activity in the log
                Activity activity = new Activity();
                activity.ActivityName = "LoggedIn";
                activity.ActivityDate = DateTime.Now;
                activity.IpAddress = Request.UserHostAddress;
                //update the database
                vl.Activities.Add(activity);
                vl.SaveChanges();
                //show the visitor log
                return RedirectToAction("Index", "Home");
            }

            else 
                return View();
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