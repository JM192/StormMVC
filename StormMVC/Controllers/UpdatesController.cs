using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using StormMVC.Models;

namespace StormMVC.Controllers
{
    
        
    public class UpdatesController : Controller
    {
        [Models.MustBeInRole(Roles = "Administrator,PowerUser")]
        // GET: Updates
        public ActionResult Index()
        {
            using (BLLContext ctx = new BLLContext())
            {
                List<UpdateBLL> items = ctx.GetAllUpdates();
                return View(items);
            }
        }
        [Models.MustBeInRole(Roles = "Administrator,PowerUser")]
        // GET: Updates/Details/5
        public ActionResult Details(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                UpdateBLL items = ctx.GetUpdate(id);
                return View(items);
            }                
        }
        [Models.MustBeInRole(Roles = "Administrator")]
        // GET: Updates/Create
        public ActionResult Create()
        {
            return View();
        }
        [Models.MustBeInRole(Roles = "Administrator")]
        // POST: Updates/Create
        [HttpPost]
        public ActionResult Create(UpdateBLL update)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.InsertUpdate(update.UpdateID, update.Patch, update.Expansion, update.Add_Ons, update.GameID);
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        [Models.MustBeInRole(Roles = "Administrator")]
        // GET: Updates/Edit/5
        public ActionResult Edit(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                UpdateBLL items = ctx.GetUpdate(id);
                return View(items);
            }
            
                              
        }
        [Models.MustBeInRole(Roles = "Administrator")]
        // POST: Updates/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UpdateBLL update)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.UpdateUpdate(update);
                    return RedirectToAction("index");
                }                    
            }
            catch
            {
                return View();
            }
        }
        [Models.MustBeInRole(Roles = "Administrator")]
        // GET: Updates/Delete/5
        public ActionResult Delete(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                UpdateBLL update = ctx.GetUpdate(id);
                return View(update);
            }            
        }
        [Models.MustBeInRole(Roles = "Administrator")]
        // POST: Updates/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.DeleteUpdate(id);
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
