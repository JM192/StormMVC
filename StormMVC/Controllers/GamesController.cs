using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using StormMVC.Models;

namespace StormMVC.Controllers
{
   [Models.MustBeInRole(Roles = "Administrator")]
    public class GamesController : Controller
    {
        // GET: Games
        public ActionResult Index()
        {
            using (BLLContext ctx = new BLLContext())
            {
                List<GameBLL> items = ctx.GetAllGames();
                return View(items);
            }                
        }

        // GET: Games/Details/5
        public ActionResult Details(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                GameBLL items = ctx.GetGame(id);
                return View(items);
            }
        }
        
        // GET: Games/Create
        public ActionResult Create()
        {
            return View();           
        }
        
        // POST: Games/Create
        [HttpPost]
        public ActionResult Create(GameBLL game)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.InsertGame(game.GameID, game.Game_Title, game.Release_Date, game.Purchase_Price);
                    return RedirectToAction("Index");
                }                    
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        
        // GET: Games/Edit/5
        public ActionResult Edit(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                GameBLL game = ctx.GetGame(id);
                return View(game);
            }
                              
        }
        
        // POST: Games/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GameBLL game)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.UpdateGame(game);
                    return RedirectToAction("Index");
                }                    
            }
            catch
            {
                return View();
            }
        }
        
        // GET: Games/Delete/5
        public ActionResult Delete(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                GameBLL game = ctx.GetGame(id);
                return View(game);
            }
        }
        
        // POST: Games/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.DeleteGame(id);
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
