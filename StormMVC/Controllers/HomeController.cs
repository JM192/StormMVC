namespace StormMVC.Controllers
{

    using System.Web.Mvc;
    using StormMVC.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "We are a game development company geared toward producing content that is both immersive and entertaining." +
                " Our goal is to design, develope and produce games that get players hooked and 'In the Zone' for" +
                " the entirety of the game";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us\n\n";
            
            ViewBag.Message = "Our Email: STtech@shadow.com";
            ViewBag.Message = "Our Phone Number: 912-654-6473";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            LoginModel m = new LoginModel();
            m.message = TempData["message"]?.ToString() ?? "";
            m.ReturnURL = TempData["ReturnURL"]?.ToString() ?? @"~/Home";
            m.Username = "genericuser";
            m.Password = "genericpassword";

            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel info)
        {
            using (BusinessLogicLayer.BLLContext ctx = new BusinessLogicLayer.BLLContext())
            {
                BusinessLogicLayer.UserBLL user = ctx.ReadSpecificUserByUsername(info.Username);
                if (user == null)
                {
                    info.message = $"The Username '{info.Username}' does not exist in the database";
                    return View(info);
                }
                //var role = ctx.GetRole(user.RoleID);

                string actual = user.Password;
                //string potential = ( user.Salt + info.Password);
                string potential = info.Password;
                //bool validateuser = System.Web.Helpers.Crypto.VerifyHashedPassword(actual, potential);
                bool validateuser = actual == potential;
                if (string.IsNullOrEmpty(info.ReturnURL)) { info.ReturnURL = @"~\Home"; }
                if (validateuser)
                {
                    Session["AUTHUsername"] = user.Username;
                    var role = ctx.GetRole(user.RoleID);
                    Session["AUTHRoles"] = role.Role;
                    return Redirect(info.ReturnURL);
                }
                info.message = "The password was incorrect";
                return View(info);
            }
        }
        //[HttpGet]
        //public ActionResult Register()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Register(string F_name, string L_name, string Address, string Ph_num, string Email, string Username, string Password)            
        //{
        //    return View("Index");
        //}
    }
}