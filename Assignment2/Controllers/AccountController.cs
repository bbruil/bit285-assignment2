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
            return View(vl.Activities);
        }

        [HttpPost]
        public ActionResult Login(Activity activity)
        {
            activity.IpAddress = Request.UserHostAddress;
            vl.Activities.Add(activity);
            vl.SaveChanges();
            // need to verify if session username and password match the database
            //if(Session["password"]==user.Password && Session["UserName"]==user.UserName)

            //if yes then redirect to the Home View Index View
            return RedirectToAction("Home");

            //if not successful then display error Redirect to Action Create

        }

        [HttpPost]
        public ActionResult Create(User user)
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