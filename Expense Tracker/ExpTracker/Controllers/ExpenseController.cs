using ExpTracker.Models;
using ExpTracker.Repository;
using Microsoft.AspNetCore.Http;
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
        public IActionResult SignupLogin(Customer customer,string mode)
        {
            if (mode.Equals("1"))
            {
                string name;
                ViewBag.mode = "signin";
                if (ModelState.IsValid)
                {
                    name = _repositoy.AddNewCustomer(customer);
                    return RedirectToAction("Index", "Home", new { signup = name });
                }
                return View();
            }
            else
            {
                ViewBag.mode = "login";
                if(ModelState.IsValid)
                {
                    string name= _repositoy.Login(customer);
                    if (name != null)
                    {
                        HttpContext.Session.SetString("Username",name);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        return RedirectToAction("SignupLogin", "Expense", new { mode = "2", loginError = "1" });
                }
               
                return View();
            }
            
        }

        public IActionResult SignupLogin(string mode,string loginError="0")
        {
            ViewBag.loginError = loginError;
            if (mode.Equals("1"))
            {
                ViewBag.mode = "signin";
            }
            else
            {
                ViewBag.mode = "login";
                
            }


            return View();
        }

        

    }
}
