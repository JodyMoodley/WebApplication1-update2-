using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        [Required(ErrorMessage ="Please Enter a City Name")]
        [RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
        [StringLength(maximumLength: 35, ErrorMessage = "City Name must be atleast 3 characters long", MinimumLength = 3)]
        [Display(Name = "City Name")]
        public string CityName { get; set; }

        [Display(Name = "Province")]
        public int ProvinceID { get; set; }
        [ForeignKey("ProvinceID")]
        public Province Province { get; set; }
    }
}