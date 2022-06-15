using Subscription_Proj.Models;
using System.Collections.Generic;

namespace Subscription_Proj.Services
{
    public class DBSubscription : ISubsRepository
    {
        private SubscriptionInfoContext subscriptionInfoContext;
        public DBSubscription(SubscriptionInfoContext subscriptionInfoContext)
        {
            this.subscriptionInfoContext = subscriptionInfoContext;
        }
        public void AddSubscription(SubscriptionInfo subscriptionInfo)
        {
            subscriptionInfoContext.Subscriptions.Add(subscriptionInfo);
            subscriptionInfoContext.SaveChanges();
        }

        public bool DeleteSub(int id)
        {
            var sub = subscriptionInfoContext.Subscriptions.Find(id);
            if(sub != null)
            {
                subscriptionInfoContext.Subscriptions.Remove(sub);
                subscriptionInfoContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<SubscriptionInfo> GetAllSubs()
        {
            return new List<SubscriptionInfo>(subscriptionInfoContext.Subscriptions);
        }

        public SubscriptionInfo GetSubscription(int id)
        {
            var sub = subscriptionInfoContext.Subscriptions.Find(id);
            return sub != null ? sub : null;
        }

        public bool HasSub(int id)
        {
            return subscriptionInfoContext.Subscriptions.Find(id) != null;
        }

        public void UpdateSubscription(SubscriptionInfo subscriptionInfo)
        {
            var sub = subscriptionInfoContext.Subscriptions.Find(subscriptionInfo.SubscriptionId);
            sub.SubscriptionName = subscriptionInfo.SubscriptionName;
            sub.UnitPrice = subscriptionInfo.UnitPrice;
            sub.SubPeriod = subscriptionInfo.SubPeriod;
            subscriptionInfoContext.SaveChanges();
        }
    }
}
