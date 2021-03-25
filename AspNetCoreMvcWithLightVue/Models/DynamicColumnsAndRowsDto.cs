using System.Collections.Generic;

namespace AspNetCoreMvcWithLightVue.Models
{
    public class DynamicColumnsAndRowsDto
    {
        public string[] Columns { get; set; }

        public IEnumerable<NorthwindOrderDto> Orders { get; set; }
    }
}
