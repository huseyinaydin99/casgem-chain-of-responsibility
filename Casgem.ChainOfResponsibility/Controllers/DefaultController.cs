using Casgem.ChainOfResponsibility.ChainOfResponsibilityPattern;
using Microsoft.AspNetCore.Mvc;

namespace Casgem.ChainOfResponsibility.Controllers
{
    //.
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            EmployeeBase treasurer = new Treassurer();
            EmployeeBase managerAssistant = new ManagerAssistant();
            EmployeeBase manager = new Manager();
            EmployeeBase areaDirector = new AreaDirector();
            treasurer.SetNextApprover(managerAssistant);
            managerAssistant.SetNextApprover(manager);
            manager.SetNextApprover(areaDirector); //bölge müdürü zincirin son halkası en babası.

            treasurer.ProcessRequest(model);
            return View();
        }
    }
}
