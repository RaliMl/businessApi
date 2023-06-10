using GoodeBooks.Database;
using GoodeBooks.Services.ServiceContracts;
using GoodeBooks.Services.ServiceContracts.Volumes;
using Microsoft.AspNetCore.Mvc;

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

        //public IActionResult GiveRole()
        //{

        //}
    }
}
