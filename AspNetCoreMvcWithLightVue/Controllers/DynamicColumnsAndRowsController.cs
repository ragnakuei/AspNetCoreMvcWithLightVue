using System.Linq;
using AspNetCoreMvcWithLightVue.Helpers;
using AspNetCoreMvcWithLightVue.Models;
using AspNetCoreMvcWithLightVue.Repositories;
using KueiExtensions.System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcWithLightVue.Controllers
{
    public class DynamicColumnsAndRowsController : Controller
    {
        private readonly NorthwindRepository _northwindRepository;

        private readonly string _style1ViewModelKey = "ComplexViewModel1";

        public DynamicColumnsAndRowsController(NorthwindRepository  northwindRepository)
        {
            _northwindRepository = northwindRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Style1()
        {
            var columnDtos = new[]
                             {
                                 new ColumnDto { Name = "CustomerID", ColumnType     = "Text" },
                                 new ColumnDto { Name = "EmployeeID", ColumnType     = "Text" },
                                 new ColumnDto { Name = "OrderDate", ColumnType      = "Text" },
                                 new ColumnDto { Name = "RequiredDate", ColumnType   = "Text" },
                                 new ColumnDto { Name = "ShippedDate", ColumnType    = "Text" },
                                 new ColumnDto { Name = "ShipVia", ColumnType        = "Text" },
                                 new ColumnDto { Name = "Freight", ColumnType        = "Text" },
                                 new ColumnDto { Name = "ShipName", ColumnType       = "Text" },
                                 new ColumnDto { Name = "ShipAddress", ColumnType    = "Text" },
                                 new ColumnDto { Name = "ShipCity", ColumnType       = "Text" },
                                 new ColumnDto { Name = "ShipRegion", ColumnType     = "Text" },
                                 new ColumnDto { Name = "ShipPostalCode", ColumnType = "Text" },
                                 new ColumnDto { Name = "ShipCountry", ColumnType    = "Text" },
                             };
            ViewBag.ColumnsJson    = columnDtos.ToJson();
            ViewBag.EmptyOrderJson = new NorthwindOrderDto().ToJson();

            var dto = new DynamicColumnsAndRowsDto
                      {
                          Columns = columnDtos.Select(dto => dto.Name).ToArray(),
                          Orders  = _northwindRepository.GetOrderList().Take(20),
                      };

            return View(dto);
        }

        [HttpPost]
        public IActionResult PostStyle1([FromBody]DynamicColumnsAndRowsDto dto)
        {
            TempData[_style1ViewModelKey] = dto.ToJson();

            return Ok(dto);
        }

        [HttpGet]
        public IActionResult ShowStyle1()
        {
            var dtoJson = TempData[_style1ViewModelKey]?.ToString();

            if (string.IsNullOrWhiteSpace(dtoJson))
            {
                return RedirectToAction("Style1");
            }

            ViewBag.DtoJson = dtoJson;

            return View();
        }
    }
}
