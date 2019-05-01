using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;

namespace StormMVC.Controllers
{
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
            catch (Exception ex)
            {
                return View("ERROR", ex);
            }
        }
    }
}
