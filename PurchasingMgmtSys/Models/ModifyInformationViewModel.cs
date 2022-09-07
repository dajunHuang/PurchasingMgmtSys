using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class ModifyInformationViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "New Email")]
        public string NewEmail { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Sex")]
        public string Sex
        {
            get; set;
        }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirm new Email")]
        [Compare("NewEmail", ErrorMessage = "The new Email and confirmation Email do not match.")]
        public string ConfirmEmail { get; set; }
    }
}
