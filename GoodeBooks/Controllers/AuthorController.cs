using GoodeBooks.Services.ServiceContracts.Authors;
using GoodeBooks.Services.ViewModels.Authors;
using GoodeBooks.Services.ViewModels.SearchInfos;
using Microsoft.AspNetCore.Mvc;

namespace GoodeBooks.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService service;

        public AuthorController(IAuthorService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View("CreateNewAuthor");
        }
        public IActionResult CreateNewAuthor(AuthorCreateViewModel model)
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
        public IActionResult Update(string id)
        {
            var author = service.GetById(id);
            return View("UpdateAuthor", author);
        }
        public IActionResult UpdateAuthor(AuthorViewModel model)
        {
            var res = service.Update(model);

            return View(model);
        }
    }
}
