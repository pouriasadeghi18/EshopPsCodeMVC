using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class RegisterViewModel
    {


        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]

        public string Email { get; set; }
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه عبور یکسان نیستند")]
        public string RePassword { get; set; }




    }
    public class LoginViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        public string Email { get; set; }
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "مرا بخاطر بسپار")]
        public bool RememberMe { get; set; }
    }

    public class ForGetPassWordViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        public string Email { get; set; }
    }

    public class ChangePassWordViewModel
    {
        [Display(Name = "کلمه عبور قبلی")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Display(Name = "کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "تکرار کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه عبور یکسان نیستند")]
        public string RePassword { get; set; }

    }
    public class RecoveryPassword
    {
        [Display(Name = "کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "تکرار کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه عبور یکسان نیستند")]
        public string RePassword { get; set; }
    }
}
