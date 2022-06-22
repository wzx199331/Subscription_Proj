using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Subscription_Proj.Models;
using Subscription_Proj.Services;
namespace Subscription_Proj.Controllers
{
    public class SubsController : Controller
    {
        private ISubsRepository _subsRepository;

        public SubsController(ISubsRepository subsRepository)
        {
            _subsRepository = subsRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Customer")]
        public IActionResult ShowSubs()
        {
            //AllSubViewModel model = new AllSubViewModel();
            //model.subs = _subsRepository.GetAllSubs();
            _subsRepository.UpdateUsedDays();
            return View(_subsRepository.GetAllSubs());
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        public IActionResult Edit(int Id)
        {
            return View(_subsRepository.GetSubscription(Id));
        }

        [HttpPost]
        public RedirectToActionResult Edit(SubscriptionInfo subscriptionInfo)
        {
            _subsRepository.UpdateSubscription(subscriptionInfo);
            return RedirectToAction("ShowSubs");
        }

        [Authorize(Roles = "Customer")]
        public IActionResult Details(int Id)
        {
            return View(_subsRepository.GetSubscription(Id));
        }

        [Authorize(Roles = "Customer")]
        public RedirectToActionResult Delete(int Id)
        {
            _subsRepository.DeleteSub(Id);
            return RedirectToAction("ShowSubs");
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SubscriptionInfo subscriptionInfo)
        {
            if(ModelState.IsValid)
            {
                _subsRepository.AddSubscription(subscriptionInfo);
                ViewBag.Message = "New Subscription Added";
            }
            return View(subscriptionInfo);
        }

    }
}
