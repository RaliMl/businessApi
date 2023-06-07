using GoodeBooks.Services.ServiceContracts.SaleInfos;
using GoodeBooks.Services.ViewModels.SaleInfos;
using GoodeBooks.Services.ViewModels.Volumes;
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
        public IActionResult GetById(string id)
        {
            return View(service.GetById(id));
        }
        public IActionResult Update(string id)
        {
            var saleInfo = service.GetById(id);
            return View("UpdateSaleInfo", saleInfo);
        }
        public IActionResult UpdateSaleInfo(SaleInfoViewModel model)
        {
            var res = service.Update(model);

            return View(model);
        }
        public IActionResult Delete(string id)
        {
            return View(service.Delete(id));
        }
    }
}
