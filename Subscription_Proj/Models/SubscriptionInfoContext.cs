using Microsoft.EntityFrameworkCore;

namespace Subscription_Proj.Models
{
    public class SubscriptionInfoContext : DbContext
    {
        public SubscriptionInfoContext(DbContextOptions<SubscriptionInfoContext> options):base(options)
        {

        }

        public DbSet<SubscriptionInfo> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubscriptionInfo>().HasData(
                new SubscriptionInfo(0, "Netflix", 9.99, "Monthly","2016-05-01", Category.Streaming),
                new SubscriptionInfo(1, "Hulu", 12.99, "Monthly", "2018-07-29", Category.Streaming),
                new SubscriptionInfo(2, "PS PLUS", 120.00, "Annualy", "2022-01-01", Category.Game)
                );
        }
    }
}
