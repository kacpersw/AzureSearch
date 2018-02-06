using AzureSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureSearch.Controllers
{
    public class HomeController : Controller
    {
        private HotelsSearch hotelsSearch;

        public HomeController()
        {
            hotelsSearch = new HotelsSearch();
        }

        public ActionResult Index()
        {
            var response = hotelsSearch.Search("Luxury", "1", 0, "", "", "Fancy Stay", "Luxury", null, false, false, new DateTime(2010, 6, 27), 5);

            var jsonResult = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new NYCHotels() { Results = response.Results, Facets = response.Facets, Count = Convert.ToInt32(response.Count) }
            };

            return jsonResult;
        }
    }
}