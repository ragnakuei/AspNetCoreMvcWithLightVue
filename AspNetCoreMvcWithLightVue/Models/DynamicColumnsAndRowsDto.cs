using System.Collections.Generic;

namespace AspNetCoreMvcWithLightVue.Models
{
    public class DynamicColumnsAndRowsDto
    {
        /// <summary>
        /// 顯示的 Column Names
        /// </summary>
        public string[] Columns { get; set; }

        /// <summary>
        /// 顯示的資料
        /// </summary>
        public IEnumerable<NorthwindOrderDto> Orders { get; set; }
    }
}
