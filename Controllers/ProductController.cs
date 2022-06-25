using Microsoft.AspNetCore.Mvc;
using WebkinzManagement.Services;
using WebkinzManagement.Models;
using WebkinzManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace WebkinzManagement.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _tempdata;
        public ProductController(IProductRepository tempdata)
        {
            // dependency injection
            _tempdata = tempdata;
        }


        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel(); // temp class
            model.Products = _tempdata.ReadAll();
            return View(model);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _tempdata.AddProduct(obj);
                ViewBag.Message = "Product was successfully added!";
            }
            //return RedirectToAction("Index");
            return View(obj);
        }


        public IActionResult Details(int? id)
        {
            var pro = _tempdata.GetProduct(id);
            if (pro == null)
            {
                return NotFound();
            }
            return View(pro);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            Product obj = _tempdata.GetProduct(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(Product obj, int id)
        {
            obj.Id = id;
            if (ModelState.IsValid)
            {
                _tempdata.UpdateProduct(obj);
                ViewBag.Message = "Product was susccessfuly updated!";
            }
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _tempdata.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
