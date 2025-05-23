using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AcunMedyaCafe.Controllers
{
    public class LoginController : Controller
    {
        private readonly CafeContext _context;

        public LoginController(CafeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            var user = _context.Admins.FirstOrDefault(x => x.Username == username && x.Password == password);

            if (user != null)
            {
                TempData["Message"] = "Giriş başarılı!";
                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.Error = "Kullanıcı adı veya şifre hatalı.";
            return View();
        }
    }
}