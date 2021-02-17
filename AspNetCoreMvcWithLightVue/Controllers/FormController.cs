using System.Linq;
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
            // 驗証 form + jQuery AutoComplete
            // product 欄位輸入
            return View();
        }

        private readonly ProductDto[] _products
            = new[]
              {
                  new ProductDto { Id = 1, Name  = "Product01" },
                  new ProductDto { Id = 2, Name  = "Product02" },
                  new ProductDto { Id = 3, Name  = "Product03" },
                  new ProductDto { Id = 4, Name  = "Product04" },
                  new ProductDto { Id = 5, Name  = "Product05" },
                  new ProductDto { Id = 6, Name  = "Product06" },
                  new ProductDto { Id = 7, Name  = "Product07" },
                  new ProductDto { Id = 8, Name  = "Product08" },
                  new ProductDto { Id = 9, Name  = "Product09" },
                  new ProductDto { Id = 10, Name = "Product10" },
                  new ProductDto { Id = 11, Name = "Product11" },
                  new ProductDto { Id = 12, Name = "Product12" },
                  new ProductDto { Id = 13, Name = "Product13" },
                  new ProductDto { Id = 14, Name = "Product14" },
                  new ProductDto { Id = 15, Name = "Product15" },
              };

        [HttpPost, Route("api/[Controller]/[Action]")]
        public IActionResult GetProducts([FromBody]SearchDto searchDto)
        {
            var result = _products.Where(p => p.Name.Contains(searchDto.Keyword))
                                  .Select(p => new
                                               {
                                                   id    = p.Id,
                                                   label = p.Name,
                                                   name  = p.Name,
                                               });

            return Ok(result);
        }
    }

    public class SearchDto
    {
        public string Keyword { get; set; }
    }

    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
