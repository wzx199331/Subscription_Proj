using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Subscription_Proj.Models
{
    public enum Category {Streaming, Game, Music, News, Finance, SocialMedia, Education, Fitness}
    public enum SubPeriod { Weekly, BiWeekly, Monthly, SemiAnnual, Annualy, BiAnnualy}
    public class SubscriptionInfo
    {
        public SubscriptionInfo()
        {
        }
        public SubscriptionInfo(string subscriptionName, double unitPrice, string subPeriod, string startDate, Category category)
        {
            SubscriptionName=subscriptionName;
            UnitPrice=unitPrice;
            SubPeriod=subPeriod;
            StartDate=startDate;
            this.category = category;
            daysUsed = updateDaysUsed();
        }

        [Key]
        [Display(Name = "Subscription Id")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubscriptionId { get; set; }

        [Display(Name = "User Id")]
        public string userId { get; set; }

        [Display(Name = "Subscription Name")]
        public string SubscriptionName { get; set; }

        [Display(Name = "Category")]
        public Category category { get; set; }

        [DataType(DataType.Currency)]
        public double UnitPrice { get; set; }
        public string SubPeriod { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }

        [Display(Name = "Days used")]
        public string daysUsed { get; set; }

        public string updateDaysUsed()
        {
            DateTime today = DateTime.Today;
            DateTime started = DateTime.Parse(StartDate);
            return (today - started).TotalDays.ToString();
        }
        
    }
}
