using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Subscription_Proj.Models
{
    //create 1 application DB CONTEXT 
    //inherit from identityDBcontext, this class contain both subsciption and users
    public class UserContext : IdentityDbContext<User>
    {
        public UserContext(DbContextOptions<UserContext>options):base(options)
        {

        }
    }
}
