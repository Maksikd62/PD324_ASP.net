using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PD324_01.Data;
using PD324_01.Models;
using PD324_01.Models.ViewModels;
using PD324_01.Repositories;
using System.Diagnostics;

namespace PD324_01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {
            int pageSize = 5;
            var products = _context.Products.ToList();
            var totalProducts = products.Count;
            var totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);

            var pagedProducts = products.Skip((page - 1) * pageSize).Take(pageSize);

            var model = new HomeVM
            {
                Products = pagedProducts,
                Categories = _context.Categories.ToList(),
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}