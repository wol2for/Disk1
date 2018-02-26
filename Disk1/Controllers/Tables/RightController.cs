using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Disk1.Models.bd;

namespace Disk1.Controllers.Tables
{
    [Authorize]
    public class RightController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.username = User.Identity.Name;
            List<CNAP> list = null;
            var response = new Disk1.Controllers.ValuesController().Get("правий (город)");

            if (response == null)
                return new HttpStatusCodeResult(400, "Такой таблицы не существует");

            try
            {
                list = (List<CNAP>)response;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FIO,Address,Gave,Got,Comment,WhoAdded,Who")] CNAP cNAP)
        {
            if (ModelState.IsValid)
            {
                var r = new Disk1.Controllers.ValuesController();
                r.Post(cNAP, "правий (город)");

                //db.CNAP.Add(cNAP);
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cNAP);
        }
        #endregion
    }
}