using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebkinzManagement.Models;
using WebkinzManagement.Services;
using WebkinzManagement.ViewModels;

namespace WebkinzManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private IProductRepository _tempdata;

        [ActivatorUtilitiesConstructor]
        public HomeController(IProductRepository tempdata)
        {
            _tempdata = tempdata;
        }
        
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel(); // temp class
            model.Products = _tempdata.ReadAll();
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
