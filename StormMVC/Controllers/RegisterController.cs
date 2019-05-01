using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;

namespace StormMVC.Controllers
{
    public class RegisterController : Controller
    {

        string InvalidUser(BLLContext ctx, UserBLL user)
        {
            UserBLL test = ctx.ReadSpecificUserByUsername(user.Username);
            if (test != null)
            {
                return $"A user with the username {user.Username} already exists.";
            }
            return null;
        }        

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        // Post: Register
        [HttpPost]
        public ActionResult Index(UserBLL data)
        {
            using (BLLContext ctx = new BLLContext())
            {
                string message =  InvalidUser(ctx, data);
                bool empty = string.IsNullOrEmpty(message);
                if (!empty)
                {
                    ViewData["message"] = message;
                    return View("InvalidUser");
                }

                string salt = System.Web.Helpers.Crypto.GenerateSalt(20);
                

                string hashedpassword = System.Web.Helpers.Crypto.HashPassword(salt + data.Password);

                RoleBLL role = new RoleBLL();
                data.Password = hashedpassword;                
                role.Role_Type = "Regular User";
                data.News_sub = "Yes";
                ctx.InsertUser(data);
            }
            return View();
        }

        // GET: Register/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Register/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Register/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Register/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Register/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Register/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
