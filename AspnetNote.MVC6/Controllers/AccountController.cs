using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetNote.MVC6.DataContext;
using AspnetNote.MVC6.Models;
using Microsoft.AspNetCore.Mvc;
using AspnetNote.MVC6.ViewModel;
using Microsoft.AspNetCore.Http;

namespace AspnetNote.MVC6.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // User ID, Password - Required
            if(ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbContext())
                {
                    // Linq - method chain
                    // => : A Go to B

                    var user = db.Users.FirstOrDefault(u => u.UserId.Equals(model.UserId) && u.UserPassword.Equals(model.UserPassword));

                    if (user != null)
                    {
                        //Login Sucessful
                        //HttpContext.Session.SetInt32(key, value);

                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);


                        return RedirectToAction("LoginSucess", "Home"); //Redirects to LoginSucess View in Home controller

                       
                    }
                }
                //Login Failed
                ModelState.AddModelError(string.Empty, "User ID or User Password is not correct.");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            //HttpContext.Session.Clear();
            HttpContext.Session.Remove("USER_LOGIN_KEY");

            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// Register
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Register Post
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(User model)
        {
            if(ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbContext())
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}