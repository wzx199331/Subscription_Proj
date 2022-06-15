using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Subscription_Proj.Models
{
    public class SubscriptionInfo
    {
        public SubscriptionInfo(int subscriptionId, string subscriptionName, double unitPrice, string subPeriod)
        {
            SubscriptionId=subscriptionId;
            SubscriptionName=subscriptionName;
            UnitPrice=unitPrice;
            SubPeriod=subPeriod;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubscriptionId { get; set; }
        public string SubscriptionName { get; set; }
        public double UnitPrice { get; set; }
        public string SubPeriod { get; set; }
    }
}
