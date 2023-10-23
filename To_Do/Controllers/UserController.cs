using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using To_Do.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace To_Do.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "";
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Home", "User");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            User user = await _context.User.FirstOrDefaultAsync(u => u.user_email == email);
            if (user != null)
            {
                if (String.Equals(user.password.Trim(), password))
                {
                    ViewBag.Message = "";
                    HttpContext.Session.SetInt32("user_id", user.user_id);
                    return RedirectToAction("Index", "ToDoItems");
                }
            }
            ViewBag.Message = "Invalid Email or Password";
            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string username, string email, string password, string password1)
        {
            User usr = await _context.User.FirstOrDefaultAsync(u => u.user_email == email);
            if (usr != null)
                ViewBag.Message = "User is already Registered";
            else
            {
                if (password == password1)
                {
                    ViewBag.Message = "";
                    User user = new User();
                    user.username = username;
                    user.user_email = email;
                    user.password = password;
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Login", "User");
                }
                else
                    ViewBag.Message = "Confirm password not matched";
            }
            return View();
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public async Task<IActionResult> Details()
        {
            int id = (int)HttpContext.Session.GetInt32("user_id");
            if (id == 0)
            {
                return NotFound();
            }
            var user = await _context.User.FirstOrDefaultAsync(m => m.user_id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: UserController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("user_id, username, user_email, password")] User user)
        {
            int user_id = (int)HttpContext.Session.GetInt32("user_id");
            if (id != user_id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Details));
            }
            return View(user);
        }

        public async Task<IActionResult> ChangePassword(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(int id, string password, string new_password)
        {
            ViewBag.Message = id.ToString() + " " + password + " " + new_password;
            int user_id = (int)HttpContext.Session.GetInt32("user_id");
            if (id != user_id)
            {
                return NotFound();
            }
            User user = await _context.User.FirstOrDefaultAsync(m => m.user_id == id);
            user.password = user.password.Trim();
            ViewBag.Message = id.ToString() + " " + password + " " + user.password;
            if (password == user.password)
            {
                ViewBag.Message = "Hello";
                user.password = new_password;
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Details));
            }
            return View(user);
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
