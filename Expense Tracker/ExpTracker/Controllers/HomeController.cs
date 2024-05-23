using ExpTracker.Data;
using ExpTracker.Models;
using ExpTracker.Repository;
using Microsoft.AspNetCore.Http;
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
            if (HttpContext.Session.GetString("Username") == null)
            {
                ViewBag.LoggedUser = null;
                ViewBag.Signup = signup;
            }
            else
            {
                ViewBag.LoggedUser = HttpContext.Session.GetString("Username").ToString();
                ViewBag.Signup = signup;
            }
            
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("CustID");
            return RedirectToAction("Index", "Home");
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
