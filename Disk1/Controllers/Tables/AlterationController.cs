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
    public class AlterationController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.username = User.Identity.Name;
            List<Alteration> list = null;

            var response = new Disk1.Controllers.ValuesController().Get("внесеня змін");

            if (response == null)
                return new HttpStatusCodeResult(400, "Такой таблицы не существует");

            try
            {
                list = (List<Alteration>)response;
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
        public ActionResult Create([Bind(Include = "ID,FIO,Gave,Got,Comment,WhoAdded,Who")] Alteration Alteration)
        {
            if (ModelState.IsValid)
            {
                var r = new Disk1.Controllers.ValuesController().Post("внесеня змін", Alteration);
                if (!r)
                    return new HttpStatusCodeResult(400, "Неверный запрос");

                return RedirectToAction("Index");
            }

            return View(Alteration);
        }
        #endregion

        #region Edit row
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alteration Alteration = (Alteration)new Disk1.Controllers.CellController().Get(id, "внесеня змін");
            if (Alteration == null)
            {
                return HttpNotFound();
            }
            ViewBag.WhoList = new Disk1.Models.DropDownListSettings().WhoList();
            return View(Alteration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FIO,Gave,Got,Comment,WhoAdded,Who")] Alteration Alteration)
        {
            if (ModelState.IsValid)
            {
                var r = new Disk1.Controllers.ValuesController().Put("внесеня змін", Alteration);
                if (!r)
                    return new HttpStatusCodeResult(400, "Неверный запрос");

                return RedirectToAction("Index");
            }
            return View(Alteration);
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

        // POST: CNAPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //CNAP cNAP = await db.CNAP.FindAsync(id);
            //db.CNAP.Remove(cNAP);
            //await db.SaveChangesAsync();
            var r = new Disk1.Controllers.ValuesController().Delete(id, "внесеня змін");
            if (!r)
                return new HttpStatusCodeResult(400, "Неверный запрос");

            return RedirectToAction("Index");
        }
        #endregion
    }
}