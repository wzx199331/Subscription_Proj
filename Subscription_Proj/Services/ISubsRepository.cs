using Subscription_Proj.Models;
using System.Collections.Generic;

namespace Subscription_Proj.Services
{
    public interface ISubsRepository
    {
        public List<SubscriptionInfo> GetAllSubs();
        public SubscriptionInfo GetSubscription(int id);
        public void AddSubscription(SubscriptionInfo subscriptionInfo);
        public void UpdateSubscription(SubscriptionInfo subscriptionInfo);
        public bool HasSub(int id);
        public bool DeleteSub(int id);
        public void UpdateUsedDays();
    }
}
