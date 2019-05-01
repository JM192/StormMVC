using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using StormMVC.Models;

namespace StormMVC.Controllers
{
        
    public class OrdersController : Controller
    {
        [Models.MustBeInRole(Roles = "Administrator,PowerUser")]
        // GET: Orders
        public ActionResult Index()
        {
            using (BLLContext ctx = new BLLContext())
            {
                List<OrderBLL> items = ctx.GetAllOrders();
                return View(items);
            }
        }
        [Models.MustBeInRole(Roles = "Administrator,PowerUser")]
        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                OrderBLL items = ctx.GetOrder(id);
                return View(items);
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
                    ctx.InsertOrder(order.Order_Num, order.Order_Name, order.Purchase_Date, order.UserID, order.GameID);
                    return RedirectToAction("index");
                }                    
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        [Models.MustBeInRole(Roles = "Administrator")]
        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                OrderBLL order = ctx.GetOrder(id);
                return View(order);

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
                    ctx.UpdateOrder(order);
                    return RedirectToAction("index");
                }
            }
            catch
            {
                return View();
            }
        }
        [Models.MustBeInRole(Roles = "Administrator")]
        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                OrderBLL order = ctx.GetOrder(id);
                return View(order);
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
