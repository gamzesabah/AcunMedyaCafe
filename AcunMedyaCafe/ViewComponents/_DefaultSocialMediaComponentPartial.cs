using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class _DefaultSocialMediaComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;

        public _DefaultSocialMediaComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.SocialMedias.ToList();
            return View(value);

        }
    }
}