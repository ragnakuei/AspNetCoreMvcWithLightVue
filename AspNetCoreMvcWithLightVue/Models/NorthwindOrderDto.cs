using System;
using KueiExtensions;

namespace AspNetCoreMvcWithLightVue.Models
{
    public class NorthwindOrderDto
    {
        public int?   OrderID    { get; set; }
        public string CustomerID { get; set; }
        public int?   EmployeeID { get; set; }

        public string OrderDate    { get; set; }
        public string RequiredDate { get; set; }
        public string ShippedDate  { get; set; }
    }
}
