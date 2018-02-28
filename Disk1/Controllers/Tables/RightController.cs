using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Disk1.Models.bd;
using Newtonsoft.Json;

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
            ViewBag.WhoList = new Disk1.Models.DropDownListSettings().WhoList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FIO,Address,Gave,Got,Comment,WhoAdded,Who")] CNAP cNAP)
        {
            if (ModelState.IsValid)
            {
                var r = new Disk1.Controllers.ValuesController().Post("правий (город)", cNAP);
                if (!r)
                    return new HttpStatusCodeResult(400, "Неверный запрос");
                //string s = null;
                //for (int i = 0; i < Request.Headers.Count; i++)
                //{
                //    s += Request.Headers[i];
                //}

                //var rrr = Request.Headers["Authorization"];
                //HttpClient cleint = new HttpClient();
                //cleint.DefaultRequestHeaders.Add("Authorization",Request.Headers["Authorization"]);
                //cleint.BaseAddress = new Uri("http://localhost:4106");

                //var myContent = JsonConvert.SerializeObject(cNAP);
                //var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                //var byteContent = new ByteArrayContent(buffer);
                //byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //var rr =  cleint.PutAsJsonAsync("api/values/правий", byteContent).Result;
                return RedirectToAction("Index");
            }

            return View(cNAP);
        }
        #endregion

        #region Edit row
        public  ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CNAP cNAP = (CNAP)new Disk1.Controllers.CellController().Get(id, "правий (город)");
            if (cNAP == null)
            {
                return HttpNotFound();
            }
            ViewBag.WhoList = new Disk1.Models.DropDownListSettings().WhoList();
            return View(cNAP);
        }

        // POST: CNAPs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Edit([Bind(Include = "ID,FIO,Address,Gave,Got,Comment,WhoAdded,Who")] CNAP cNAP)
        {
            if (ModelState.IsValid)
            {
                var r = new Disk1.Controllers.ValuesController().Put("правий (город)", cNAP);
                if (!r)
                    return new HttpStatusCodeResult(400, "Неверный запрос");

                return RedirectToAction("Index");
            }
            return View(cNAP);
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
            var r = new Disk1.Controllers.ValuesController().Delete(id,"правий (город)");
            if (!r)
                return new HttpStatusCodeResult(400, "Неверный запрос");

            return RedirectToAction("Index");
        }
        #endregion
    }
}