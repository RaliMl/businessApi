using GoodeBooks.Database.Migrations;
using GoodeBooks.Services.ServiceContracts.SearchInfos;
using GoodeBooks.Services.ViewModels.SearchInfos;
using GoodeBooks.Services.ViewModels.Volumes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [Authorize(Roles = "Admin")]
        public IActionResult CreateSearchInfo()
        {
            return View("CreateNewSearchInfo");
        }
        public IActionResult CreateNewSearchInfo(SearchInfoCreateViewModel model)
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
