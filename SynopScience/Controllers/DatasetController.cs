using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SynopScience.Data;
using SynopScience.Models;

namespace SynopScience.Controllers
{
    public class DatasetController : Controller
    {
        // Different Result Functions:
        // * ViewResult - returns an HTML view                               return View();
        // * JsonResult - returns JSON formatted data                        return Json(data);
        // * ContentResult - returns plain text content                      return Content("plain text);
        // * RedirectResult - redirects to a URL                             return Redirect("url");
        // * RedirectToActionResult - redirects to another action            return RedirectToAction("ActionName");
        // * StatusCodeResult - returns a specific HTTP status code          return StatusCode(404);

        // * IActionResult - the default function that allows the use of any of these functions
        //public IActionResult Overview()
        //{
        //var dataset = new Dataset() { Id = 1, ItemCode = "TST01", ItemName = "TST-000-01", ItemDescription="Steel Plated Material", ItemType="Metal", ItemCount=25, ItemPrice = 10.9f, ItemShelfLife = 60, ItemActive = true };
        //return View(dataset);
        //}

        //Read the Data

        private readonly DatasetContext _context;

        public DatasetController(DatasetContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dataset = await _context.Dataset.Include(s =>s.SerialNumber).ToListAsync();
            return View(dataset);
        }

        //Create the Data
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id","ItemName","ItemCode","ItemDescription","ItemType","ItemCount", "ItemPrice", "ItemShelfLife", "ItemActive")] Dataset data)
        {
            if(ModelState.IsValid)
            {
                _context.Dataset.Add(data);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(data);
        }

        //Edit the Data
        public async Task<IActionResult> Edit(int Id)
        {
            var data = await _context.Dataset.FirstOrDefaultAsync(x =>x.Id == Id);
            return View(data);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(int Id, [Bind("Id", "ItemName", "ItemCode", "ItemDescription", "ItemType", "ItemCount", "ItemPrice", "ItemShelfLife", "ItemActive")] Dataset data)
        {
            if (ModelState.IsValid)
            {
                _context.Update(data);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(data);
        }

        //Delete Data
        public async Task<IActionResult> Delete(int Id)
        {
            var data = await _context.Dataset.FirstOrDefaultAsync(_ => _.Id == Id);
            return View(data);
        }
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> ConfirmDeletion(int Id)
        {
            var data = await _context.Dataset.FindAsync(Id);
            var serial = await _context.SerialNumbers.FindAsync(Id);

            if (data != null)
            {
                _context.SerialNumbers.Remove(serial);
                _context.Dataset.Remove(data);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}
