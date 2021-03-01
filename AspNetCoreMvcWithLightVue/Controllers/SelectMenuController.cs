using System.Linq;
using System.Text.Json;
using AspNetCoreMvcWithLightVue.Helpers;
using AspNetCoreMvcWithLightVue.Infra;
using AspNetCoreMvcWithLightVue.Models;
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

        private readonly string _viewModelSessionKey = "SelectMenuViewModel";

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

            _contextAccessor.HttpContext.Session.SetString(_viewModelSessionKey, vm.ToJson());

            return Ok(vm);
        }

        [HttpGet]
        public IActionResult Style1Result()
        {
            var vmJson = _contextAccessor.HttpContext.Session.GetString(_viewModelSessionKey);
            var vm     = vmJson.ParseJson<SelectMenuViewModel>();

            return View(vm);
        }
    }
}
