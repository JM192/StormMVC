using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLogicLayer;
using StormMVC.Models;

namespace StormMVC.Controllers
{
    [Models.MustBeInRole(Roles = "Administrator")]
    public class UsersController : Controller
    {
        // GET: Users/Index
        [HttpGet]
        public ActionResult Index()
        {
            using (BLLContext ctx = new BLLContext())
            {
                List<UserBLL> items = ctx.GetAllUsers();
                return View(items);
            }                
        }
        // GET: Users/Details
        [HttpGet]
        public ActionResult Details(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                UserBLL items = ctx.GetUser(id);
                return View(items);
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
                    ctx.InsertUser(user.UserID, user.F_name, user.L_name, user.Address,
                        user.Ph_num, user.Email, user.Username, user.Password, user.News_sub, user.RoleID);
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        // GET: Users/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                UserBLL user = ctx.GetUser(id);
                return View(user);
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
                    ctx.UpdateUser(user);
                    return RedirectToAction("index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                UserBLL user = ctx.GetUser(id);
                return View(user);
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
