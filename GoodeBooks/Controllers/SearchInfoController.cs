using GoodeBooks.Services.ServiceContracts.SearchInfos;
using GoodeBooks.Services.ViewModels.SearchInfos;
using GoodeBooks.Services.ViewModels.Volumes;
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

        public IActionResult CreateSearchInfo()
        {
            return View("CreateNewSearchInfo");
        }
        public IActionResult CreateNewSearchInfo(SearchInfoCreateViewModel model)
        {
            service.Create(model);
            return View(model);
        }
        public IActionResult GetById(string id)
        {
            return View(service.GetById(id));
        }
        public IActionResult Delete(string id)
        {
            return View(service.Delete(id));
        }
        public IActionResult UpdateSearchInfo(string id)
        {
            var searchInfo = service.GetById(id);
            return View("Update", searchInfo);
        }
        public IActionResult Update(string id, SearchInfoGetViewModel model)
        {
            var res = service.Update(id, model);

            return View(model);
        }
    }
}
