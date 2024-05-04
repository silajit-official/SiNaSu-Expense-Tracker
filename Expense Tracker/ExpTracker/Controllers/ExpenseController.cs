using ExpTracker.Models;
using ExpTracker.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

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
                    if(name.Equals("-1"))
                    {
                        ModelState.AddModelError("CustEmail", "Email Already exist. Please use another Email for registering");
                        return View();
                    }
                    return RedirectToAction("Index", "Home", new { signup = name });
                }
                return View();
            }
            else
            {
                ViewBag.mode = "login";
                ViewBag.loginError = "0";
                if (ModelState.IsValid)
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

        public IActionResult AddExpenseCategory(string statusMessage=null)
        {
            var username = HttpContext.Session.GetString("Username");
            if(username == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.statusMessage = statusMessage;
            ViewBag.username = username;

            return View();
        }

        [HttpPost]
        public IActionResult AddExpenseCategory(ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid)
            {
                int retVal=_repositoy.AddExpenseCategory(expenseCategory);
                return RedirectToAction("AddExpenseCategory", "Expense", new { statusMessage = retVal.ToString() });
            }
            return View();
        }

        public IActionResult ViewAllExpenseCategoryName()
        {
            var username = HttpContext.Session.GetString("Username");
            if (username == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.username = username;
            List<ExpenseCategory> expenseCategories=_repositoy.ViewAllExpenseCategoryName();
            return View(expenseCategories);
        }

        public IActionResult DeleteCatgoryByID(int id)
        {
            var username = HttpContext.Session.GetString("Username");
            if (username == null)
            {
                return RedirectToAction("Index", "Home");
            }
            int retVal=_repositoy.DeleteCatgoryByID(id);
            return RedirectToAction("ViewAllExpenseCategoryName","Expense");
        }


    }
}
