using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AspNetCoreMvcWithLightVue.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMvcWithLightVue.Infra;

namespace AspNetCoreMvcWithLightVue.Controllers
{
    public class ComplexModelController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;

        private readonly string _style2ViewModelKey = "ComplexViewModel2";
        private readonly string _style3ViewModelKey = "ComplexViewModel3";

        private readonly ComplexViewModel _vm
            = new ComplexViewModel
              {
                  Categories = new[]
                               {
                                   new Category
                                   {
                                       Id   = 1,
                                       Name = "Category1",
                                       Items = new[]
                                               {
                                                   new Item
                                                   {
                                                       Id    = 11,
                                                       Name  = "Item11",
                                                       Value = 11m,
                                                   },
                                                   new Item
                                                   {
                                                       Id    = 12,
                                                       Name  = "Item12",
                                                       Value = 12m,
                                                   },
                                                   new Item
                                                   {
                                                   },
                                               }
                                   },
                                   new Category
                                   {
                                       Id   = 2,
                                       Name = "Category2",
                                       Items = new[]
                                               {
                                                   new Item
                                                   {
                                                       Id    = 21,
                                                       Name  = "Item21",
                                                       Value = 21m,
                                                   },
                                                   new Item
                                                   {
                                                       Id    = 22,
                                                       Name  = "Item22",
                                                       Value = 22m,
                                                   },
                                                   new Item
                                                   {
                                                       Id    = 23,
                                                       Name  = "Item23",
                                                       Value = 23m,
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
        public async Task<IActionResult> NewCategoryAndThreeItems(int categoryIndex)
        {
            var model = new ComplexViewModel
                        {
                            Categories = new[]
                                         {
                                             new Category
                                             {
                                                 Items = Enumerable.Range(0, 3)
                                                                   .Select(i => new Item())
                                                                   .ToArray(),
                                             }
                                         }
                        };

            var html = (await this.RenderViewAsync("CategoryView", model))
               .Replace("Categories[0]",
                        $"Categories[{categoryIndex}]");

            return Ok(html);
        }

        [HttpPost]
        public IActionResult ShowStyle1(ComplexViewModel vm)
        {
            ViewBag.ReturnUrl = Url.Action("Style1");

            return View("ComplexViewModel", vm);
        }

        [HttpGet]
        public IActionResult Style2()
        {
            return View(_vm);
        }

        [HttpPost]
        public IActionResult PostStyle2(ComplexViewModel vm)
        {
            _contextAccessor.HttpContext.Session.SetString(_style2ViewModelKey, vm.ToJson());

            return Ok(vm);
        }

        [HttpGet]
        public IActionResult ShowStyle2()
        {
            var vmJson = _contextAccessor.HttpContext.Session.GetString(_style2ViewModelKey);

            var vm = vmJson.ParseJson<ComplexViewModel>();

            ViewBag.ReturnUrl = Url.Action("Style2");

            return View("ComplexViewModel", vm);
        }

        [HttpGet]
        public IActionResult Style3()
        {
            ViewBag.EmptyCategoryJson = new Category
                                        {
                                            Items = Enumerable.Range(0, 3)
                                                              .Select(i => new Item())
                                                              .ToArray(),
                                        }.ToJson();


            return View(_vm);
        }

        [HttpPost]
        public IActionResult PostStyle3([FromBody]ComplexViewModel vm)
        {
            _contextAccessor.HttpContext.Session.SetString(_style3ViewModelKey, vm.ToJson());

            return Ok(vm);
        }

        [HttpGet]
        public IActionResult ShowStyle3()
        {
            var vmJson = _contextAccessor.HttpContext.Session.GetString(_style3ViewModelKey);

            var vm = vmJson.ParseJson<ComplexViewModel>();

            ViewBag.ReturnUrl = Url.Action("Style3");

            return View("ComplexViewModel", vm);
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

        public Item[] Items { get; set; }
    }

    public class Item
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public decimal? Value { get; set; }
    }
}
