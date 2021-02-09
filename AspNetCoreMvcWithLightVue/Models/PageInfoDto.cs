using System.Text.Json.Serialization;
using AspNetCoreMvcWithLightVue.Controllers;

namespace AspNetCoreMvcWithLightVue.Models
{
    public class PageInfoDto
    {
        /// <summary>
        ///     頁碼
        /// </summary>
        public int PageNo { get; set; }

        /// <summary>
        ///     一頁筆數
        /// </summary>
        public int OnePageCount { get; set; }

        /// <summary>
        ///     總頁數
        /// </summary>
        public int PageCount
        {
            get
            {
                if (DataCount % OnePageCount == 0)
                {
                    return DataCount / OnePageCount;
                }

                return (DataCount / OnePageCount) + 1;
            }
        }

        /// <summary>
        ///     資料總筆數
        /// </summary>
        public int DataCount { get; set; }

        /// <summary>
        ///     排序欄位
        /// </summary>
        public string SortColumn { get; set; }

        /// <summary>
        ///     前端決定的要排序的欄位
        /// </summary>
        public string ClickSortColumn { get; set; }

        /// <summary>
        ///     排序欄位順序
        /// </summary>
        public SortColumnOrder SortColumnOrder { get; set; } = SortColumnOrder.Asc;

        /// <summary>
        ///     要略過的筆數
        /// </summary>
        [JsonIgnore]
        public int Skip => (PageNo - 1) * OnePageCount;
    }
}
