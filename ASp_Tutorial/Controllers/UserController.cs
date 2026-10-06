using Microsoft.AspNetCore.Mvc;

namespace ASp_Tutorial.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
