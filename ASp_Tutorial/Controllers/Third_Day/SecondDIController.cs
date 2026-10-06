using Microsoft.AspNetCore.Mvc;

namespace ASp_Tutorial.Controllers.Third_Day
{
    public class SecondDIController() : Controller
    {
        //DI Dependency Injection
        public IActionResult Index()
        {
            return View();
        }
    }
}
