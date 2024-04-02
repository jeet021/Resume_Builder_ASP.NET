using Microsoft.AspNetCore.Mvc;

namespace Resume_Builder.Controllers
{
    public class MainDataInsertController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
