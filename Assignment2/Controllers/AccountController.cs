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
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            // need to verify if session username and password match the database

            //if yes then redirect to the Home View Index View
            return RedirectToAction("Home", "Index");

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