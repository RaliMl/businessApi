using Microsoft.AspNetCore.Mvc;

namespace GoodeBooks.Controllers
{
    public class GoogleBookApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
