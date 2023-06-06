using GoodeBooks.Services.ServiceContracts.SaleInfos;
using GoodeBooks.Services.ViewModels.SaleInfos;
using Microsoft.AspNetCore.Mvc;

namespace GoodeBooks.Controllers
{
    public class SaleInfoController : Controller
    {
        private readonly ISaleInfoService service;

        public SaleInfoController(ISaleInfoService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateSaleInfo()
        {
            return View("CreateNewSaleInfo");
        }
        public IActionResult CreateNewSaleInfo(SaleInfoCreateViewModel model)
        {
            service.Create(model);
            return View(model);
        }
    }
}
