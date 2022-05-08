using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Product_GalleriesMetaData
    {
        [Key]
        public int GalleryId { get; set; }
        [Display(Name = "کالا")]

        public int ProductID { get; set; }
        [Display(Name = "عکس")]
      
        public string ImageName { get; set; }
 
     
      

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        public string Title { get; set; }
    }

    [MetadataType(typeof(Product_GalleriesMetaData))]
    public partial class Product_Gallery
    {

    }
}
