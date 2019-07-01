namespace StormMVC.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using BusinessLogicLayer;
    using MyLogger;

    
    public class GamesController : Controller
    {
        [Models.MustBeInRole(Roles = "Administrator,PowerUser")]
        // GET: Games
        public ActionResult Index()
        {
            using (BLLContext ctx = new BLLContext())
            {
                List<GameBLL> items = ctx.GetAllGames();
                return View(items);
            }                
        }
        [Models.MustBeInRole(Roles = "Administrator,PowerUser")]
        // GET: Games/Details/5
        public ActionResult Details(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                GameBLL items = ctx.GetGame(id);
                return View(items);
            }
        }
        [Models.MustBeInRole(Roles = "Administrator")]
        // GET: Games/Create
        public ActionResult Create()
        {
            return View();           
        }
        [Models.MustBeInRole(Roles = "Administrator")]
        // POST: Games/Create
        [HttpPost]
        public ActionResult Create(GameBLL game)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.InsertGame(game.Game_Title, DateTime.Now, game.Purchase_Price);
                    return RedirectToAction("Index");
                }                    
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }
        [Models.MustBeInRole(Roles = "Administrator,PowerUser")]
        // GET: Games/Edit/5
        public ActionResult Edit(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                GameBLL game = ctx.GetGame(id);
                return View(game);
            }                              
        }
        [Models.MustBeInRole(Roles = "Administrator,PowerUser")]
        // POST: Games/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GameBLL game)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    game.GameID = id;
                    ctx.JustUpdateGame(game);
                    return RedirectToAction("Index");
                }                    
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }
        [Models.MustBeInRole(Roles = "Administrator")]
        // GET: Games/Delete/5
        public ActionResult Delete(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                GameBLL game = ctx.GetGame(id);
                return View(game);
            }
        }
        [Models.MustBeInRole(Roles = "Administrator")]
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
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }
    }
}
