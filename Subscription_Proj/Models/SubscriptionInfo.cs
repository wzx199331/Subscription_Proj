using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Subscription_Proj.Models
{
    public enum Category {Streaming, Game, Music, News, Finance, SocialMedia, Education}
    public class SubscriptionInfo
    {
        public SubscriptionInfo()
        {
        }
        public SubscriptionInfo(int subscriptionId, string subscriptionName, double unitPrice, string subPeriod, string startDate, Category category)
        {
            SubscriptionId=subscriptionId;
            SubscriptionName=subscriptionName;
            UnitPrice=unitPrice;
            SubPeriod=subPeriod;
            StartDate=startDate;
            this.category = category;
            daysUsed = updateDaysUsed();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubscriptionId { get; set; }

        public string userId { get; set; }
        public string SubscriptionName { get; set; }
        public Category category { get; set; }
        public double UnitPrice { get; set; }
        public string SubPeriod { get; set; }

        [DataType(DataType.Date)]
        public string StartDate { get; set; }

        public string daysUsed { get; set; }

        public string updateDaysUsed()
        {
            DateTime today = DateTime.Today;
            DateTime started = DateTime.Parse(StartDate);
            return (today - started).TotalDays.ToString();
        }
        
    }
}
