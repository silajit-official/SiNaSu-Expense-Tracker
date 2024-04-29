using ExpTracker.Models;
using ExpTracker.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExpTracker.Controllers
{
    public class ExpenseController : Controller
    {
        public IExpTrackerRepository _repositoy;
        public ExpenseController(IExpTrackerRepository repos)
        {
            _repositoy = repos;
        }
        [HttpPost]
        public IActionResult SignupLogin(Customer customer)
        {
            string name;
            ViewBag.mode = "signin";
            if (ModelState.IsValid)
            {
                 name= _repositoy.AddNewCustomer(customer);
                return RedirectToAction("Index", "Home", new { signup = name });
            }
            //name=_repositoy.AddNewCustomer(customer);
            return View();
        }

        public IActionResult SignupLogin(string mode)
        {
            if (mode.Equals("1"))
            {
                ViewBag.mode = "signin";
            }
            else
                ViewBag.mode = "login";
            return View();
        }

        

    }
}
