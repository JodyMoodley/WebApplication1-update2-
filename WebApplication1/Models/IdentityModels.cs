using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("HotelConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<WebApplication1.Models.Province> Provinces { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.City> Cities { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.Suburb> Suburbs { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.Venue> Venues { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.Room> Rooms { get; set; }
        public System.Data.Entity.DbSet<WebApplication1.Models.RoomReservation> RoomReservations { get; set; }
        public System.Data.Entity.DbSet<WebApplication1.Models.CheckIn> CheckIns { get; set; }
        public System.Data.Entity.DbSet<WebApplication1.Models.CheckOut> CheckOuts { get; set; }
        public System.Data.Entity.DbSet<WebApplication1.Models.Reservation> Reservations { get; set; }
        //public System.Data.Entity.DbSet<WebApplication1.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}