using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts.Bookshelves;
using GoodeBooks.Services.ViewModels.Bookshelves;
using GoodeBooks.Services.ViewModels.SaleInfos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View("CreateBookshelf");
        }
        public IActionResult CreateBookshelf(BookshelfCreateViewModel model)
        {
            service.Create(model);
            return View(model);
        }
        [Authorize(Roles = "Admin, User")]
        public IActionResult GetById(long id)
        {
            return View(service.GetById(id));
        }
        
        //check if user is owner
        [Authorize(Roles = "Admin, User")]
        public IActionResult Update(long id)
        {
            var bookshelf = service.GetById(id);
            return View("UpdateBookshelf", bookshelf);
        }
        [Authorize(Roles = "Admin, User")]
        public IActionResult UpdateBookshelf(BookshelfViewModel model)
        {
            var res = service.Update(model);

            return View(model);
        }
        [Authorize(Roles = "Admin, User")]
        public IActionResult Delete(long id)
        {
            return View(service.Delete(id));
        }
    }
}
