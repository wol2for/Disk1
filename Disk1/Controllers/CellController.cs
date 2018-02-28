using Disk1.Models.bd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Disk1.Controllers
{
    public class CellController : ApiController
    {
        private Disk bd = new Disk();
        // GET api/Cell
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Cell/5
        public object Get(int? id, [FromBody]string tablename)
        {
            if (String.IsNullOrEmpty(tablename))
                return null;
            if (id == null)
                return null;

            switch (tablename)
            {
                case "правий (город)":
                    {
                        return bd.CNAP.Find(id); 
                    }
                case "ЦНАП контроль":
                    {

                        return bd.ControlCNAP.Find(id);
                    }
                case "левий (райони)":
                    {
                        return bd.Left.Find(id);
                    }
                case "Норматівки":
                    { 
                        return bd.Regulations.Find(id);
                    }
                case "неприватизация":
                    {
                        return bd.NotPrivatization.Find(id);
                    }
                case "внесеня змін":
                    {
                        return bd.Alteration.Find(id);
                    }
                case "Онлайн витяг":
                    {

                        return bd.Online.Find(id);
                    }
                case "6-зем":
                    {
                        
                        return bd.Sixzem.Find(id);
                    }
                case "викопіювання":
                    {
                        return bd.Dumping.Find(id);
                    }
                case "заявка-витяг 80грн.":
                    {
                        return bd.Zav80.Find(id);
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        // POST api/Cell
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Cell/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Cell/5
        public void Delete(int id)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bd.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}