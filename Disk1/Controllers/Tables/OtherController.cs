using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Disk1.Models.bd;

namespace Disk1.Controllers.Tables
{
    [Authorize]
    public class OtherController : Controller
    {
        private Disk db = new Disk();

        // GET: Other
        public async Task<ActionResult> Index()
        {
            return View(await db.Other.ToListAsync());
        }


        #region Create

        // GET: Other/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Other/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,string1,string2,string3,string4,string5,string6")] Other other)
        {
            if (ModelState.IsValid)
            {
                db.Other.Add(other);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(other);
        }

        #endregion

        #region Edit
        
        // GET: Other/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Other other = await db.Other.FindAsync(id);
            if (other == null)
            {
                return HttpNotFound();
            }
            return View(other);
        }

        // POST: Other/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,string1,string2,string3,string4,string5,string6")] Other other)
        {
            if (ModelState.IsValid)
            {
                db.Entry(other).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(other);
        }

        #endregion

        #region Delete

        // GET: Other/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Other other = await db.Other.FindAsync(id);
        //    if (other == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(other);
        //}

        // POST: Other/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Other other = await db.Other.FindAsync(id);
            db.Other.Remove(other);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

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
