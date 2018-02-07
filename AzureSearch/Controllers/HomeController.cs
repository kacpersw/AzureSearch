using AzureSearch.Models;
using Newtonsoft.Json;
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

            
            var a = new NYCHotels()
            {
                Results = response.Results,
                Facets = response.Facets,
                Count = Convert.ToInt32(response.Count)
            };
            var b = a.Results;



            var listOfCategories = new List<string>();

            var dictionary = new Dictionary<string, string>();
            foreach (var result in response.Results)
            {
                var aa = result.Document.Where(k=>k.Key == "Document").ToDictionary(ina=> ina, new Example { });
                var asasa = JsonConvert.SerializeObject(result.Document);

            }
            var tt = JsonConvert.SerializeObject(response);
            var os = JsonConvert.DeserializeObject(tt);
            foreach (var category in listOfCategories)
            {

            }

            return jsonResult;
        }
        public class Example
        {
            public int? Count { get; set; }
            public Dictionary<string, object> Results { get; set; }
        }
    }

}