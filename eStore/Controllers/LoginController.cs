﻿using Microsoft.AspNetCore.Mvc;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Http;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace eStore.Controllers
{
    public class LoginController : Controller
    {
        private readonly AssignmentContext _context;

        public LoginController(AssignmentContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        //[Route("login")]
        [HttpPost]
        public IActionResult CheckLogin(string email, string password)
        {
            IMemberRepository memberRepository = new MemberRepository();
            var account = ReadJson.GetAdmin();
            bool isAdmin = false;
            bool isMem = false;

            var members = memberRepository.GetMembers();
          //  Member loginUser = _context.Members.FirstOrDefault(m => m.Email == email && m.Password == password);
            if (email != null && password != null)
            {
                //System.Diagnostics.Debug.WriteLine(account.Email + "|" + account.Password);
                if (email.Equals(account.Email) && password.Equals(account.Password))
                {//admin
                    var member = new Member
                    {
                        Email = account.Email,
                        Password = account.Password,
                    };
                    isAdmin = true;
                    isMem = true;
                    return RedirectToAction("Index", "Home");
                }
                //else if (memberAccount != null)
                //{ //member , phan quyen

                //    isAdmin = false;
                //    HttpContext.Session.SetInt32("id", loginUser.MemberId);
                //    return RedirectToAction("Home", "User");
                //}
                foreach (var i in members)
                {
                    if (i.Email.Equals(email) && i.Password.Equals(password))
                    {
                        isAdmin = false;
                        isMem = true;
                        HttpContext.Session.SetInt32("id", i.MemberId);
                        return RedirectToAction("Index", "User");

                    }

                }
                if (isMem == true)
                {
                    ViewBag.error = "Invalid Account";
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ViewBag.error = "Wrong username/email or pass word, please try again";
                    return RedirectToAction("Login", "Login");

                }
            }
            else
            {

                ViewBag.error = "Please Enter your username and password";
                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("ACCOUNT");
            return RedirectToAction("Index");
        }
    }
}
