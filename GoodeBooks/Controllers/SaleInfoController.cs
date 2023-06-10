using GoodeBooks.Services.ServiceContracts.SaleInfos;
using GoodeBooks.Services.ViewModels.SaleInfos;
using GoodeBooks.Services.ViewModels.Volumes;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public IActionResult CreateSaleInfo()
        {
            return View("CreateNewSaleInfo");
        }
        public IActionResult CreateNewSaleInfo(SaleInfoCreateViewModel model)
        {
            service.Create(model);
            return View(model);
        }
        [Authorize(Roles = "Admin, User")]
        public IActionResult GetById(string id)
        {
            return View(service.GetById(id));
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string id)
        {
            return View(service.Delete(id));
        }
    }
}
