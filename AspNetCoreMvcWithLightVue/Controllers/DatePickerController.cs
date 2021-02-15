using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcWithLightVue.Controllers
{
    public class DatePickerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Style1()
        {
            // v-model two-way binding - 針對 Browser 提供的 Date Picker
            return View();
        }
        public IActionResult Style2()
        {
            // v-model two-way binding - 針對 jQuery UI Date Picker
            return View();
        }
    }
}
