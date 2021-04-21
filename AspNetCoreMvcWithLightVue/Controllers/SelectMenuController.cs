using System.Linq;
using AspNetCoreMvcWithLightVue.Helpers;
using AspNetCoreMvcWithLightVue.Infra;
using AspNetCoreMvcWithLightVue.Models;
using KueiExtensions.System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcWithLightVue.Controllers
{
    public class SelectMenuController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;

        private readonly SelectOptionItem<int>[] _gendorOptions
            = new[]
              {
                  new SelectOptionItem<int> { Value = 1, Text = "男" },
                  new SelectOptionItem<int> { Value = 2, Text = "女" },
                  new SelectOptionItem<int> { Value = 3, Text = "不明" },
              };

        private readonly string _viewModelSessionKeyStyle1 = "SelectMenuViewModelStyle1";
        private readonly string _viewModelSessionKeyStyle2 = "SelectMenuViewModelStyle2";
        private readonly string _viewModelSessionKeyStyle3 = "SelectMenuViewModelStyle3";

        public SelectMenuController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Style1()
        {
            ViewBag.GendorOptionsJson = _gendorOptions.ToJson();

            return View();
        }


        [HttpPost]
        public IActionResult PostStyle1([FromBody]SelectMenuViewModel vm)
        {
            vm.GendorName = _gendorOptions.FirstOrDefault(g => g.Value == vm.GendorId)?.Text;

            _contextAccessor.HttpContext.Session.SetString(_viewModelSessionKeyStyle1, vm.ToJson());

            return Ok(vm);
        }

        [HttpGet]
        public IActionResult Style1Result()
        {
            var vmJson = _contextAccessor.HttpContext.Session.GetString(_viewModelSessionKeyStyle1);
            var vm     = vmJson.ParseJson<SelectMenuViewModel>();

            return View(vm);
        }

        [HttpGet]
        public IActionResult Style2()
        {
            var vmJson = _contextAccessor.HttpContext.Session.GetString(_viewModelSessionKeyStyle2);
            var vm = string.IsNullOrWhiteSpace(vmJson)
                         ? new SelectMenuViewModel()
                         : vmJson.ParseJson<SelectMenuViewModel>();

            ViewBag.GendorOptionsJson = _gendorOptions.ToJson();

            return View(vm);
        }


        [HttpPost]
        public IActionResult PostStyle2([FromBody]SelectMenuViewModel vm)
        {
            vm.GendorName = _gendorOptions.FirstOrDefault(g => g.Value == vm.GendorId)?.Text;

            _contextAccessor.HttpContext.Session.SetString(_viewModelSessionKeyStyle2, vm.ToJson());

            return Ok(vm);
        }

        [HttpGet]
        public IActionResult Style3()
        {
            var vmJson = _contextAccessor.HttpContext.Session.GetString(_viewModelSessionKeyStyle3);
            var vm = string.IsNullOrWhiteSpace(vmJson)
                         ? new SelectMenuViewModel()
                         : vmJson.ParseJson<SelectMenuViewModel>();

            ViewBag.GendorOptionsJson = _gendorOptions.ToJson();

            return View(vm);
        }
    }
}
