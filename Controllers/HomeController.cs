using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LoginRegistration.Models;
using System.Linq;

namespace LoginRegistration.Controllers
{
    public class HomeController : Controller
    {
        private LnrContext dbContext;

        public HomeController(LnrContext context)
        {
            dbContext = context;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [Route("CreateUser")]
        [HttpPost]
        public IActionResult RegisterUser(MyModel newUser)
        {
            if (ModelState.IsValid) {
                PasswordHasher<MyModel> Hasher = new PasswordHasher<MyModel>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                newUser.CreatedAt = DateTime.Now;
                newUser.UpdatedAt = DateTime.Now;
                dbContext.Add(newUser);
                dbContext.SaveChanges();
                return RedirectToAction("Success");
            }
            else
            {
                return View("Index");
            }
        }

        [Route("LoggedIn")]
        [HttpPost]
        public IActionResult userLogin(MyLogin newLogin)
        {
            MyModel oneUser = dbContext.MyModel.Where(log => log.Email == newLogin.LEmail).FirstOrDefault();
            var hasher = new PasswordHasher<MyLogin>();
            var result = hasher.VerifyHashedPassword(newLogin, oneUser.Password, newLogin.LPassword);
            if(result ==0)
            {
                ModelState.AddModelError("LPassword", "Password does not match");
                return View("Login");
            }
            HttpContext.Session.SetInt32("ID", oneUser.MyModelId);
            return RedirectToAction("Logged");
        }

        [Route("Success")]
        [HttpGet]
        public IActionResult Logged()
        {
            int? IdCheck = HttpContext.Session.GetInt32("ID");
            return View("Success");
        }
    }
}
