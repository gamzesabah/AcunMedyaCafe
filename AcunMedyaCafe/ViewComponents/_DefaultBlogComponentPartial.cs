using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcunMedya.Coffe.ViewComponents
{
    public class _DefaultBlogComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;
        public _DefaultBlogComponentPartial(CafeContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var value = _context.Blogs.ToList() ?? new List<Blog>();
            return View(value);
        }

    }
}