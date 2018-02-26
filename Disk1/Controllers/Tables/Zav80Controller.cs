﻿using Disk1.Models.bd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Disk1.Controllers.Tables
{
    public class Zav80Controller : Controller
    {
        [Authorize]
        public ActionResult Index()
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

            return View(list.OrderByDescending(e => e.ID).ToList());
        }
    }
}