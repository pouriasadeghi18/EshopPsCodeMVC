using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class UserMetaData
    {
        [Key]
 
        public int UserID { get; set; }       
        
        
        [Display(Name = "نقش کاربر")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        
        public int RoleID { get; set; }

        [Display(Name = "نام کاربر")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "کد فعال سازی")]
        
        public string ActiveCode { get; set; }

        [Display(Name = "فعال")]
        public bool IsActive { get; set; }

        [Display(Name = "تاریخ")]
        public System.DateTime RegisterDate { get; set; }

        public virtual Role Role { get; set; }
    }


    [MetadataType(typeof(UserMetaData))]
    public partial class Users
    {

    }
}
