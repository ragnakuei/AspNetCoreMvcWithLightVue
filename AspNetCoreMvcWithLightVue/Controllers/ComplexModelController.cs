using System.Text.Json;
using AspNetCoreMvcWithLightVue.Helpers;
using AspNetCoreMvcWithLightVue.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcWithLightVue.Controllers
{
    public class ComplexModelController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;

        private readonly string _viewModelSessionKey = "ComplexViewModel";

        private readonly ComplexViewModel _vm
            = new ComplexViewModel
              {
                  Categories = new[]
                               {
                                   new Category
                                   {
                                       Id   = 1,
                                       Name = "Category1",
                                       SubCategories = new[]
                                                       {
                                                           new SubCategory
                                                           {
                                                               Id   = 11,
                                                               Name = "SubCategory11",
                                                               Items = new[]
                                                                       {
                                                                           new Item { Id = 111, Name = "Item111", },
                                                                           new Item { Id = 112, Name = "Item112", },
                                                                       }
                                                           },
                                                           new SubCategory
                                                           {
                                                               Id   = 12,
                                                               Name = "SubCategory12",
                                                               Items = new[]
                                                                       {
                                                                           new Item { Id = 121, Name = "Item121", },
                                                                           new Item { Id = 122, Name = "Item122", },
                                                                           new Item { Id = 123, Name = "Item123", },
                                                                       }
                                                           },
                                                       }
                                   },
                                   new Category
                                   {
                                       Id   = 2,
                                       Name = "Category2",
                                       SubCategories = new[]
                                                       {
                                                           new SubCategory
                                                           {
                                                               Id   = 21,
                                                               Name = "SubCategory21",
                                                               Items = new[]
                                                                       {
                                                                           new Item { Id = 211, Name = "Item211", },
                                                                           new Item { Id = 212, Name = "Item212", },
                                                                       }
                                                           },
                                                           new SubCategory
                                                           {
                                                               Id   = 22,
                                                               Name = "SubCategory22",
                                                               Items = new[]
                                                                       {
                                                                           new Item { Id = 221, Name = "Item221", },
                                                                           new Item { Id = 222, Name = "Item222", },
                                                                           new Item { Id = 223, Name = "Item223", },
                                                                       }
                                                           },
                                                           new SubCategory
                                                           {
                                                               Id   = 23,
                                                               Name = "SubCategory23",
                                                               Items = new[]
                                                                       {
                                                                           new Item { Id = 231, Name = "Item231", },
                                                                           new Item { Id = 232, Name = "Item232", },
                                                                           new Item { Id = 233, Name = "Item233", },
                                                                           new Item { Id = 234, Name = "Item234", },
                                                                       }
                                                           },
                                                       }
                                   },
                               }
              };

        public ComplexModelController(IHttpContextAccessor contextAccessor)
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
            return View(_vm);
        }

        [HttpPost]
        public IActionResult PostStyle1(ComplexViewModel vm)
        {
            return View("Style1Result", vm);
        }

        [HttpGet]
        public IActionResult Style2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostStyle2([FromBody]ComplexViewModel vm)
        {
            _contextAccessor.HttpContext.Session.SetString(_viewModelSessionKey, vm.ToJson());

            return Ok(vm);
        }

        [HttpGet]
        public IActionResult Style2Result()
        {
            var vmJson = _contextAccessor.HttpContext.Session.GetString(_viewModelSessionKey);
            var vm     = JsonSerializer.Deserialize<ComplexViewModel>(vmJson);

            return View(vm);
        }
    }

    public class ComplexViewModel
    {
        public Category[] Categories { get; set; }
    }

    public class Category
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public SubCategory[] SubCategories { get; set; }
    }

    public class SubCategory
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public Item[] Items { get; set; }
    }

    public class Item
    {
        public int? Id { get; set; }

        public string Name { get; set; }
    }
}
