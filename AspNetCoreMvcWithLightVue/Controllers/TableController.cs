using System.Collections.Generic;
using System.Linq;
using AspNetCoreMvcWithLightVue.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcWithLightVue.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Style1()
        {
            return View();
        }

        public IActionResult Style2()
        {
            return View();
        }

        private readonly Dto[] _data = new[]
                                       {
                                           new Dto { Id = 1, Name   = "Name001", Age = 21, },
                                           new Dto { Id = 2, Name   = "Name002", Age = 22, },
                                           new Dto { Id = 3, Name   = "Name003", Age = 23, },
                                           new Dto { Id = 4, Name   = "Name004", Age = 24, },
                                           new Dto { Id = 5, Name   = "Name005", Age = 25, },
                                           new Dto { Id = 6, Name   = "Name006", Age = 26, },
                                           new Dto { Id = 7, Name   = "Name007", Age = 27, },
                                           new Dto { Id = 8, Name   = "Name008", Age = 28, },
                                           new Dto { Id = 9, Name   = "Name009", Age = 29, },
                                           new Dto { Id = 10, Name  = "Name010", Age = 30, },
                                           new Dto { Id = 11, Name  = "Name011", Age = 31, },
                                           new Dto { Id = 12, Name  = "Name012", Age = 32, },
                                           new Dto { Id = 13, Name  = "Name013", Age = 33, },
                                           new Dto { Id = 14, Name  = "Name014", Age = 34, },
                                           new Dto { Id = 15, Name  = "Name015", Age = 35, },
                                           new Dto { Id = 16, Name  = "Name016", Age = 36, },
                                           new Dto { Id = 17, Name  = "Name017", Age = 37, },
                                           new Dto { Id = 18, Name  = "Name018", Age = 38, },
                                           new Dto { Id = 19, Name  = "Name019", Age = 39, },
                                           new Dto { Id = 20, Name  = "Name020", Age = 40, },
                                           new Dto { Id = 21, Name  = "Name021", Age = 41, },
                                           new Dto { Id = 22, Name  = "Name022", Age = 42, },
                                           new Dto { Id = 23, Name  = "Name023", Age = 43, },
                                           new Dto { Id = 24, Name  = "Name024", Age = 44, },
                                           new Dto { Id = 25, Name  = "Name025", Age = 45, },
                                           new Dto { Id = 26, Name  = "Name026", Age = 46, },
                                           new Dto { Id = 27, Name  = "Name027", Age = 47, },
                                           new Dto { Id = 28, Name  = "Name028", Age = 48, },
                                           new Dto { Id = 29, Name  = "Name029", Age = 49, },
                                           new Dto { Id = 30, Name  = "Name030", Age = 50, },
                                           new Dto { Id = 31, Name  = "Name031", Age = 51, },
                                           new Dto { Id = 32, Name  = "Name032", Age = 52, },
                                           new Dto { Id = 33, Name  = "Name033", Age = 53, },
                                           new Dto { Id = 34, Name  = "Name034", Age = 54, },
                                           new Dto { Id = 35, Name  = "Name035", Age = 55, },
                                           new Dto { Id = 36, Name  = "Name036", Age = 56, },
                                           new Dto { Id = 37, Name  = "Name037", Age = 57, },
                                           new Dto { Id = 38, Name  = "Name038", Age = 58, },
                                           new Dto { Id = 39, Name  = "Name039", Age = 59, },
                                           new Dto { Id = 40, Name  = "Name040", Age = 60, },
                                           new Dto { Id = 41, Name  = "Name041", Age = 61, },
                                           new Dto { Id = 42, Name  = "Name042", Age = 62, },
                                           new Dto { Id = 43, Name  = "Name043", Age = 63, },
                                           new Dto { Id = 44, Name  = "Name044", Age = 64, },
                                           new Dto { Id = 45, Name  = "Name045", Age = 65, },
                                           new Dto { Id = 46, Name  = "Name046", Age = 66, },
                                           new Dto { Id = 47, Name  = "Name047", Age = 67, },
                                           new Dto { Id = 48, Name  = "Name048", Age = 68, },
                                           new Dto { Id = 49, Name  = "Name049", Age = 69, },
                                           new Dto { Id = 50, Name  = "Name050", Age = 70, },
                                           new Dto { Id = 51, Name  = "Name051", Age = 71, },
                                           new Dto { Id = 52, Name  = "Name052", Age = 72, },
                                           new Dto { Id = 53, Name  = "Name053", Age = 73, },
                                           new Dto { Id = 54, Name  = "Name054", Age = 74, },
                                           new Dto { Id = 55, Name  = "Name055", Age = 75, },
                                           new Dto { Id = 56, Name  = "Name056", Age = 76, },
                                           new Dto { Id = 57, Name  = "Name057", Age = 77, },
                                           new Dto { Id = 58, Name  = "Name058", Age = 78, },
                                           new Dto { Id = 59, Name  = "Name059", Age = 79, },
                                           new Dto { Id = 60, Name  = "Name060", Age = 80, },
                                           new Dto { Id = 61, Name  = "Name061", Age = 81, },
                                           new Dto { Id = 62, Name  = "Name062", Age = 82, },
                                           new Dto { Id = 63, Name  = "Name063", Age = 83, },
                                           new Dto { Id = 64, Name  = "Name064", Age = 84, },
                                           new Dto { Id = 65, Name  = "Name065", Age = 85, },
                                           new Dto { Id = 66, Name  = "Name066", Age = 86, },
                                           new Dto { Id = 67, Name  = "Name067", Age = 87, },
                                           new Dto { Id = 68, Name  = "Name068", Age = 88, },
                                           new Dto { Id = 69, Name  = "Name069", Age = 89, },
                                           new Dto { Id = 70, Name  = "Name070", Age = 90, },
                                           new Dto { Id = 71, Name  = "Name071", Age = 91, },
                                           new Dto { Id = 72, Name  = "Name072", Age = 92, },
                                           new Dto { Id = 73, Name  = "Name073", Age = 93, },
                                           new Dto { Id = 74, Name  = "Name074", Age = 94, },
                                           new Dto { Id = 75, Name  = "Name075", Age = 95, },
                                           new Dto { Id = 76, Name  = "Name076", Age = 96, },
                                           new Dto { Id = 77, Name  = "Name077", Age = 97, },
                                           new Dto { Id = 78, Name  = "Name078", Age = 98, },
                                           new Dto { Id = 79, Name  = "Name079", Age = 99, },
                                           new Dto { Id = 80, Name  = "Name080", Age = 100, },
                                           new Dto { Id = 81, Name  = "Name081", Age = 101, },
                                           new Dto { Id = 82, Name  = "Name082", Age = 102, },
                                           new Dto { Id = 83, Name  = "Name083", Age = 103, },
                                           new Dto { Id = 84, Name  = "Name084", Age = 104, },
                                           new Dto { Id = 85, Name  = "Name085", Age = 105, },
                                           new Dto { Id = 86, Name  = "Name086", Age = 106, },
                                           new Dto { Id = 87, Name  = "Name087", Age = 107, },
                                           new Dto { Id = 88, Name  = "Name088", Age = 108, },
                                           new Dto { Id = 89, Name  = "Name089", Age = 109, },
                                           new Dto { Id = 90, Name  = "Name090", Age = 110, },
                                           new Dto { Id = 91, Name  = "Name091", Age = 111, },
                                           new Dto { Id = 92, Name  = "Name092", Age = 112, },
                                           new Dto { Id = 93, Name  = "Name093", Age = 113, },
                                           new Dto { Id = 94, Name  = "Name094", Age = 114, },
                                           new Dto { Id = 95, Name  = "Name095", Age = 115, },
                                           new Dto { Id = 96, Name  = "Name096", Age = 116, },
                                           new Dto { Id = 97, Name  = "Name097", Age = 117, },
                                           new Dto { Id = 98, Name  = "Name098", Age = 118, },
                                           new Dto { Id = 99, Name  = "Name099", Age = 119, },
                                           new Dto { Id = 100, Name = "Name100", Age = 120, },
                                       };


        [HttpPost, Route("api/[Controller]/[Action]")]
        public IActionResult GetDataTable([FromBody]PageInfoDto pageInfoDto)
        {
            pageInfoDto ??= new PageInfoDto
                            {
                                PageNo          = 1,
                                OnePageCount    = 10,
                                SortColumn      = "Id",
                                ClickSortColumn = "Id",
                                SortColumnOrder = SortColumnOrder.Desc
                            };

            pageInfoDto.DataCount = _data.Length;

            // 前端排序整理
            if (string.IsNullOrWhiteSpace(pageInfoDto.ClickSortColumn) == false)
            {
                if (pageInfoDto.SortColumn == pageInfoDto.ClickSortColumn)
                {
                    if (pageInfoDto.SortColumnOrder == SortColumnOrder.Asc)
                    {
                        pageInfoDto.SortColumnOrder = SortColumnOrder.Desc;
                    }
                    else
                    {
                        pageInfoDto.SortColumnOrder = SortColumnOrder.Asc;
                    }
                }
                else
                {
                    pageInfoDto.SortColumn      = pageInfoDto.ClickSortColumn;
                    pageInfoDto.SortColumnOrder = SortColumnOrder.Asc;
                }

                pageInfoDto.ClickSortColumn = string.Empty;
            }

            IEnumerable<Dto> result = _data;

            if (pageInfoDto.SortColumnOrder == SortColumnOrder.Asc)
            {
                if (pageInfoDto.SortColumn == "Id")
                {
                    result = result.OrderBy(r => r.Id);
                }
                else if (pageInfoDto.SortColumn == "Name")
                {
                    result = result.OrderBy(r => r.Name);
                }
                else if (pageInfoDto.SortColumn == "Age")
                {
                    result = result.OrderBy(r => r.Age);
                }
            }
            else
            {
                if (pageInfoDto.SortColumn == "Id")
                {
                    result = result.OrderByDescending(r => r.Id);
                }
                else if (pageInfoDto.SortColumn == "Name")
                {
                    result = result.OrderByDescending(r => r.Name);
                }
                else if (pageInfoDto.SortColumn == "Age")
                {
                    result = result.OrderByDescending(r => r.Age);
                }
            }

            result = result.Skip(pageInfoDto.Skip).Take(pageInfoDto.PageCount);

            return Ok(new
                      {
                          PageInfo = pageInfoDto,
                          Data     = result
                      });
        }
    }
}
