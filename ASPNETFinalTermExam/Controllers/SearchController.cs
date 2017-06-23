using ASPNETFinalTermExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETFinalTermExam.Controllers
{
    public class SearchController : Controller
    {
        KuasDb db = new KuasDb();
        List<SelectListItem> ContactTitleList = new List<SelectListItem>();
        // GET: Search
        public ActionResult Search()
        {
            GetData();
            return View();
        }

        [HttpPost()]
        public JsonResult SearchAction(String CustomerID,String CustomerName,String ContactName,String ContactTitle)
        {
            var order = db.Customers.Where(x =>
            (string.IsNullOrEmpty(CustomerID) ? true : x.CustomerID.ToString().Equals(CustomerID)) &&
              (string.IsNullOrEmpty(CustomerName) ? true : x.CompanyName.ToString().Contains(CustomerName)) &&
              (string.IsNullOrEmpty(ContactName) ? true : x.ContactName.ToString().Contains(ContactName)) &&
              (string.IsNullOrEmpty(ContactTitle) ? true : x.ContactTitle.ToString().Equals(ContactTitle))
            ).Select(x => new
            {
                x.CustomerID,
                CustomerName=x.CompanyName,
                x.ContactName,
                x.ContactTitle
            }
            ).ToList();

            return this.Json(order);
        }


        public void GetData()
        {
            ContactTitleList.Add(new SelectListItem
            {
                Text = "請選擇職稱",
                Value = ""
            });

         
        }
    }
}