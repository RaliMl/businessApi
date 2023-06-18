using GoodeBooks.Services.ServiceContracts.StarRate;
using GoodeBooks.Services.ServiceContracts.Volumes;
using GoodeBooks.Services.ViewModels.StarRate;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GoodeBooks.Controllers
{
    public class StarRateController : Controller
    {
        private readonly IStarRateService service;

        public StarRateController(IStarRateService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddRate(string volumeTitle, int rate)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            StarRateCreateViewModel model = new StarRateCreateViewModel()
            {
                UserId = userId,
                VolumeTitle = volumeTitle,
                Rate = rate
            };

            service.AddRating(model);

            return Redirect("/Volume/GetAll/");
        }
    }
}
