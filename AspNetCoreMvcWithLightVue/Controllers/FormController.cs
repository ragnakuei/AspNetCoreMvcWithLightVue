using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcWithLightVue.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Style1()
        {
            // 驗証 form
            return View();
        }

        public IActionResult Style2()
        {
            // 驗証 form
            return View();
        }
    }
}
