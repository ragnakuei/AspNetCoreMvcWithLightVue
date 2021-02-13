using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcWithLightVue.Controllers
{
    public class ProvideInjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Style1()
        {
            return View();
        }
    }
}