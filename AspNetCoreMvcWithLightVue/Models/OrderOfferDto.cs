using System;
using System.ComponentModel.DataAnnotations;
using AspNetCoreMvcWithLightVue.Infra;

namespace AspNetCoreMvcWithLightVue.Models
{
    /// <summary>
    /// 報價單
    /// </summary>
    public class OrderOfferDto
    {
        /// <summary>
        /// 報價單 Guid
        /// </summary>
        public Guid? Guid { get; set; }

        /// <summary>
        /// 報價日期
        /// </summary>
        [Display(Name = "報價日期")]
        [Required(ErrorMessage = "請填寫{0}")]
        public string OrderDate { get; set; }

        /// <summary>
        /// 小計
        /// </summary>
        [Display(Prompt = "小計")]
        [DecimalRange("0", "9999999999", ErrorMessage = "{0} 數值要介於 {2} 及 {1} 之間")]
        public decimal? SubTotal { get; set; }

        /// <summary>
        /// 加值營業稅
        /// </summary>
        [Display(Prompt = "加值營業稅")]
        [DecimalRange("0", "9999999999", ErrorMessage = "{0} 數值要介於 {2} 及 {1} 之間")]
        public decimal? BusinessTax { get; set; }

        /// <summary>
        /// 合計
        /// </summary>
        [Display(Prompt = "合計")]
        [DecimalRange("0", "9999999999", ErrorMessage = "{0} 數值要介於 {2} 及 {1} 之間")]
        public decimal? Total { get; set; }

        /// <summary>
        /// 註解
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 報價單項目
        /// </summary>
        public OrderDetailDto[] Details { get; set; }
    }

    /// <summary>
    /// 工服委託單報價項目
    /// </summary>
    public class OrderDetailDto
    {
        /// <summary>
        /// Guid
        /// </summary>
        public Guid? Guid { get; set; }

        /// <summary>
        /// 報價項目 Guid
        /// </summary>
        [Display(Name = "報價項目")]
        [Required(ErrorMessage = "請填寫{0}")]
        public Guid? OrderItemGuid { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        [Display(Prompt = "數量")]
        [Range(0, Int32.MaxValue, ErrorMessage = "{0} 要介於 {1} 及 {2} 之間")]
        public int? Count { get; set; }

        /// <summary>
        /// 單價
        /// </summary>
        [Display(Prompt = "單價")]
        [DecimalRange("0", "9999999999", ErrorMessage = "{0} 數值要介於 {2} 及 {1} 之間")]
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// 總價
        /// </summary>
        [Display(Prompt = "總價")]
        [DecimalRange("0", "9999999999", ErrorMessage = "{0} 數值要介於 {2} 及 {1} 之間")]
        public decimal? SumPrice { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Display(Prompt = "備註")]
        [StringLength(1000, ErrorMessage = "{0} 長度要介於 {2} 及 {1} 之間")]
        public string Comment { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name = "排序")]
        public int Sort { get; set; }
    }
}
