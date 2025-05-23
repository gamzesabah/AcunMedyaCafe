using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Areas.Admin.Controllers
{
    //[Authorize]
    [Area("Admin")]
    public class SubscribeController : Controller
    {
        private readonly CafeContext _context;
        private readonly IValidator<Subscribe> _validator;

        public SubscribeController(CafeContext context, IValidator<Subscribe> validator)
        {
            _context = context;
            _validator = validator;
        }

        public IActionResult Index()
        {
            var values = _context.Subscribers.ToList();
            return View(values);
        }
        public IActionResult AddSubscribe()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSubscribe(Subscribe p)
        {
            ValidationResult result = await _validator.ValidateAsync(p);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(p);
            }

            _context.Subscribers.Add(p);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Subscribe", new { area = "Admin" });
        }
        public IActionResult DeleteSubscribe(int id)
        {
            var value = _context.Subscribers.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index", "Subscribe", new { area = "Admin" });
        }
        public IActionResult UpdateSubscribe(int id)
        {
            var value = _context.Subscribers.Find(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSubscribe(Subscribe p)
        {
            ValidationResult result = await _validator.ValidateAsync(p);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(p);
            }

            _context.Subscribers.Update(p);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Subscribe", new { area = "Admin" });
        }
    }
}