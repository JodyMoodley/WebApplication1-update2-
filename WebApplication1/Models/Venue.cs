using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Venue
    {
        [Key]
        public int VenueID { get; set; }
        [Required(ErrorMessage ="Please Enter The Venue Name")]
        [Display(Name = "Venue Name")]
        [RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
        [StringLength(maximumLength: 35, ErrorMessage = "Venue Name must be atleast 3 characters long", MinimumLength = 3)]
        public string VenueName { get; set; }

        [Display(Name = "Suburb")]
        public int SuburbID { get; set; }
        [ForeignKey("SuburbID")]
        public Suburb Suburb { get; set; }

        [Required(ErrorMessage = "Please Enter The Venue Address")]
        [Display(Name = "Venue Address")]
        [RegularExpression(pattern: @"^[a-zA-Z''-'\s]$", ErrorMessage = "special characters are not allowed.")]
        [StringLength(maximumLength: 40, ErrorMessage = "Venue address must be atleast 3 characters long", MinimumLength = 3)]
        public string VenueAddress { get; set; }
    }
}