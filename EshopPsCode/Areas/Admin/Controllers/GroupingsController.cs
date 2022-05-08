using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace EshopPsCode.Areas.Admin.Controllers
{
    public class GroupingsController : Controller
    {
        private EshopPsCodeEntities db = new EshopPsCodeEntities();

        // GET: Admin/Groupings
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult ListGroups()
        {
            var grouping = db.Grouping.Where(g => g.Subgroup == null);
            return PartialView(grouping.ToList());
        }

        // GET: Admin/Groupings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grouping grouping = db.Grouping.Find(id);
            if (grouping == null)
            {
                return HttpNotFound();
            }
            return View(grouping);
        }

        // GET: Admin/Groupings/Create
        public ActionResult Create(int? id)
        {
          
            return PartialView(new Grouping()
            {
                Subgroup = id
            });
        }

        // POST: Admin/Groupings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupingID,GroupingName,Subgroup")] Grouping grouping)
        {
            if (ModelState.IsValid)
            {
                db.Grouping.Add(grouping);
                db.SaveChanges();
                return PartialView("ListGroups" , db.Grouping.Where(g => g.Subgroup == null));
            }

            ViewBag.Subgroup = new SelectList(db.Grouping, "GroupingID", "GroupingName", grouping.Subgroup);
            return View(grouping);
        }

        // GET: Admin/Groupings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grouping grouping = db.Grouping.Find(id);
            if (grouping == null)
            {
                return HttpNotFound();
            }
            ViewBag.Subgroup = new SelectList(db.Grouping, "GroupingID", "GroupingName", grouping.Subgroup);
            return PartialView(grouping);
        }

        // POST: Admin/Groupings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupingID,GroupingName,Subgroup")] Grouping grouping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grouping).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("ListGroups" , db.Grouping.Where(g => g.Subgroup == null));
            }
            ViewBag.Subgroup = new SelectList(db.Grouping, "GroupingID", "GroupingName", grouping.Subgroup);
            return View(grouping);
        }

        // GET: Admin/Groupings/Delete/5
        public void Delete(int id)
        {
            var Group = db.Grouping.Find(id);
            if(Group.Grouping1.Any())
            {
                foreach (var item in db.Grouping.Where(g => g.Subgroup == id))
                {
                    db.Grouping.Remove(item);
                }
            }
            db.Grouping.Remove(Group);
            db.SaveChanges();
        }

        // POST: Admin/Groupings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grouping grouping = db.Grouping.Find(id);
            db.Grouping.Remove(grouping);
            db.SaveChanges();
            return PartialView("ListGroups", db.Grouping.Where(g => g.Subgroup == null));
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
