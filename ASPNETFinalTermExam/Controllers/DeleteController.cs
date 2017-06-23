using ASPNETFinalTermExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETFinalTermExam.Controllers
{
    public class DeleteController : Controller
    {
        // GET: Delete
        [HttpPost()]
        public ActionResult Delete(String CustomerID)
        {

            KuasDb db = new KuasDb();
                //用where 那他出來的型態不一樣
                Customers cus = db.Customers.Find(Int32.Parse(CustomerID));

                db.Customers.Remove(cus);
                db.SaveChanges();
          
            return View();
        }
    }
}