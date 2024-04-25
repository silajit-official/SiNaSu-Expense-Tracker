using ExpTracker.Data;
using ExpTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ExpTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EXP_TRACKERContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = new EXP_TRACKERContext();
        }

        public IActionResult Index()
        {
            //ViewBag.LoggedUser = "Silajit";
            var data = _context.Customer.Where(er=>er.CustPassword.Equals("1234")).ToList();
            List<string> list = new List<string>();
            foreach (var item in data)
            {
                list.Add(item.CustFname);
            }
            return View(list);
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
