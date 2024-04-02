using Microsoft.AspNetCore.Mvc;

namespace Resume_Builder.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
