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

        // POST api/values/5
        public bool Post(string tablename, [FromBody]object item)
        {

            if (String.IsNullOrEmpty(tablename))
                return false;
            if(item == null)
                return false;

            switch (tablename)
            {
                case "правий (город)":
                    {
                        bd.CNAP.Add((CNAP)item);
                        bd.SaveChanges();
                        return true;
                    }
                case "ЦНАП контроль":
                    {
                        bd.ControlCNAP.Add((ControlCNAP)item);
                        bd.SaveChanges();
                        return true;
                    }
                case "левий (райони)":
                    {
                        bd.Left.Add((Left)item);
                        bd.SaveChanges();
                        return true;
                    }
                case "Норматівки":
                    {
                        bd.Regulations.Add((Regulations)item);
                        bd.SaveChanges();
                        return true;
                    }
                case "неприватизация":
                    {
                        bd.NotPrivatization.Add((NotPrivatization)item);
                        bd.SaveChanges();
                        return true;
                    }
                case "внесеня змін":
                    {
                        bd.Alteration.Add((Alteration)item);
                        bd.SaveChanges();
                        return true; 
                    }
                case "Онлайн витяг":
                    {
                        bd.Online.Add((Online)item);
                        bd.SaveChanges();
                        return true;
                    }
                case "6-зем":
                    {
                        bd.Sixzem.Add((Sixzem)item);
                        bd.SaveChanges();
                        return true;
                    }
                case "викопіювання":
                    {
                        bd.Dumping.Add((Dumping)item);
                        bd.SaveChanges();
                        return true;
                    }
                case "заявка-витяг 80грн.":
                    {
                        bd.Zav80.Add((Zav80)item);
                        bd.SaveChanges();
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }


        }

        // PUT api/values/5
        public bool Put(string tablename, [FromBody]object item)
        {
            if (String.IsNullOrEmpty(tablename))
                return false;
            if (item == null)
                return false;
            //db.Entry(cNAP).State = EntityState.Modified;
            switch (tablename)
            {
                case "правий (город)":
                    {
                        bd.Entry((CNAP)item).State = EntityState.Modified;
                        bd.SaveChanges();
                        return true;
                    }
                case "ЦНАП контроль":
                    {
                        bd.Entry((ControlCNAP)item).State = EntityState.Modified;
                        bd.SaveChanges();
                        return true;
                    }
                case "левий (райони)":
                    {
                        bd.Entry((Left)item).State = EntityState.Modified;
                        bd.SaveChanges();
                        return true;
                    }
                case "Норматівки":
                    {
                        bd.Entry((Regulations)item).State = EntityState.Modified;
                        bd.SaveChanges();
                        return true;
                    }
                case "неприватизация":
                    {
                        bd.Entry((NotPrivatization)item).State = EntityState.Modified;
                        bd.SaveChanges();
                        return true;
                    }
                case "внесеня змін":
                    {
                        bd.Entry((Alteration)item).State = EntityState.Modified;
                        bd.SaveChanges();
                        return true;
                    }
                case "Онлайн витяг":
                    {
                        bd.Entry((Online)item).State = EntityState.Modified;
                        bd.SaveChanges();
                        return true;
                    }
                case "6-зем":
                    {
                        bd.Entry((Sixzem)item).State = EntityState.Modified;
                        bd.SaveChanges();
                        return true;
                    }
                case "викопіювання":
                    {
                        bd.Entry((Dumping)item).State = EntityState.Modified;
                        bd.SaveChanges();
                        return true;
                    }
                case "заявка-витяг 80грн.":
                    {
                        bd.Entry((Zav80)item).State = EntityState.Modified;
                        bd.SaveChanges();
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        // DELETE api/values/5
        public bool Delete(int? id, [FromBody]string tablename)
        {
            if (id == null)
                return false;
            if (string.IsNullOrEmpty(tablename))
                return false;

            //db.Entry(cNAP).State = EntityState.Modified;
            switch (tablename)
            {
                case "правий (город)":
                    {
                        CNAP cNAP = bd.CNAP.Find(id);
                        bd.CNAP.Remove(cNAP);
                        bd.SaveChanges();
                        return true;
                    }
                case "ЦНАП контроль":
                    {
                        ControlCNAP ControlCNAP = bd.ControlCNAP.Find(id);
                        bd.ControlCNAP.Remove(ControlCNAP);
                        bd.SaveChanges();
                        return true;
                    }
                case "левий (райони)":
                    {
                        Left Left = bd.Left.Find(id);
                        bd.Left.Remove(Left);
                        bd.SaveChanges();
                        return true;
                    }
                case "Норматівки":
                    {
                        Regulations Regulations = bd.Regulations.Find(id);
                        bd.Regulations.Remove(Regulations);
                        bd.SaveChanges();
                        return true;
                    }
                case "неприватизация":
                    {
                        NotPrivatization NotPrivatization = bd.NotPrivatization.Find(id);
                        bd.NotPrivatization.Remove(NotPrivatization);
                        bd.SaveChanges();
                        return true;
                    }
                case "внесеня змін":
                    {
                        Alteration Alteration = bd.Alteration.Find(id);
                        bd.Alteration.Remove(Alteration);
                        bd.SaveChanges();
                        return true;
                    }
                case "Онлайн витяг":
                    {
                        Online Online = bd.Online.Find(id);
                        bd.Online.Remove(Online);
                        bd.SaveChanges();
                        return true;
                    }
                case "6-зем":
                    {
                        Sixzem Sixzem = bd.Sixzem.Find(id);
                        bd.Sixzem.Remove(Sixzem);
                        bd.SaveChanges();
                        return true;
                    }
                case "викопіювання":
                    {
                        Dumping Dumping = bd.Dumping.Find(id);
                        bd.Dumping.Remove(Dumping);
                        bd.SaveChanges();
                        return true;
                    }
                case "заявка-витяг 80грн.":
                    {
                        Zav80 Zav80 = bd.Zav80.Find(id);
                        bd.Zav80.Remove(Zav80);
                        bd.SaveChanges();
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
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
