using System;
using KueiExtensions;

namespace AspNetCoreMvcWithLightVue.Models
{
    public class NorthwindOrderDto
    {
        private string _dateTimeToStringFormat = "yyyy-MM-dd";
        private string _dateTimeFromDbFormat   = "MM/dd/yyyy hh:mm:ss";

        public int?   OrderID    { get; set; }
        public string CustomerID { get; set; }
        public int?   EmployeeID { get; set; }

        public string OrderDate    { get; set; }
        public string RequiredDate { get; set; }
        public string ShippedDate  { get; set; }

        public int?     ShipVia        { get; set; }
        public decimal? Freight        { get; set; }
        public string   ShipName       { get; set; }
        public string   ShipAddress    { get; set; }
        public string   ShipCity       { get; set; }
        public string   ShipRegion     { get; set; }
        public string   ShipPostalCode { get; set; }
        public string   ShipCountry    { get; set; }
    }
}
