namespace StormMVC.Controllers
{
    using System;
    using System.Web.Mvc;
    using BusinessLogicLayer;
    using MyLogger;
    using DataAccessLayer;

    public class AccountController : Controller
    {
        public ActionResult Logout()
        {
            Session.Remove("AUTHUsername");
            Session.Remove("AUTHRoles");
            return Redirect("~/Home");
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
        public ActionResult Edit()
        {
            using (BLLContext ctx = new BLLContext())
            {
                string userName = User.Identity.Name;
                var u = ctx.ReadSpecificUserByUsername(userName);
                return View(u);
            }                
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(string Username, UserBLL user)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    user.Username = Username;
                    ctx.JustUpdateUser(user);
                    return RedirectToAction("Index");
                }                 
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }
    }
}
