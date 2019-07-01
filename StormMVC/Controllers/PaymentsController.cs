using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using MyLogger;
using StormMVC.Models;

namespace StormMVC.Controllers
{
    [MustBeInRole(Roles ="Administrator")]
    public class PaymentsController : Controller
    {

        // GET: Payments
        public ActionResult Index()
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    List<PaymentBLL> items = ctx.GetAllPayments();
                    return View(items);
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }         
        }

        // GET: Payments/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    PaymentBLL items = ctx.GetPayment(id);
                    return View(items);
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }              
        }

        // GET: Payments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Payments/Create
        [HttpPost]
        public ActionResult Create(PaymentBLL payment)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.InsertPayment(payment.UserID, payment.Name, payment.Address, payment.Ph_num,
                                      payment.Card_num, payment.Security_code);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }

        // GET: Payments/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    PaymentBLL payment = ctx.GetPayment(id);
                    return View(payment);
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }                
        }
        // POST: Payments/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PaymentBLL payment)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    payment.PaymentID = id;
                    ctx.JustUpdatePayment(payment);
                    return RedirectToAction("Index");
                }                    
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    PaymentBLL payment = ctx.GetPayment(id);
                    return View(payment);
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }                
        }

        // POST: Payments/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.DeletePayment(id);
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
