using Microsoft.AspNetCore.Identity;

namespace Calend.Models
{
    public class AppUser: IdentityUser
    {
        public virtual ICollection<Event> Events { get; set; }  
    }
}
