using Subscription_Proj.Models;
using System.Collections.Generic;
using System.Linq;

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
            //subscriptionInfo.SubscriptionId = subscriptionInfoContext.Subscriptions.Count() + 1;
            
            subscriptionInfoContext.Subscriptions.Add(subscriptionInfo);
            subscriptionInfoContext.SaveChanges();
        }

        public bool DeleteSub(int id)
        {
            var sub = (from SubscriptionInfo in subscriptionInfoContext.Subscriptions
                       where SubscriptionInfo.SubscriptionId == id
                       select SubscriptionInfo).ToList();

            if(sub != null)
            {
                subscriptionInfoContext.Subscriptions.Remove(sub[0]);
                subscriptionInfoContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<SubscriptionInfo> GetAllSubs(string userId)
        {
            var subList = (from SubscriptionInfo in subscriptionInfoContext.Subscriptions
                           where SubscriptionInfo.userId == userId
                           select SubscriptionInfo
                           ).ToList();
            UpdateUsedDays();
            return subList;
        }

        public SubscriptionInfo GetSubscription(int id)
        {
            var sub = (from SubscriptionInfo in subscriptionInfoContext.Subscriptions
                       where SubscriptionInfo.SubscriptionId == id
                       select SubscriptionInfo).ToList();
            return sub[0];
        }

        public bool HasSub(int id)
        {
            var sub = (from SubscriptionInfo in subscriptionInfoContext.Subscriptions
                       where SubscriptionInfo.SubscriptionId == id
                       select SubscriptionInfo).ToList();
            return sub != null;
        }

        public void UpdateSubscription(SubscriptionInfo subscriptionInfo)
        {
            /*
            var subs = (from SubscriptionInfo in subscriptionInfoContext.Subscriptions
                       where SubscriptionInfo.SubscriptionId == subscriptionInfo.SubscriptionId
                       select SubscriptionInfo).ToList();
            */
            var sub = subscriptionInfoContext.Subscriptions.Find(subscriptionInfo.SubscriptionId);
            //sub.SubscriptionId = subscriptionInfo.SubscriptionId;
            sub.SubscriptionName = subscriptionInfo.SubscriptionName;
            sub.UnitPrice = subscriptionInfo.UnitPrice;
            sub.SubPeriod = subscriptionInfo.SubPeriod;
            sub.StartDate = subscriptionInfo.StartDate;
            sub.daysUsed = subscriptionInfo.updateDaysUsed();
            sub.userId = subscriptionInfo.userId;
            subscriptionInfoContext.SaveChanges();
        }

        public void UpdateUsedDays()
        {
            foreach (SubscriptionInfo s in subscriptionInfoContext.Subscriptions)
               s.daysUsed = s.updateDaysUsed();
            subscriptionInfoContext.SaveChanges();
        }
    }
}
