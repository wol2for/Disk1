using Disk1.Models.bd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Disk1.Controllers.Tables
{
    [Authorize]
    public class DumpingController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.username = User.Identity.Name;
            List<Dumping> list = null;
            var response = new Disk1.Controllers.ValuesController().Get("викопіювання");

            if (response == null)
                return new HttpStatusCodeResult(400, "Такой таблицы не существует");

            try
            {
                list = (List<Dumping>)response;
            }
            catch
            {
                return new HttpStatusCodeResult(400, "Приведение не осуществилось");
            }

            return View(list.OrderByDescending(e => e.ID).ToList());
        }



        #region Create row      
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.WhoList = new Disk1.Models.DropDownListSettings().WhoList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FIO,Gave,Got,Comment,WhoAdded,Who")] Dumping Dumping)
        {
            if (ModelState.IsValid)
            {
                var r = new Disk1.Controllers.ValuesController().Post("викопіювання", Dumping);
                if (!r)
                    return new HttpStatusCodeResult(400, "Неверный запрос");

                return RedirectToAction("Index");
            }

            return View(Dumping);
        }
        #endregion

        #region Edit row
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dumping Dumping = (Dumping)new Disk1.Controllers.CellController().Get(id, "викопіювання");
            if (Dumping == null)
            {
                return HttpNotFound();
            }
            ViewBag.WhoList = new Disk1.Models.DropDownListSettings().WhoList();
            return View(Dumping);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FIO,Gave,Got,Comment,WhoAdded,Who")] Dumping Dumping)
        {
            if (ModelState.IsValid)
            {
                var r = new Disk1.Controllers.ValuesController().Put("викопіювання", Dumping);
                if (!r)
                    return new HttpStatusCodeResult(400, "Неверный запрос");

                return RedirectToAction("Index");
            }
            return View(Dumping);
        }
        #endregion

        #region delete row
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CNAP cNAP = await db.CNAP.FindAsync(id);
        //    if (cNAP == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cNAP);
        //}


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var r = new Disk1.Controllers.ValuesController().Delete(id, "викопіювання");
            if (!r)
                return new HttpStatusCodeResult(400, "Неверный запрос");

            return RedirectToAction("Index");
        }
        #endregion

    }
}