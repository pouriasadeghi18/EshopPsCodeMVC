using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EshopPsCode.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
       
        public ActionResult Index()
        {
            return View();
        }

        [Route("AboutUs")]
        public ActionResult About()
        {
            return View();
        }

        [Route("ContactUs")]
        public ActionResult Contact()
        {
            return View();
        }
    }

}