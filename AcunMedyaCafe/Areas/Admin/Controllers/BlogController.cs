﻿using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Areas.Admin.Controllers
{
    //[Authorize]
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly CafeContext _context;
        private readonly IValidator<Blog> _validator;

        public BlogController(CafeContext context, IValidator<Blog> validator)
        {
            _context = context;
            _validator = validator;
        }

        public IActionResult Index()
        {
            var values = _context.Blogs.ToList();
            return View(values);
        }
        public IActionResult AddBlog()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBlog(Blog p)
        {
            ValidationResult result = await _validator.ValidateAsync(p);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(p);
            }

            _context.Blogs.Add(p);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Blog", new { area = "Admin" });
        }
        public IActionResult DeleteBlog(int id)
        {
            var value = _context.Blogs.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index", "Blog", new { area = "Admin" });
        }
        public IActionResult UpdateBlog(int id)
        {
            var value = _context.Blogs.Find(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(Blog p)
        {
            ValidationResult result = await _validator.ValidateAsync(p);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(p);
            }

            _context.Blogs.Update(p);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Blog", new { area = "Admin" });
        }
    }
}