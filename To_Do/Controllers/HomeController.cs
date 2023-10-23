using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using To_Do.Models;

namespace To_Do.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ToDos _db;

        public HomeController(ILogger<HomeController> logger,ToDos db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        // chart js code
        public IActionResult getBarData()
        {
            int id = (int)HttpContext.Session.GetInt32("user_id");
            var result = _db.bargraphItems.Where(m => m.user_id == id).GroupBy(m => m.date).Select(g => new { x=g.Key,y=g.Sum(i => i.completed_task) }).ToList();
            return Json(result);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
