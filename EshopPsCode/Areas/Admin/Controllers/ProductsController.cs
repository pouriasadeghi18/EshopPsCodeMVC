using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.IO;

using EShopPsCode;

namespace EshopPsCode.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private EshopPsCodeEntities db = new EshopPsCodeEntities();

        // GET: Admin/Products
        public ActionResult Index()
        {
            
            return View(db.Product.ToList());
        }

        

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.groups = db.Grouping.ToList();
            return View();
        }

        // POST: Admin/Products/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Title,ShortDiscraption,Text,Price,CreateTime,ImageName")] Product product,List<int> groupcheck , HttpPostedFileBase productimage , string tags)
        {
            if (groupcheck == null)
            {
                ViewBag.groups = db.Grouping.ToList();
                ViewBag.groupcheked = true;
                return View(product);
            }

            if (ModelState.IsValid)
            {
                product.ImageName = "NoPhoto.jpg";
                if (productimage != null && productimage.IsImage())
                {
                    product.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(productimage.FileName);
                    productimage.SaveAs(Server.MapPath("/Images/ProductImages/" + product.ImageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Images/ProductImages/" + product.ImageName), Server.MapPath("/Images/ProductImages/thumb/" + product.ImageName));
                }
              
                product.CreateTime = DateTime.Now;
                db.Product.Add(product);
                
                foreach (var item in groupcheck)
                {
                    db.Product_Selected_Groups.Add(new Product_Selected_Groups()
                    {
                        GroupID = item,
                        ProductID = product.ProductID
                    });

                }
                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tag = tags.Split(',');
                    foreach (var item in tag)
                    {
                        db.Product_Tags.Add(new Product_Tags()
                        {
                            Tag = item.Trim(),
                            ProductID = product.ProductID
                        });
                    }
                }
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.groups = db.Grouping.ToList();
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.SelectGroup = db.Product_Selected_Groups.ToList();
            ViewBag.groups = db.Grouping.ToList();
            ViewBag.tags = string.Join(",", db.Product_Tags.Where(i => i.ProductID == id).Select(t => t.Tag).ToList());
            return View(product);
        }

        // POST: Admin/Products/Edit/5
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Title,ShortDiscraption,Text,Price,CreateTime,ImageName")] Product product,List<int> groupcheck , HttpPostedFileBase productimage, string tags)
        {
            if (ModelState.IsValid)
            {
                if (productimage != null && productimage.IsImage())
                {
                    if(product.ImageName != "NoPhoto.ipg")
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/ProductImages/" + product.ImageName));
                        System.IO.File.Delete(Server.MapPath("/Images/ProductImages/thumb/" + product.ImageName));
                    }
                    product.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(productimage.FileName);
                    productimage.SaveAs(Server.MapPath("/Images/ProductImages/" + product.ImageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Images/ProductImages/" + product.ImageName), Server.MapPath("/Images/ProductImages/thumb/" + product.ImageName));
                }
                db.Entry(product).State = EntityState.Modified;
                db.Product_Tags.Where(t => t.ProductID == product.ProductID).ToList().ForEach(t => db.Product_Tags.Remove(t));
                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tag = tags.Split(',');
                    foreach (var item in tag)
                    {
                        db.Product_Tags.Add(new Product_Tags()
                        {
                            Tag = item.Trim(),
                            ProductID = product.ProductID
                        });
                    }
                }

                db.Product_Selected_Groups.Where(g => g.ProductID == product.ProductID).ToList().ForEach(t => db.Product_Selected_Groups.Remove(t));
                foreach (var item in groupcheck)
                {
                    db.Product_Selected_Groups.Add(new Product_Selected_Groups()
                    {
                        GroupID = item,
                        ProductID = product.ProductID
                    });

                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SelectGroup = groupcheck;
            ViewBag.groups = db.Grouping.ToList();
            ViewBag.tags = tags;
            return View(product);
        }

       

        // POST: Admin/Products/Delete/5
      
        public void Delete(int id)
        {
            Product product = db.Product.Find(id);
            db.Product_Selected_Groups.Where(g => g.ProductID == id).ToList().ForEach(i => db.Product_Selected_Groups.Remove(i));
            db.Product_Tags.Where(t => t.ProductID == id).ToList().ForEach(i => db.Product_Tags.Remove(i));
            
            if(product.ImageName != "NoPhoto.jpg")
            {
                System.IO.File.Delete(Server.MapPath("/Images/ProductImages/" + product.ImageName));
                System.IO.File.Delete(Server.MapPath("/Images/ProductImages/thumb/" + product.ImageName));
            }
            db.Product.Remove(product);
            db.SaveChanges();
            
        }

        public ActionResult ProductGallery(int id)
        {
            ViewBag.gallery = db.Product_Gallery.Where(i => i.ProductID == id).ToList();
            return View( new Product_Gallery()
            {
                ProductID = id
            });
        }

        public ActionResult table(int id)
        {
            ViewBag.gallery = db.Product_Gallery.Where(i => i.ProductID == id).ToList();
            return PartialView();
        }

        [HttpPost]
         [ValidateAntiForgeryToken]
        public ActionResult ProductGallery(Product_Gallery gallery , HttpPostedFileBase ImgUp)
        {
            if (ModelState.IsValid)
            {
                if(ImgUp != null && ImgUp.IsImage())
                {
                    gallery.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUp.FileName);
                    ImgUp.SaveAs(Server.MapPath("/Images/ProductImages/" + gallery.ImageName));
                    ImageResizer resize = new ImageResizer();
                    resize.Resize(Server.MapPath("/Images/ProductImages/" + gallery.ImageName), Server.MapPath("/Images/ProductImages/thumb/" + gallery.ImageName));
                 
                }
                db.Product_Gallery.Add(gallery);
                db.SaveChanges();
            }
                return RedirectToAction("table", new {id = gallery.ProductID});
        }
        public void DeleteGallerry(int id )
        {
            var gallery = db.Product_Gallery.Find(id);
            db.Product_Gallery.Where(i => i.GalleryId == id).ToList().ForEach(i => db.Product_Gallery.Remove(i));
            System.IO.File.Delete(Server.MapPath("/Images/ProductImages/" + gallery.ImageName));
            System.IO.File.Delete(Server.MapPath("/Images/ProductImages/thumb/" + gallery.ImageName));
            db.SaveChanges();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
