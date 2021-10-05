using System;
using AspNetCoreMvcWithLightVue.Infra;
using AspNetCoreMvcWithLightVue.Models;
using KueiExtensions.System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcWithLightVue.Controllers
{
    public class OrderOfferController : Controller
    {
        private readonly string _style1ViewModelKey = "ComplexViewModel1";

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Style1()
        {
            ViewBag.EmptyOrderDetailJson = new OrderDetailDto().ToJson();

            ViewBag.OrderItemsJson = GetOrderItems().ToJson();

            var orderDto = GetDefaultOrderDto();

            return View(orderDto);
        }

        [HttpPost]
        public IActionResult PostStyle1([FromBody]OrderOfferDto offerDto)
        {
            TempData[_style1ViewModelKey] = offerDto.ToJson();

            return Ok(offerDto);
        }

        [HttpPost]
        public IActionResult Calculate([FromBody]OrderOfferDto offerDto)
        {
            offerDto.SubTotal = 0;

            foreach (var detail in offerDto.Details)
            {
                detail.SumPrice   =  detail.Count * detail.UnitPrice;
                offerDto.SubTotal += detail.SumPrice;
            }

            offerDto.BusinessTax = offerDto.SubTotal * 0.05m;
            offerDto.Total       = offerDto.BusinessTax + offerDto.SubTotal;
            return Ok(offerDto);
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

            ViewBag.OrderItemsJson = GetOrderItems().ToJson();

            return View();
        }

        private SelectOptionItem<Guid>[] GetOrderItems()
        {
            return new[]
                   {
                       new SelectOptionItem<Guid> { Text = "A", Value = new Guid("A6B7381B-889C-4601-8619-B14A014B575A") },
                       new SelectOptionItem<Guid> { Text = "B", Value = new Guid("CC89577C-6730-4306-B98C-A055D4257FA0") },
                       new SelectOptionItem<Guid> { Text = "C", Value = new Guid("2E01C13B-1F76-4CC3-9072-816E471745AC") },
                       new SelectOptionItem<Guid> { Text = "D", Value = new Guid("405ED4F6-64EB-4AF7-8266-C8DCF6DDC733") },
                       new SelectOptionItem<Guid> { Text = "E", Value = new Guid("9BFE85E7-CB78-47BD-8B5D-A5EA2D3C3EB0") },
                   };
        }

        private static OrderOfferDto GetDefaultOrderDto()
        {
            return new OrderOfferDto
                   {
                       Guid        = null,
                       OrderDate   = "2021-08-01",
                       SubTotal    = null,
                       BusinessTax = null,
                       Total       = null,
                       Remark      = null,
                       Details = new OrderDetailDto[]
                                 {
                                     new()
                                     {
                                         Guid          = Guid.NewGuid(),
                                         OrderItemGuid = new Guid("A6B7381B-889C-4601-8619-B14A014B575A"),
                                         Count         = 1,
                                         UnitPrice     = 100,
                                         SumPrice      = 100,
                                         Comment       = "Comment1",
                                         Sort          = 1
                                     },
                                     new()
                                     {
                                         Guid          = Guid.NewGuid(),
                                         OrderItemGuid = new Guid("CC89577C-6730-4306-B98C-A055D4257FA0"),
                                         Count         = 2,
                                         UnitPrice     = 200,
                                         SumPrice      = 400,
                                         Comment       = "Comment2",
                                         Sort          = 2
                                     },
                                     new()
                                     {
                                         Guid          = Guid.NewGuid(),
                                         OrderItemGuid = new Guid("2E01C13B-1F76-4CC3-9072-816E471745AC"),
                                         Count         = 3,
                                         UnitPrice     = 300,
                                         SumPrice      = 900,
                                         Comment       = "Comment3",
                                         Sort          = 3
                                     },
                                 }
                   };
        }
    }
}
