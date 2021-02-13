using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcWithLightVue.Controllers
{
    public class CounterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Style1()
        {
            return View();
        }

        public IActionResult Style2()
        {
            return View();
        }

        public IActionResult Style3()
        {
            return View();
        }
    }
}
