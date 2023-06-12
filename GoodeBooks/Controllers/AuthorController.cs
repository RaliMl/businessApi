using GoodeBooks.Services.ServiceContracts.Authors;
using GoodeBooks.Services.ViewModels.Authors;
using GoodeBooks.Services.ViewModels.SearchInfos;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View("CreateNewAuthor");
        }        
        public IActionResult CreateNewAuthor(AuthorCreateViewModel model)
        {
            service.Create(model);
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult GetById(string id)
        {
            return View(service.GetById(id));
        }

        [Authorize(Roles ="Admin,User")]
        public IActionResult GetByName(string name)
        {
            return View(service.GetByName(name));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string id)
        {
            return View(service.Delete(id));
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Update(string id)
        {
            var author = service.GetById(id);
            return View("UpdateAuthor", author);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateAuthor(AuthorViewModel model)
        {
            var res = service.Update(model);

            return View(model);
        }
    }
}
