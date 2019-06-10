using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KickTask.Models
{
    [MetadataType(typeof(AccountMetaData))]
    public partial class Account
    {
        public string ConfirmPassword { get; set; }
    }

    public class AccountMetaData
    {
        [Display(Name = "Full Name")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "Fullname is required")]
        public string Fullname { get; set; }

        [Display(Name = "Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        [Display(Name = "Date of birth")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:MM.dd.YYYY}")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password of birth is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage ="Minimum 6 characters required")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm password and password do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Country")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Display(Name = "Usage Purpose")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Your purpose of usage is required")]
        public string UsagePurpose { get; set; }

        [Display(Name = "AgreedPolicy")]    
        public bool AgreedPolicy { get; set; }
    }
}