using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts.Bookshelves;
using GoodeBooks.Services.ViewModels.Bookshelves;
using GoodeBooks.Services.ViewModels.SaleInfos;
using Google.Apis.Books.v1.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using System.Security.Claims;

namespace GoodeBooks.Controllers
{
    public class BookshelfController : Controller
    {
        private readonly IBookshelfService service;
        private readonly BookstoreDbContext context;

        public BookshelfController(IBookshelfService service, BookstoreDbContext context)
        {
            this.service = service;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin, User")]
        public IActionResult Create()
        {
            return View("CreateBookshelf");
        }
        public IActionResult CreateBookshelf(BookshelfCreateViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            service.Create(model, userId);
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult GetById(long id)
        {
            return View(service.GetById(id));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult GetAll (int pageNumber = 1)
        {
            return View(service.GetAll().ToPagedList(pageNumber, 10));
        }

        [Authorize(Roles = "User")]
        public IActionResult GetInformation(long id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = context.Users.FirstOrDefault(x => x.Id == userId);
            if (user.Bookshelves.Select(x => x.Id).Contains(id))
            {
                return View(service.GetById(id));
            }
            return Forbid();
        }
        
        [Authorize(Roles = "Admin")]
        public IActionResult Update(long id)
        {
            var bookshelf = service.GetById(id);
            return View("UpdateBookshelf", bookshelf);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateBookshelf(BookshelfViewModel model)
        {
            var res = service.Update(model);

            return View(model);
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

        [Authorize(Roles = "User")]
        public IActionResult UpdateMyBookshelf (int pageNumber = 1)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var bookshelves = service.GetAll(userId);

            return View("UserBookshelvesTableView", bookshelves.ToPagedList(pageNumber, 10));
        }
        [Authorize(Roles = "User")]
        public IActionResult UpdateUserBookshelf(BookshelfViewModel model)
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
