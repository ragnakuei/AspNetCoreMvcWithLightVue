using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcWithLightVue.Controllers
{
    public class SlotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Style1()
        {
            // parent component 內給定 child component inner html，由 child component 來顯示 !
            return View();
        }

        public IActionResult Style2()
        {
            // parent component 內給定 child component inner html，由 child component 的 jQuery UI Dialog 來顯示 !
            // 以 watch props 的方式來判斷，是否需要顯示 dialog
            return View();
        }

        public IActionResult Style3()
        {
            // parent component 內給定 child component inner html，由 child component 的 jQuery UI Dialog 來顯示 !
            // 以直接呼叫 child component method 的方式來顯示 dialog
            return View();
        }
    }
}
