using Disk1.Models.bd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Disk1.Helpers
{
    public static class WhoHelper
    {
        public static MvcHtmlString Who(this HtmlHelper html, int? id)
            {
                if(id == null)
                    return new MvcHtmlString("н/д");

                string name = null;
                using (Disk bd = new Disk()) {

                  name = bd.Who.Find(id).Who1;
                    
                    }
                if(string.IsNullOrEmpty(name))
                    return new MvcHtmlString("н/д");

                return new MvcHtmlString(name);
            }
    }
}