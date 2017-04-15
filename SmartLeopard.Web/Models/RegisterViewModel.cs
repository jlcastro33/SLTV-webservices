using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartLeopard.Web.Models
{
    public class RegisterViewModel
    {
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Resources.ModelLabels))]
        [Required(ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(Resources.LabelValidations))]
        public string Email { get; set; }

        // [StringLength(100, ErrorMessageResourceName = "PasswordStringLength", ErrorMessageResourceType = typeof(Resources.LabelValidations))]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.ModelLabels))]
        [Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(Resources.LabelValidations))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.ModelLabels))]
        [Compare("Password", ErrorMessageResourceName = "PasswordCompare", ErrorMessageResourceType = typeof(Resources.LabelValidations))]
        public string ConfirmPassword { get; set; }

        [Display(Name = "DeviceMac", ResourceType = typeof(Resources.ModelLabels))]
      //  [Required(ErrorMessageResourceName = "DeviceMacRequired", ErrorMessageResourceType = typeof(Resources.LabelValidations))]
        public string Mac { get; set; }

        public string Lang { get; set; }

        [Display(Name = "FirstName", ResourceType = typeof(Resources.ModelLabels))]
        [Required(ErrorMessageResourceName = "FirstNameRequired", ErrorMessageResourceType = typeof(Resources.LabelValidations))]
        public string Name { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(Resources.ModelLabels))]
        [Required(ErrorMessageResourceName = "LastNameRequired", ErrorMessageResourceType = typeof(Resources.LabelValidations))]
        public string Surname { get; set; }


        [Display(Name = "ZipCode", ResourceType = typeof(Resources.ModelLabels))]
        public string ZipCode { get; set; }

        [Display(Name = "CountryCode", ResourceType = typeof(Resources.ModelLabels))]
        public string CountryCode { get; set; }
    }
}