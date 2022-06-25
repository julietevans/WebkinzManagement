using Microsoft.AspNetCore.Mvc;

namespace WebkinzManagement.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
