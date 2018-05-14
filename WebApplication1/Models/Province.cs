using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Province
    {
        [Key]
        public int ProvinceID { get; set; }

        [Required(ErrorMessage ="Please Enter a Province")]
        [Display(Name ="Province Name")]
         [RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
        [StringLength(maximumLength: 35, ErrorMessage = "Province name must be atleast 3 characters long", MinimumLength = 3)]
        public string ProvinceName { get; set; }
    }
}