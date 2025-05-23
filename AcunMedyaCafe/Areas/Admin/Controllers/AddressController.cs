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
    public class AddressController : Controller
    {
        private readonly CafeContext _context;
        private readonly IValidator<Address> _validator;

        public AddressController(CafeContext context, IValidator<Address> validator)
        {
            _context = context;
            _validator = validator;
        }

        public IActionResult Index()
        {
            var values = _context.Addresses.ToList();
            return View(values);
        }
        public IActionResult AddAddress()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAddress(Address p)
        {
            ValidationResult result = await _validator.ValidateAsync(p);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(p);
            }

            _context.Addresses.Add(p);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Address", new { area = "Admin" });
        }
        public IActionResult DeleteAddress(int id)
        {
            var value = _context.Addresses.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index", "Address", new { area = "Admin" });
        }
        public IActionResult UpdateAddress(int id)
        {
            var value = _context.Addresses.Find(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAddress(Address p)
        {
            ValidationResult result = await _validator.ValidateAsync(p);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(p);
            }

            _context.Addresses.Update(p);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Address", new { area = "Admin" });
        }
    }
}