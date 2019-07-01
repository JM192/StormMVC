namespace StormMVC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using BusinessLogicLayer;
    using MyLogger;

    [Models.MustBeInRole(Roles = "Administrator")]
    public class UsersController : Controller
    {
        // GET: Users/Index
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    List<UserBLL> items = ctx.GetAllUsers();
                    return View(items);
                }   
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }        
        }
        // GET: Users/Details
        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    UserBLL items = ctx.GetUser(id);
                    return View(items);
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }                          
        }
        // GET: Users/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(UserBLL user)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.InsertUser(user.Name, user.Email, user.Username, user.Password, 
                                   user.News_sub, 1, "", "");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }

        // GET: Users/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    UserBLL user = ctx.GetUser(id);
                    return View(user);
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);                
            }
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserBLL user)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    user.UserID = id;
                    ctx.JustUpdateUser(user);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }

        // GET: Users/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    UserBLL user = ctx.GetUser(id);
                    return View(user);
                }
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }             
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.DeleteUser(id);
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
