using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using StormMVC.Models;

namespace StormMVC.Controllers
{
    [Models.MustBeInRole(Roles ="Administrator")]
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            using (BLLContext ctx = new BLLContext())
            {
                List<RoleBLL> items = ctx.GetAllRoles();
                return View(items);
            }                
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                RoleBLL items = ctx.GetRole(id);
                return View(items);
            }                
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(RoleBLL role)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.InsertRole(role.RoleID, role.Name, role.Role_Type, role.Privilege);
                    return RedirectToAction("Index");
                }                    
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                RoleBLL role = ctx.GetRole(id);
                return View(role);
            }            
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RoleBLL role)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.UpdateRole(role);
                    return RedirectToAction("Index");
                }                    
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                RoleBLL items = ctx.GetRole(id);
                return View(items);
            }
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.DeleteRole(id);
                    return RedirectToAction("Index");
                }                    
            }
            catch
            {
                return View();
            }
        }
    }
}
