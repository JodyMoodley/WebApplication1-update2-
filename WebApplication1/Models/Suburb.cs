using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Suburb
    {
        [Key]
        public int SuburbID { get; set; }

        [Required(ErrorMessage ="Please Enter a Suburb")]
        [Display(Name = "Suburb Name")]
        [RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
        [StringLength(maximumLength: 35, ErrorMessage = "Suburb Name must be atleast 3 characters long", MinimumLength = 3)]
        public string SuburbName { get; set; }


        [Display(Name = "City")]
        public int CityID { get; set; }
        [ForeignKey("CityID")]
        public City City { get; set; }
    }
}