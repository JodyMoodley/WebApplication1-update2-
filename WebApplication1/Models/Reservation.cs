using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Reservation
    {
        public int id { get; set; }

        public int UserID { get; set; }
        public string UserName { get; set; }

        public int RoomID { get; set; }

        public double TPirce { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CheckInDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CheckOutDate { get; set; }

        public double NONight { get; set; }

        public ApplicationUser ApplicationUsers { get; set; }

        public Room Room { get; set; }

        public bool bookingStatus { get; set; }

        //public double TCost() => Room.Price * NONight;


        //public bool calcStatus()
        //{
        //    if(TPirce != 0)
        //    {
        //        bookingStatus = true;
        //    }
        //    else
        //    {
        //        bookingStatus = false;
        //    }
        //    return bookingStatus;
        //}
    }
}