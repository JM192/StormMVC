using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;

namespace StormMVC.Controllers
{   
    public class AccountController : Controller
    {
        public ActionResult Logout()
        {
            Session.Remove("AUTHUsername");
            Session.Remove("AUTHRoles");
            return Redirect("~/home");
        }
        // GET: Account
        public ActionResult Index()
        {
            using (BLLContext ctx = new BLLContext())
            {
                if (!User.Identity.IsAuthenticated) { return View("Sorry"); }
                string username = User.Identity.Name; 
                var item = ctx.ReadSpecificUserByUsername(username);
                return View(item);
            }                
        }

        // GET: Account/Details/5
        public ActionResult Details(string username)
        {
            using (BLLContext ctx = new BLLContext())
            {
                var item = ctx.ReadSpecificUserByUsername(username);
                return View(item);
            }                
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                var u =ctx.GetUser(id);
               // Models.LoginModel l = new Models.LoginModel();
                return View(u);
            }                
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserBLL user)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {                    
                    ctx.UpdateUser(user);
                    return RedirectToAction("index");
                }                 
            }
            catch
            {
                return View();
            }
        }
    }
}
