using Microsoft.AspNetCore.Identity;

namespace MovieReservationAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Additional profile data
        public string Name { get; set; }
    }
}
