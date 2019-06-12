using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KickTask.Models.Extendet
{
    public class AccountLogin
    {
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}