using GoodeBooks.Services.ServiceContracts.SearchInfos;
using GoodeBooks.Services.ViewModels.SearchInfos;
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
    }
}
