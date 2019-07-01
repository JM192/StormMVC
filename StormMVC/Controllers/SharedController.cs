namespace StormMVC.Controllers
{

    using System.Web.Mvc;
    using BusinessLogicLayer;
    using MyLogger;

    public class SharedController : Controller
    {
        [HttpGet]
        public ActionResult Unauthorized()
        {
            return View();
        }
        public ActionResult Unauthorized(Models.LoginModel m)
        {
            try
            {
                using (BusinessLogicLayer.BLLContext ctx = new BusinessLogicLayer.BLLContext())
                {
                    var user = ctx.ReadSpecificUserByUsername(m.Username);
                    if (user == null)
                    {
                        m.message = "Not a valid username";
                        return View(m);
                    }
                    string actual = user.Password;
                    string potential = m.Password;
                    bool checkedout = actual == potential;
                    if (checkedout)
                    {
                        RoleBLL role = new RoleBLL();
                        Session["AUTHUsername"] = m.Username;
                        Session["AUTHRoles"] = role.Role;
                        if (string.IsNullOrEmpty(m.ReturnURL))
                        {
                            m.ReturnURL = @"~\Home";
                        }
                        return Redirect(m.ReturnURL);
                    }
                    m.message = $"Password was not correct";
                    return View(m);
                }
            }
            catch (System.Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }
    }
}
