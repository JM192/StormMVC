using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;

namespace StormMVC.Controllers
{
    public class TwoLevelsController : Controller
    {
        // GET: TwoLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TwoLevels/Create
        [HttpPost]
        public ActionResult Create(Models.TwoLevelsViewModel two)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    int UserID = ctx.InsertUser(two.UserID, two.F_name, two.L_name, two.Address, two.Ph_num, two.Email,
                        two.Username, two.Password, two.News_sub, two.RoleID);
                    ctx.InsertOrder(two.Order_Num, two.Order_Name, two.Purchase_Date, two.UserID, two.GameID);
                    return RedirectToAction("~/Home");
                }                    
            }
            catch (Exception ex)
            {
                return View("ERROR",ex);
            }
        }        
    }
}
