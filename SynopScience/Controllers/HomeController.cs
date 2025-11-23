using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SynopScience.Data;
using SynopScience.Models;

namespace SynopScience.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly DatasetContext _context;

        public HomeController(DatasetContext context)
        {
            _context = context;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
            //_logger = logger;
        //}

        public async Task<IActionResult> Index()
        {
            var dataset = await _context.Dataset.Include(s => s.SerialNumber).ToListAsync();
            ViewBag.MyData = dataset;
            return View(dataset);
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
