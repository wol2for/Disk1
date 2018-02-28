using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Disk1.Models
{
    public class DropDownListSettings
    {
        public List<SelectListItem> WhoList() {

            List<SelectListItem> whoList = new List<SelectListItem>(); ;
            using (bd.Disk bd = new bd.Disk())
            {
                foreach (var item in bd.Who)
                {
                    whoList.Add(new SelectListItem { Value = item.ID.ToString(), Text = item.Who1 });
                }
            }

            return whoList;

        }
    }
}