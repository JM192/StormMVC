namespace StormMVC.Controllers
{

    using System;
    using System.Web.Mvc;
    using BusinessLogicLayer;
    using MyLogger;
    using StormMVC.Models;
    [MustBeInRole(Roles="Administrator,PowerUser")]
    public class CascadingDeleteController : Controller
    {
        // GET: CascadingDelete/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CascadingDelete/Delete/5
        [HttpPost]
        public ActionResult Delete(Models.CascadingDeleteViewModel cascade)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.DeleteUser(cascade.UserID);
                    ctx.DeleteOrder(cascade.Order_Num);
                    return RedirectToAction("~/Home");
                }                
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }
    }
}
