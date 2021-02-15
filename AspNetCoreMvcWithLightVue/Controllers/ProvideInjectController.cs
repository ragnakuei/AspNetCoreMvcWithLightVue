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
            // parent component 設定 provide，child component 設定 inject，來達成跨 component 溝通的方式
            return View();
        }
    }
}
