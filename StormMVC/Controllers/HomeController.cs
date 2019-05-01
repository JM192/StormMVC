using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using DataAccessLayer;
using StormMVC.Models;

namespace StormMVC.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "We are a game development company geared toward producing content that is immersive and entertaining.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";
            ViewBag.Message = "Our Email: STtech@shadow.com";
            ViewBag.Message = "Our Phone Number: 912-654-6473";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel info)
        {
            using (BusinessLogicLayer.BLLContext ctx = new BusinessLogicLayer.BLLContext())
            {
                BusinessLogicLayer.UserBLL user = ctx.ReadSpecificUserByUsername(info.Username);
                if (user == null)
                {
                    info.message = $"The Username '{info.Username}' does not exist in the database";
                    return View(info);
                }
                var role = ctx.GetRole(user.RoleID);

                string actual = user.Password;
                string potential = info.Password;
                bool validateuser = actual == potential;
                if (string.IsNullOrEmpty(info.ReturnURL)) { info.ReturnURL = @"~\home"; }
                if (validateuser)
                {
                    Session["AUTHUsername"] = user.Username;
                    Session["AUTHRoles"] = role.Role_Type;
                    return Redirect(info.ReturnURL);
                }
                info.message = "The password was incorrect";
                return View(info);
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string F_name, string L_name, string Address, string Ph_num, string Email, string Username, string Password)            
        {
            return View("Index");
        }
    }
}