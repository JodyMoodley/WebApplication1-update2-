using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CheckOut
    {
        [Key]
        public int CheckInID { get; set; }
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }
        //public string UserName { get; set; }
        //public int GuestID { get; set; }
        //[ForeignKey("GuestID")]
        //public Guest Guest { get; set; }

        public int ReservationID { get; set; }
        [ForeignKey("ReservationID")]
        public RoomReservation RoomReservations { get; set; }
    }
}