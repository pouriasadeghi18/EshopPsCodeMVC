using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer
{

    public class ProductMetaData
    {
        [Key]
        public int ProductID { get; set; }

        [Display(Name = "عنوان ")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        public string Title { get; set; }
        [Display(Name = "توضیح کوتاه")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(500,ErrorMessage = "تعداد کاراکتر {0} بیش از 500 است" )]
        [DataType(DataType.MultilineText)]
        public string ShortDiscraption { get; set; }
        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Text { get; set; }
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        
        public int Price { get; set; }
        [Display(Name = "تاریخ")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public System.DateTime CreateTime { get; set; }
        [Display(Name = "عکس")]
        public string ImageName { get; set; }
    }

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {

    }
}
