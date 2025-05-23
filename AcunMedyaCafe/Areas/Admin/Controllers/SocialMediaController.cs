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
    public class SocialMediaController : Controller
    {
        private readonly CafeContext _context;
        private readonly IValidator<SocialMedia> _validator;

        public SocialMediaController(CafeContext context, IValidator<SocialMedia> validator)
        {
            _context = context;
            _validator = validator;
        }

        public IActionResult Index()
        {
            var values = _context.SocialMedias.ToList();
            return View(values);
        }
        public IActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]

        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index", "SocialMedia", new { area = "Admin" });
        }
        
        public IActionResult UpdateSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(SocialMedia p)
        {
            ValidationResult result = await _validator.ValidateAsync(p);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(p);
            }

            _context.SocialMedias.Update(p);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "SocialMedia", new { area = "Admin" });
        }
    }
}
