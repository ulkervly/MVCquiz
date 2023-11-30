using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.DAL;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel homeVm = new HomeViewModel()
            {
                
                //FeaturedPlants = _context.Products.Include(x => x.ProductImages).Where(x => x.IsFeatured == true).ToList(),
                //NewPlants = _context.Products.Include(x => x.ProductImages).Where(x => x.IsLatest == true).ToList(),
                //BestsellerPlants = _context.Products.Include(x => x.ProductImages).Where(x => x.IsBestseller == true).ToList(),
            };

            return View(homeVm);
        }


    }
}