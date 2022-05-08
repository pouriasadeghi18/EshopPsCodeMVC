using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataLayer;
using EShopPsCode;

namespace EshopPsCode.Controllers
{
    public class AccountController : Controller
    {
        EshopPsCodeEntities Db = new EshopPsCodeEntities();

        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [Route("Register")]
        [ValidateAntiForgeryToken]

        public ActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                if (!Db.Users.Any(u => u.Email == register.Email.Trim().ToLower()))
                {
                    Users user = new Users();
                    user.Email = register.Email;
                    user.UserName = register.UserName;
                    user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(register.Password, "MD5");
                    user.RoleID = 1;
                    user.ActiveCode = Guid.NewGuid().ToString();
                    user.IsActive = false;
                    user.RegisterDate = DateTime.Now;

                    Db.Users.Add(user);
                    Db.SaveChanges();
                    string body = PartialToStringClass.RenderPartialView("ManageEmail", "ActivationEmail", user);
                    SendEmail.Send(user.Email, "ایمیل فعال سازی", body);
                    return View("SuccessRegister", user);
                }
                else
                {
                    ModelState.AddModelError("Email", "کاربری قبلا با ایمیل  " + register.Email + "   ثبت نام شده");
                }
            }
            return View(register);
        }

        public ActionResult ActivationEmail(string id)
        {
            var user = Db.Users.SingleOrDefault(a => a.ActiveCode == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            user.IsActive = true;
            user.ActiveCode = Guid.NewGuid().ToString();
            ViewBag.Name = user.UserName;
            Db.SaveChanges();
            return View();

        }


        [Route("Login")]


        public ActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login, string returnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                string password = FormsAuthentication.HashPasswordForStoringInConfigFile(login.Password, "MD5");
                var user = Db.Users.SingleOrDefault(u => u.Email == login.Email && u.Password == password);

                if (user != null)
                {
                    if (user.IsActive)
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, login.RememberMe);
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "حساب کاربری شما فعال نشده است");
                    }

                }
                else
                {
                    ModelState.AddModelError("Email", "حساب کاربری با این مشخصات یافت نشد");
                }
            }
            return View(login);
        }


        [Route("Signout")]
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        [Route("ForGetPassword")]
        public ActionResult ForGetPassword()
        {
            return View();
        }
        [Route("ForGetPassword")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForGetPassword(ForGetPassWordViewModel F)
        {
            var user = Db.Users.SingleOrDefault(e => e.Email == F.Email);
            if (ModelState.IsValid)
            {

                if (user != null)
                {
                    if (user.IsActive)
                    {
                        string body = PartialToStringClass.RenderPartialView("ManageEmail", "ForgetPassword", user);
                        SendEmail.Send(F.Email, "بازیابی کلمه عبور", body);
                        return View("SuccessSendEmailForgetPassword",user);
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "کاربر فعال نشده است");
                    }

                }
                else
                {
                    ModelState.AddModelError("Email", "کاربری با این ایمیل یافت نشد");
                }
            }



            return View(user);
        }

        [Route("RecoveryPassword/{id}")]
        public ActionResult RecoveryPassword(string id)
        {
            var user = Db.Users.SingleOrDefault(u => u.ActiveCode == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View();
        }
        [Route("RecoveryPassword/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult RecoveryPassword( string id,RecoveryPassword recovery )
        {
            if (ModelState.IsValid)
            {
                var User = Db.Users.SingleOrDefault(u => u.ActiveCode == id);
                if (User == null)
                {
                    return HttpNotFound();
                }

                User.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(recovery.Password, "MD5");
                User.ActiveCode = Guid.NewGuid().ToString();
                Db.SaveChanges();
                return Redirect("/Login?recovery=true");
            }
            return View();
           
            
        }
    }
}