using ExpTracker.Data;
using ExpTracker.Models;
using ExpTracker.Repository;
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
        IExpTrackerRepository _repository;

        public HomeController(ILogger<HomeController> logger,IExpTrackerRepository repos)
        {
            _logger = logger;
            _context = new EXP_TRACKERContext();
            _repository = repos;
        }

        public IActionResult Index(string signup=null)
        {
            //ViewBag.LoggedUser = "Silajit";
            if(signup!=null)
                ViewBag.Signup = signup;
            var data = _context.Customer.Where(er=>er.CustPassword.Equals("1234")).ToList();
            List<string> list = new List<string>();
            foreach (var item in data)
            {
                list.Add(item.CustFname);
            }
            return View(list);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
