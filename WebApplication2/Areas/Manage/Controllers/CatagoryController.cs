using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DAL;
using WebApplication2.Models;

namespace WebApplication2.Areas.Manage.Controllers
{
    [Area("manage")]
    public class CatagoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CatagoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var Catagory = _context.Catagories.ToList();

            return View(Catagory);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Catagory Catagory)
        {
            ViewBag.ErrorMessage = "";
            if (ModelState.IsValid)
            {
              
                var cat = _context.Catagories.FirstOrDefault(x => x.Name == Catagory.Name);
                if (cat == null)
                {
                    _context.Catagories.Add(Catagory);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    
                    ViewBag.ErrorMessage = "Duplicate Category Name";

                }
            }
            return View(Catagory);
        }
        public IActionResult Update(int id)
        {
           

            return View();


        }
        [HttpPost]
        public IActionResult Update(Catagory Catagory)
        {
            ViewBag.ErrorMessage = "";
            if (ModelState.IsValid)
            {
                var cat = _context.Catagories.FirstOrDefault(x => x.Name == Catagory.Name
                                  && x.Id != Catagory.Id);
                if (cat == null)
                {
                    _context.Entry(Catagory).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    // Inform your user about the problem
                    ViewBag.ErrorMessage = "Duplicate category Name";
                }
            }
            return View(Catagory);
        }
    }
}
