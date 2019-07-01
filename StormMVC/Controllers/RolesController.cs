namespace StormMVC.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using BusinessLogicLayer;
    using MyLogger;

    [Models.MustBeInRole(Roles ="Administrator")]
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    List<RoleBLL> items = ctx.GetAllRoles();
                    return View(items);
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }              
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    RoleBLL items = ctx.GetRole(id);
                    return View(items);
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }           
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(string Role, string Privileges)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.InsertRole(Role, Privileges);
                    return RedirectToAction("Index");
                }                    
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    RoleBLL role = ctx.GetRole(id);
                    return View(role);
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }          
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RoleBLL r)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    r.RoleID = id;
                    ctx.JustUpdateRole(r);
                    return RedirectToAction("Index");
                }                    
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    RoleBLL items = ctx.GetRole(id);
                    return View(items);
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
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
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }
    }
}
