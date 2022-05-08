using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.MetadataServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class RoleMetaData
    {
        [Key]
        [Display(Name = "نقش کاربر")]
        public int RoleID { get; set; }
        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        public string RoleTitle { get; set; }

        [Display(Name = "نام نقش")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]


        public string RoleName { get; set; }
    }
    [MetadataType(typeof(RoleMetaData))]
    public partial class Role
    {

    }
}
