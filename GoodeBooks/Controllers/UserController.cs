using GoodeBooks.Database;
using GoodeBooks.Services.ServiceContracts;
using GoodeBooks.Services.ViewModels.Users;
using GoodeBooks.Services.ViewModels.VolumeInfos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using System.Security.Claims;

namespace GoodeBooks.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService service;
        private readonly BookstoreDbContext context;

        public UserController(IUserService service, BookstoreDbContext context)
        {
            this.service = service;
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View("CreateUser");
        }
        public IActionResult CreateUser(UserCreateViewModel model) 
        {
            var res = service.Create(model);

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Assign()
        {
            return View("AssignBookshelf");
        }
        public IActionResult AssignBookshelf(UserBookshelfIdsViewModel model)
        {
            var res = service.AssignBookshelf(model);

            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult GetById(string id)
        {
            return View(service.GetById(id));
        }
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin,User")]
        public IActionResult GetInformation()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(service.GetById(userId));
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string id)
        {
            return View(service.Delete(id));
        }
        [Authorize(Roles = "User")]
        public IActionResult DeleteMyAccount()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(service.Delete(userId));
        
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Update(string id)
        {
            var user = service.GetById(id);
            return View("UpdateUser", user);
        }
        public IActionResult UpdateUser(UserViewModel model)
        {
            var res = service.Update(model);

            return View(model);
        }
        [Authorize(Roles = "User")]
        public IActionResult UpdateMyAccount()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = service.GetById(userId);

            return View("UpdateMyUserAccount", user);
        }
        public IActionResult UpdateMyUserAccount(UserViewModel model)
        {
            var res = service.Update(model);

            return View(model);
        }
    }
}
