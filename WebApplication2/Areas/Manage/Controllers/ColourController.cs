using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Areas.Manage.Controllers
{
    public class ColourController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
