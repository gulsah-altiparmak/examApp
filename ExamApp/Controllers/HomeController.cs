using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExamApp.Models;
using Data;
using System.Net.Http;
using HtmlAgilityPack;

namespace ExamApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            HttpClient client = new HttpClient();
            string title;
            // get answer in non-blocking way
            using (var response = await client.GetAsync("https://www.wired.com/story/these-adorable-fish-robots-form-schools-like-the-real-thing/"))
            {
                using (var content = response.Content)
                {
                    // read answer in non-blocking way
                    var result = await content.ReadAsStringAsync();
                    var document = new HtmlDocument();
                    document.LoadHtml(result);
                    var node = document.DocumentNode.SelectSingleNode("//*[@id='main-content']/article/div[1]/header/div/div[1]/h1");
                     title=node.InnerText;
                    //Some work with page....
                }
            }
            return View(title);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
