namespace StormMVC.Controllers
{
    using System;
    using System.Web.Mvc;
    using BusinessLogicLayer;
    using MyLogger;

    public class TwoLevelsController : Controller
    {

        string InvalidUser(BLLContext ctx, UserBLL user)
        {
            UserBLL test = ctx.ReadSpecificUserByUsername(user.Email);
            if (test != null)
            {
                return $"A user with the entered information {user.Username} already exists";
            }
            return null;
        }

        // GET: TwoLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TwoLevels/Create
        [HttpPost]
        public ActionResult Create(Models.TwoLevelsViewModel two)            
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    

                    string salt = System.Web.Helpers.Crypto.GenerateSalt(10);
                    //string VerifyPhrase = System.Web.Helpers.Crypto.GenerateSalt(100);
                    string hashedpass = System.Web.Helpers.Crypto.HashPassword(salt + two.Password);

                    two.Salt = salt;
                    two.Hash = hashedpass;
                    int newUserID = ctx.InsertUser(two.Name, two.Email, two.Username, two.Password, 
                                                two.News_sub, 1, two.Salt, two.Hash);

                    ctx.InsertPayment(newUserID, two.Name, two.Address, two.Ph_num, two.Card_num,                          two.Security_code);
                    return Redirect("~/Home");
                }                    
            }
            catch (Exception ex) when (Logger.Log(ex))
            {
                return View("Error", ex);
            }
        }        
    }
}
