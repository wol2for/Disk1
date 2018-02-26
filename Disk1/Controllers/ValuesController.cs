using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Disk1.Models.bd;

using System.Data.Entity;
using System.Threading.Tasks;

namespace Disk1.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        private Disk bd = new Disk();

        // GET api/values
        public List<CNAP> Get()
        {
            
            return bd.CNAP.ToList();
        }

        // GET api/values/5
        public object Get(string tablename)
        {
            if (String.IsNullOrEmpty(tablename))
                return null;

            switch (tablename)
            {
                case "правий (город)":
                    {
                        return bd.CNAP.ToList();
                    }
                case "ЦНАП контроль":
                    {
                        return bd.ControlCNAP.ToList(); ;
                    }
                case "левий (райони)":
                    {
                        return bd.Left.ToList(); 
                    }
                case "Норматівки":
                    {
                        return bd.Regulations.ToList();
                    }
                case "неприватизация":
                    {
                        return bd.NotPrivatization.ToList();
                    }
                case "внесеня змін":
                    {
                        return bd.Alteration.ToList();
                    }
                case "Онлайн витяг":
                    {
                        return bd.Online.ToList();
                    }
                case "6-зем":
                    {
                        return bd.Sixzem.ToList();
                    }
                case "викопіювання":
                    {
                        return bd.Dumping.ToList();
                    }
                case "заявка-витяг 80грн.":
                    {
                        return bd.Zav80.ToList();
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        // POST api/values
        public void Post([FromBody]object item, string tablename)
        {
            if (tablename == "правий (город)")
                bd.CNAP.Add((CNAP)item);

            bd.SaveChanges();

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
