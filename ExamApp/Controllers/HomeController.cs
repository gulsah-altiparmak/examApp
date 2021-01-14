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
using System.Net;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        private HashSet<string> hSet = new HashSet<string>();
        
        
        
        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult RetrieveData(){
            try
            {
                // download the html source
                var webClient = new WebClient();
                var source = webClient.DownloadString(@"https://www.wired.com/");
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(source);

                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("/html/body/div[3]/div/div[3]/div/div/div[2]/div[1]/div/div[1]//a[@href]"))
                {
                    if (link != null)
                    {
                        // take the value of the attribute

                        var href = link.GetAttributeValue("href", "");
                        if (href.StartsWith("/story"))
                        {
                            hSet.Add(href);
                            Console.WriteLine(href);
                        }

                    }
                }
                TitleAndContent(hSet);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            
            return View();
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
        public void TitleAndContent(HashSet<string> link)
        {
            
            string innerText = "";
            foreach (var item in link)
            {
                var webClient = new WebClient();
                var source = webClient.DownloadString(@"https://www.wired.com" + item);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(source);
                var titleNode = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/main/article/div[1]/header/div/div[1]/h1");
                var innerTitle=titleNode.InnerText;
                if(_context.Exams.Any(p=> p.Title.Equals(innerTitle))) continue;
                
                foreach (HtmlNode text in doc.DocumentNode.SelectNodes("/html/body/div[1]/div/main/article/div[2]//p/text()"))
                {
                    innerText = innerText + text.InnerText;
                }
                var exam =new Exam{
                Content=innerText,
                Title = innerTitle
                 };
                _context.Exams.Add(exam);
                _context.SaveChanges();
                innerText = "";
            }


        }

      
     
        

    }
}
