using GoodeBooks.Services.ServiceContracts.Bookshelves;
using GoodeBooks.Services.ViewModels.Bookshelves;
using GoodeBooks.Services.ViewModels.SaleInfos;
using Microsoft.AspNetCore.Mvc;

namespace GoodeBooks.Controllers
{
    public class BookshelfController : Controller
    {
        private readonly IBookshelfService service;

        public BookshelfController(IBookshelfService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View("CreateBookshelf");
        }
        public IActionResult CreateBookshelf(BookshelfCreateViewModel model)
        {
            service.Create(model);
            return View(model);
        }
        public IActionResult GetById(long id)
        {
            return View(service.GetById(id));
        }
        public IActionResult Update(long id)
        {
            var bookshelf = service.GetById(id);
            return View("UpdateBookshelf", bookshelf);
        }
        public IActionResult UpdateBookshelf(BookshelfViewModel model)
        {
            var res = service.Update(model);

            return View(model);
        }
        public IActionResult Delete(long id)
        {
            return View(service.Delete(id));
        }
    }
}
