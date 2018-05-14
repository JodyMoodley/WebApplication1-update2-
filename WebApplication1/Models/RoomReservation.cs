using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RoomReservation
    {
        [Key]
        public int RR_ID { get; set; }
        public int RoomID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CheckIn { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CheckOut { get; set; }

        public double? Bill { get; set; }
        public string BookingStatus { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ACheckIn { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ACheckOut { get; set; }
        public virtual Room Rooms { get; set; }
        public virtual ApplicationUser ApplicationUsers { get; set; }

        //public double calcCost()
        //{
        //    Bill = Rooms.RoomPrice;
        //    return Bill;
        //}

        public string calcStatus()
        {
            if (ACheckIn != null)
            {
                BookingStatus = "Booked";
            }
            else
            {
                BookingStatus = "Available";
            }
            return BookingStatus;
        }

    }
}