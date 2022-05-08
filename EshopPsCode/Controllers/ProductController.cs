using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
namespace EshopPsCode.Controllers
{
    public class ProductController : Controller
    {
        EshopPsCodeEntities Db = new EshopPsCodeEntities();
        // GET: Product
        public ActionResult ShowGroups()
        {
            return PartialView(Db.Grouping.ToList());
        }
    }
}