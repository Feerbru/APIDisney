using Microsoft.AspNetCore.Mvc;

namespace Disney.Api.Controllers
{
    public class MovieController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}