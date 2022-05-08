using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.Web.Security;
namespace EshopPsCode.Areas.UserAccount.Controllers
{
    public class AccountController : Controller
    {
        EshopPsCodeEntities db = new EshopPsCodeEntities();
        // GET: UserAccount/Account

        
        public ActionResult ChangePassword()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePassWordViewModel change)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Single(u => u.UserName == User.Identity.Name);
                string hashpassword = FormsAuthentication.HashPasswordForStoringInConfigFile(change.OldPassword, "MD5");
                if (user.Password == hashpassword)
                {
                    user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(change.Password, "MD5");
                    db.SaveChanges();
                    ViewBag.change = true;

                }
                else
                {
                    ModelState.AddModelError("OldPassword", "رمز قبلی شما درست نمی باشد");
                }
            }
            return View();
        }
    }
}