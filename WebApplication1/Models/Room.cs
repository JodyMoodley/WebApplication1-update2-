using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
       
        [Required(ErrorMessage ="Please Enter Room Price")]
        [Display(Name ="Room Price")]
        [DataType(DataType.Currency)]
        public double RoomPrice { get; set; }

        [Display(Name = "Room Type")]
        [RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
        [StringLength(maximumLength: 35, ErrorMessage = "Room type must be atleast 3 characters long", MinimumLength = 3)]
        public string RoomType { get; set; }

        //public string UserName { get; set; }
        [Display(Name = "Bed Size")]
        [RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
        [StringLength(maximumLength: 35, ErrorMessage = "Bed size must be atleast 3 characters long", MinimumLength = 3)]
        public string BedSize { get; set; }

        //[DataType(DataType.Date)]
        //public DateTime? CheckInDate { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime? CheckOutDate { get; set; }

        //public double? NONights { get; set; }

        //public bool Status { get; set; }

        [Display(Name = "Venue")]
        public int VenueID { get; set; }
        [ForeignKey("VenueID")]
        public Venue Venue { get; set; }
        public virtual ICollection<RoomReservation> RoomReservations { get; set; }
        //public ApplicationUser ApplicationUsers { get; set; }
    }
}