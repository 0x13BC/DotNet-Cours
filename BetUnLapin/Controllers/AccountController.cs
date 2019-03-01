using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetUnLapin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BetUnLapin.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register( RegisterViewModel Model)
        {
            if(ModelState.IsValid)
            {

            }

            return View();
        }
    }
}