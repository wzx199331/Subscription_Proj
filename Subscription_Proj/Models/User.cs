using Microsoft.AspNetCore.Identity;

namespace Subscription_Proj.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
