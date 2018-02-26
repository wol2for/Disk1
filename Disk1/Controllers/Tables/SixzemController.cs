﻿using Disk1.Models.bd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Disk1.Controllers.Tables
{
    public class SixzemController : Controller
    {
        [Authorize]
        public ActionResult Index()
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

            return View(list.OrderByDescending(e => e.ID).ToList());
        }
    }
}