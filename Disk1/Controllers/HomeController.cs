using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Disk1.Models.bd;


using System.Data;
using System.Data.Entity;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Disk1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Главаня";
            return View();
        }

        [Authorize]
        public ActionResult Main()
        {
            ViewBag.username = User.Identity.Name;
            return View(new Disk1.Controllers.ValuesController().Get());
        }

        public ActionResult Register()
        {
            return View();
        }

        #region PartialView for authorize/unauthorize

        [ChildActionOnly]
        public ActionResult Table()
        {
            if (User.Identity.IsAuthenticated)
                return PartialView("TablePrivate");
            else
                return PartialView("TableAll");
        }

        [ChildActionOnly]
        public ActionResult Btn()
        {
            if (User.Identity.IsAuthenticated)
                return PartialView("logout");
            else
                return PartialView("Reg");
        }
        #endregion

        #region ТАБЛИЦЫ открытые для всех

        //правый город 
        public ActionResult RightCity()
        {
            ViewBag.username = User.Identity.Name;
            List<CNAP> list = null;
            var response = new Disk1.Controllers.ValuesController().Get("правий (город)");

            if (response == null)
                return new HttpStatusCodeResult(400,"Такой таблицы не существует");

            try{
                list = (List<CNAP>)response;
            }
            catch{
                return new HttpStatusCodeResult(400, "Приведение не осуществилось");
            }

            return View(list.OrderByDescending(e=>e.ID));
        }

        //ЦНАП контроль
        public ActionResult CNAPControl()
        {
            ViewBag.username = User.Identity.Name;
            List<ControlCNAP> list = null;
            var response = new Disk1.Controllers.ValuesController().Get("ЦНАП контроль");

            if (response == null)
                return new HttpStatusCodeResult(400, "Такой таблицы не существует");

            try
            {
                list = (List<ControlCNAP>)response;
            }
            catch
            {
                return new HttpStatusCodeResult(400, "Приведение не осуществилось");
            }

            return View(list.OrderByDescending(e => e.ID));
        }

        //левый город 
        public ActionResult LeftCity()
        {
            ViewBag.username = User.Identity.Name;
            List<Left> list = null;
            var response = new Disk1.Controllers.ValuesController().Get("левий (райони)");

            if (response == null)
                return new HttpStatusCodeResult(400, "Такой таблицы не существует");

            try
            {
                list = (List<Left>)response;
            }
            catch
            {
                return new HttpStatusCodeResult(400, "Приведение не осуществилось");
            }

            return View(list.OrderByDescending(e => e.ID));
        }

        //нормативки
        public ActionResult Normative()
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

            return View(list.OrderByDescending(e => e.ID));
        }

        //неприватизация
        public ActionResult nonPrivatization()
        {
            ViewBag.username = User.Identity.Name;
            List<NotPrivatization> list = null;
            var response = new Disk1.Controllers.ValuesController().Get("неприватизация");

            if (response == null)
                return new HttpStatusCodeResult(400, "Такой таблицы не существует");

            try
            {
                list = (List<NotPrivatization>)response;
            }
            catch
            {
                return new HttpStatusCodeResult(400, "Приведение не осуществилось");
            }

            return View(list.OrderByDescending(e => e.ID));
        }

        //внесеня змін
        public ActionResult Alteration()
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

            return View(list.OrderByDescending(e => e.ID));
        }

        //6-зем
        public ActionResult Sixzem()
        {
            ViewBag.username = User.Identity.Name;
            List<Sixzem> list = null;
            var response = new Disk1.Controllers.ValuesController().Get("6-зем");

            if (response == null)
                return new HttpStatusCodeResult(400, "Такой таблицы не существует");

            try
            {
                list = (List<Sixzem>)response;
            }
            catch
            {
                return new HttpStatusCodeResult(400, "Приведение не осуществилось");
            }

            return View(list.OrderByDescending(e => e.ID));
        }

        //викопіювання
        public ActionResult Dumping()
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

            return View(list.OrderByDescending(e => e.ID));
        }

        //Онлайн витяг
        public ActionResult Online()
        {
            ViewBag.username = User.Identity.Name;
            List<Online> list = null;
            var response = new Disk1.Controllers.ValuesController().Get("Онлайн витяг");

            if (response == null)
                return new HttpStatusCodeResult(400, "Такой таблицы не существует");

            try
            {
                list = (List<Online>)response;
            }
            catch
            {
                return new HttpStatusCodeResult(400, "Приведение не осуществилось");
            }

            return View(list.OrderByDescending(e => e.ID));
        }

        //заявка-витяг 80грн.
        public ActionResult Zav80()
        {
            ViewBag.username = User.Identity.Name;
            List<Zav80> list = null;
            var response = new Disk1.Controllers.ValuesController().Get("заявка-витяг 80грн.");

            if (response == null)
                return new HttpStatusCodeResult(400, "Такой таблицы не существует");

            try
            {
                list = (List<Zav80>)response;
            }
            catch
            {
                return new HttpStatusCodeResult(400, "Приведение не осуществилось");
            }

            return View(list.OrderByDescending(e => e.ID));
        }
        #endregion

    }
}
