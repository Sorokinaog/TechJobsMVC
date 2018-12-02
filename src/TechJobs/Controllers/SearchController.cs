using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm )
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.searchType = searchType;

            if (searchType == "all")
            {
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobs;
                ViewBag.title = "Search by all fields";
                return View("Index");
            }
            else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobs;
                ViewBag.title = string.Format("Search by {0}", searchType);
                return View("Index");
            }
        }
    }
}
