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
            // 按下按鈕，counter 會加 1，但不會反映至 Html 中
            return View();
        }

        public IActionResult Style2()
        {
            // 1. 透過 ref 來包裝 primitive type，就可以動態更新
            // 2. 加上 watch field 來監視值的變動
            return View();
        }

        public IActionResult Style3()
        {
            // 1. 透過 reactive 來包裝 object type，來進行動態更新
            return View();
        }
    }
}
