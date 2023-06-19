using GoodeBooks.Database.Migrations;
using GoodeBooks.Services.ServiceContracts.SearchInfos;
using GoodeBooks.Services.ViewModels.SearchInfos;
using GoodeBooks.Services.ViewModels.Volumes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace GoodeBooks.Controllers
{
    public class SearchInfoController : Controller
    {
        private readonly ISearchInfoService service;

        public SearchInfoController(ISearchInfoService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string searchTerm, int pageNumber = 1)
        {
            return View("GetAll", service.Search(searchTerm).ToPagedList(pageNumber, 10));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateSearchInfo()
        {
            return View("CreateNewSearchInfo");
        }
        public IActionResult CreateNewSearchInfo(SearchInfoCreateViewModel model)
        {
            var id = service.Create(model);

            TempData["SearchInfoId"] = id;
            TempData.Keep("SearchInfoId");

            return View(model);
        }
        [Authorize(Roles = "Admin, User")]
        public IActionResult GetById(string id)
        {
            return View(service.GetById(id));
        }
        public IActionResult GetAll(int pageNumber = 1)
        {
            return View(service.GetAll().ToPagedList(pageNumber, 10));
        }
        public IActionResult NextPage(int currentPage)
        {

            // Calculate the next page number
            var nextPage = currentPage + 1;

            // Redirect to the new page
            return RedirectToAction("GetAll", new { pageNumber = nextPage });
        }

        public IActionResult PreviousPage(int currentPage)
        {
            // Calculate the previous page number
            var previousPage = currentPage - 1;

            // Redirect to the new page
            return RedirectToAction("GetAll", new { pageNumber = previousPage });
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string id)
        {
            return View(service.Delete(id));
        }
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateSearchInfo(string id)
        {
            var searchInfo = service.GetById(id);
            return View("Update", searchInfo);
        }
        public IActionResult Update(SearchInfoViewModel model)
        {
            var res = service.Update(model);

            return View(model);
        }
    }
}
