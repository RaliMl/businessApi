using GoodeBooks.Services.ServiceContracts.Authors;
using GoodeBooks.Services.ViewModels.Authors;
using GoodeBooks.Services.ViewModels.SearchInfos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;

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

        [Authorize(Roles = "Admin,User")]
        public IActionResult Search(string searchTerm, int pageNumber = 1)
        {
            return View("GetAll", service.Search(searchTerm).ToPagedList(pageNumber, 10));
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
