using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
