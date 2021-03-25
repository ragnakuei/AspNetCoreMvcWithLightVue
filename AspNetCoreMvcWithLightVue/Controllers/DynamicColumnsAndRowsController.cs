using System.Linq;
using AspNetCoreMvcWithLightVue.Helpers;
using AspNetCoreMvcWithLightVue.Models;
using AspNetCoreMvcWithLightVue.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcWithLightVue.Controllers
{
    public class DynamicColumnsAndRowsController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;

        private readonly NorthwindRepository _northwindRepository;

        private readonly string _style1ViewModelKey = "ComplexViewModel1";

        public DynamicColumnsAndRowsController(IHttpContextAccessor contextAccessor,
                                               NorthwindRepository  northwindRepository)
        {
            _contextAccessor     = contextAccessor;
            _northwindRepository = northwindRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Style1()
        {
            var dto = new DynamicColumnsAndRowsDto
                      {
                          Columns = new[]
                                    {
                                        "CustomerID",
                                        "EmployeeID",
                                        "OrderDate",
                                        "RequiredDate",
                                        "ShippedDate",
                                        "ShipVia",
                                        "Freight",
                                        "ShipName",
                                        "ShipAddress",
                                        "ShipCity",
                                        "ShipRegion",
                                        "ShipPostalCode",
                                        "ShipCountry",
                                    },
                          Orders = _northwindRepository.GetOrderList().Take(20),
                      };

            ViewBag.EmptyOrderJson = new NorthwindOrderDto().ToJson();

            return View(dto);
        }

        [HttpPost]
        public IActionResult PostStyle1([FromBody]DynamicColumnsAndRowsDto dto)
        {
            _contextAccessor.HttpContext.Session.SetString(_style1ViewModelKey, dto.ToJson());

            return Ok(dto);
        }

        [HttpGet]
        public IActionResult ShowStyle1()
        {
            var vmJson = _contextAccessor.HttpContext.Session.GetString(_style1ViewModelKey);

            var vm = vmJson.ParseJson<DynamicColumnsAndRowsDto>();

            return View(vm);
        }
    }
}
