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

        public IActionResult ShowSubs()
        {
            //AllSubViewModel model = new AllSubViewModel();
            //model.subs = _subsRepository.GetAllSubs();
            return View(_subsRepository.GetAllSubs());
        }
    }
}
