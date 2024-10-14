using ChainOfResponsibilityDesingPattern.ChainOfResponsibility;
using ChainOfResponsibilityDesingPattern.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ChainOfResponsibilityDesingPattern.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            CustomerProcessViewModel model=new CustomerProcessViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            var treasurer = new Treasurer();
            var managerAsistant = new ManagerAssistant();
            var manager = new Manager();
            var areaDirectory = new AreaDirectör();

            treasurer.SetNextApprover(managerAsistant);
            managerAsistant.SetNextApprover(manager);
            manager.SetNextApprover(areaDirectory);

            model.Messages = treasurer.ProcessRequest(model) ?? new List<string>();

            return View(model);
        }
        
    }
}
