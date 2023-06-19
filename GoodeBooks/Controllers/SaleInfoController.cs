using GoodeBooks.Services.ServiceContracts.SaleInfos;
using GoodeBooks.Services.ViewModels.SaleInfos;
using GoodeBooks.Services.ViewModels.Volumes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;

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

        [Authorize(Roles = "Admin,User")]
        public IActionResult Search(string searchTerm, int pageNumber = 1)
        {
            return View("GetAll", service.Search(searchTerm).ToPagedList(pageNumber, 10));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateSaleInfo()
        {
            return View("CreateNewSaleInfo");
        }
        public IActionResult CreateNewSaleInfo(SaleInfoCreateViewModel model)
        {
            var id = service.Create(model);

            TempData["SaleInfoId"] = id;
            TempData.Keep("SaleInfoId");

            return View(model);
        }
        [Authorize(Roles = "Admin, User")]
        public IActionResult GetById(string id)
        {
            return View(service.GetById(id));
        }
        [Authorize(Roles = "Admin,User")]
        public IActionResult GetAll(int pageNumber = 1)
        {
            return View(service.GetAll().ToPagedList(pageNumber, 10));
        }
        public IActionResult NextPage(int currentPage)
        {
            var nextPage = currentPage + 1;

            return RedirectToAction("GetAll", new { pageNumber = nextPage });
        }

        public IActionResult PreviousPage(int currentPage)
        {
            var previousPage = currentPage - 1;

            return RedirectToAction("GetAll", new { pageNumber = previousPage });
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
