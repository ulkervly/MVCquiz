using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DAL;
using WebApplication2.Models;

namespace WebApplication2.Areas.Manage.Controllers
{
    [Area("manage")]

    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var Products = _context.Products.ToList();

            return View(Products);
        }
        public IActionResult Create()
        {
            ViewBag.Colours = _context.Colours.ToList();
            ViewBag.Catagories = _context.Catagories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product Product)
        {
            ViewBag.Colours = _context.Colours.ToList();
            ViewBag.Catagories = _context.Catagories.ToList();
            if (!ModelState.IsValid)
            {

                return View();
            }
            if (!_context.Catagories.Any(a => a.Id == Product.CatagoryId))
            {
                ModelState.AddModelError("CatagoriesId", "genre is not found!");
                return View();
            }


            bool check = true;
            if (Product.ColourIds != null)
            {
                foreach (var item in Product.ColourIds)
                {
                    if (!_context.Colours.Any(x => x.Id == item))
                    {
                        check = false;
                        break;
                    }
                }
            }
            if (check)
            {
                foreach (var item in Product.ColourIds)
                {
                    ProductColour ProductColour = new ProductColour()
                    {
                        Product = Product,
                        ColourId = item,
                    };
                    _context.ProductColours.Add(ProductColour);
                }
            }
            else
            {
                ModelState.AddModelError("ColourId", "Error");
                return View();
            }


            _context.Products.Add(Product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            ViewBag.Colours = _context.Colours.ToList();
            ViewBag.Catagories = _context.Catagories.ToList();

            Product existProduct = _context.Products.Include(x => x.ProductColours).FirstOrDefault(x => x.Id == id);
            if (existProduct == null) return NotFound();

            existProduct.ColourIds = existProduct.ProductColours.Select(x => x.ColourId).ToList();
            return View(existProduct);


        }
        [HttpPost]
        public IActionResult Update(Product Product)
        {
            ViewBag.Colours = _context.Colours.ToList();
            ViewBag.Catagories = _context.Catagories.ToList();

            if (!ModelState.IsValid)
            {
                return View();
            }
            Product existProduct = _context.Products.Include(x => x.ProductColours).FirstOrDefault(x => x.Id == Product.Id);
            if (existProduct == null) return NotFound();


            existProduct.ProductColours.RemoveAll(x => !Product.ColourIds.Any(y => y == x.ColourId));

            foreach (var item in Product.ColourIds.Where(x => !existProduct.ProductColours.Any(y => y.ColourId == x)))
            {
                ProductColour ProductTag = new ProductColour()
                {
                    ColourId = item,
                };
                _context.ProductColours.Add(ProductTag);
            }



            existProduct.Name = Product.Name;
            existProduct.Description = Product.Description;
            ;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}
