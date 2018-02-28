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
    public class NormativeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.username = User.Identity.Name;
            List<Regulations> list = null;
            var response = new Disk1.Controllers.ValuesController().Get("Норматівки");

            if (response == null)
                return new HttpStatusCodeResult(400, "Такой таблицы не существует");

            try
            {
                list = (List<Regulations>)response;
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
        public ActionResult Create([Bind(Include = "ID,FIO,Address,Gave,Got,Comment,WhoAdded,Who")] Regulations Regulations)
        {
            if (ModelState.IsValid)
            {
                var r = new Disk1.Controllers.ValuesController().Post("Норматівки", Regulations);
                if (!r)
                    return new HttpStatusCodeResult(400, "Неверный запрос");
                return RedirectToAction("Index");
            }

            return View(Regulations);
        }
        #endregion

        #region Edit row
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regulations Regulations = (Regulations)new Disk1.Controllers.CellController().Get(id, "Норматівки");
            if (Regulations == null)
            {
                return HttpNotFound();
            }
            ViewBag.WhoList = new Disk1.Models.DropDownListSettings().WhoList();
            return View(Regulations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FIO,Address,Gave,Got,Comment,WhoAdded,Who")] Regulations Regulations)
        {
            if (ModelState.IsValid)
            {
                var r = new Disk1.Controllers.ValuesController().Put("Норматівки", Regulations);
                if (!r)
                    return new HttpStatusCodeResult(400, "Неверный запрос");

                return RedirectToAction("Index");
            }
            return View(Regulations);
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
            var r = new Disk1.Controllers.ValuesController().Delete(id, "Норматівки");
            if (!r)
                return new HttpStatusCodeResult(400, "Неверный запрос");

            return RedirectToAction("Index");
        }
        #endregion

    }
}