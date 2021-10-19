using System.Collections.Generic;
using System.Linq;
using AspNetCoreMvcWithLightVue.Models;
using AspNetCoreMvcWithLightVue.Repositories;
using KueiExtensions.System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcWithLightVue.Controllers
{
    public class DynamicColumnsAndRowsController : Controller
    {
        private readonly string _style1ViewModelKey = "ComplexViewModel1";

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Style1()
        {
            var columnDtos = new[]
                             {
                                 nameof(NorthwindOrderDto.CustomerID),
                                 nameof(NorthwindOrderDto.EmployeeID),
                                 nameof(NorthwindOrderDto.OrderDate),
                                 nameof(NorthwindOrderDto.RequiredDate),
                                 nameof(NorthwindOrderDto.ShippedDate),
                             };
            ViewBag.ColumnsJson    = columnDtos.ToJson();
            ViewBag.EmptyOrderJson = new NorthwindOrderDto().ToJson();

            var dto = new DynamicColumnsAndRowsDto
                      {
                          Columns = columnDtos.Select(dto => dto).ToArray(),
                          Orders  = GetNorthwindOrderDtos(),
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

        private IEnumerable<NorthwindOrderDto> GetNorthwindOrderDtos()
        {
            return new[]
                   {
                       new NorthwindOrderDto { OrderID = 1, CustomerID = "CA", EmployeeID = 1, OrderDate = "2020/12/01", RequiredDate = "2020/12/15", ShippedDate = "2020/12/10" },
                       new NorthwindOrderDto { OrderID = 2, CustomerID = "CA", EmployeeID = 1, OrderDate = "2020/12/01", RequiredDate = "2020/12/15", ShippedDate = "2020/12/10" },
                       new NorthwindOrderDto { OrderID = 3, CustomerID = "CB", EmployeeID = 2, OrderDate = "2020/12/02", RequiredDate = "2020/12/16", ShippedDate = "2020/12/10" },
                       new NorthwindOrderDto { OrderID = 4, CustomerID = "CB", EmployeeID = 3, OrderDate = "2020/12/03", RequiredDate = "2020/12/17", ShippedDate = "2020/12/10" },
                       new NorthwindOrderDto { OrderID = 5, CustomerID = "CC", EmployeeID = 1, OrderDate = "2020/11/01", RequiredDate = "2020/11/15", ShippedDate = "2020/11/10" },
                   };
        }
    }
}
