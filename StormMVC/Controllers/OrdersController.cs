namespace StormMVC.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using BusinessLogicLayer;
    using MyLogger;

    public class OrdersController : Controller
    {
        [Models.MustBeInRole(Roles = "Administrator,PowerUser")]
        // GET: Orders
        public ActionResult Index()
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    List<OrderBLL> items = ctx.GetAllOrders();
                    return View(items);
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }
        [Models.MustBeInRole(Roles = "Administrator,PowerUser")]
        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    OrderBLL items = ctx.GetOrder(id);
                    return View(items);
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }
        [Models.MustBeInRole(Roles = "Administrator")]
        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }
        [Models.MustBeInRole(Roles = "Administrator")]
        // POST: Orders/Create
        [HttpPost]
        public ActionResult Create(OrderBLL order)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.InsertOrder(order.Order_Name, DateTime.Now, order.UserID, order.GameID);
                    return RedirectToAction("Index");
                }                    
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }
        [Models.MustBeInRole(Roles = "Administrator")]
        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    OrderBLL order = ctx.GetOrder(id);
                    return View(order);
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }                     
        }
        [Models.MustBeInRole(Roles = "Administrator")]
        // POST: Orders/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OrderBLL order)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    order.Order_Num = id;
                    ctx.JustUpdateOrder(order);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }
        [Models.MustBeInRole(Roles = "Administrator")]
        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    OrderBLL order = ctx.GetOrder(id);
                    return View(order);
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }
        [Models.MustBeInRole(Roles = "Administrator")]
        // POST: Orders/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.DeleteOrder(id);
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
