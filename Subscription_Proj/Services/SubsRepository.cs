using Subscription_Proj.Models;
using System.Collections.Generic;

namespace Subscription_Proj.Services
{
    public class SubsRepository : ISubsRepository
    {
        private List<SubscriptionInfo> _subscriptions;

        public SubsRepository()
        {
            _subscriptions = new List<SubscriptionInfo>();
            /*
            _subscriptions.Add(new SubscriptionInfo(0, "Netflix", 9.99, "Monthly"));
            _subscriptions.Add(new SubscriptionInfo(1, "Hulu", 12.99, "Monthly"));
            _subscriptions.Add(new SubscriptionInfo(2, "PS PLUS", 120.00, "Annualy"));
            */
        }
        public void AddSubscription(SubscriptionInfo subscriptionInfo)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteSub(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<SubscriptionInfo> GetAllSubs(string userId)
        {
            return _subscriptions;
        }

        public SubscriptionInfo GetSubscription(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool HasSub(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateSubscription(SubscriptionInfo subscriptionInfo)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUsedDays()
        {
            throw new System.NotImplementedException();
        }
    }
}
