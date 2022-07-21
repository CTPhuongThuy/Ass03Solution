﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DataAccess;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace eStore.Controllers
{
    public class UserController : Controller
    {

        AssignmentContext db = new AssignmentContext();
        private Member LoginUser()
        {
            int? id = HttpContext.Session.GetInt32("id");
            var member = db.Members.SingleOrDefault(m => m.MemberId == id);
            return member;
        }
        // GET: UserController
        public ActionResult Index()
        {
            var member = LoginUser();
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public async Task<IActionResult> Edit()
        {
            var member = await db.Members.FindAsync(LoginUser().MemberId);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberId,Email,CompanyName,City,Country,Password,Status")] Member member)
        {
            if (id != member.MemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    db.Update(member);
                    await db.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }
        private bool MemberExists(int id)
        {
            return db.Members.Any(e => e.MemberId == id);
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}