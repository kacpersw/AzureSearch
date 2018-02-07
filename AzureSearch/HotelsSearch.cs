using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AzureSearch
{
    public class HotelsSearch
    {
        private readonly SearchServiceClient searchClient;
        private readonly ISearchIndexClient indexClient;
        private const string IndexName = "hotels";

        public string errorMessage;

        public HotelsSearch()
        {
            try
            {
                string searchServiceName = ConfigurationManager.AppSettings["SearchServiceName"];
                string apiKey = ConfigurationManager.AppSettings["SearchServiceApiKey"];

                searchClient = new SearchServiceClient(searchServiceName, new SearchCredentials(apiKey));
                indexClient = searchClient.Indexes.GetClient(IndexName);
            }
            catch (Exception e)
            {
                errorMessage = e.Message.ToString();
            }
        }

        public DocumentSearchResult Search(string searchText, string hotelId, double baseRate, string description, string description_fr, string hotelName, string category,
            IEnumerable<string> tags, bool parkingIncluded, bool smokingAllowed, DateTime lastRenovationDate, int rating)
        {
            try
            {
                SearchParameters sp = new SearchParameters()
                {
                    SearchMode = SearchMode.All,
                    Top = 10
                };

                return indexClient.Documents.Search(searchText, sp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error querying index: {0}\r\n", ex.Message.ToString());
            }

            return null;
        }
    }
}