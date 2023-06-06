using GoodeBooks.Services.ServiceContracts.VolumeInfos;
using GoodeBooks.Services.ViewModels.VolumeInfos;
using Microsoft.AspNetCore.Mvc;

namespace GoodeBooks.Controllers
{
    public class VolumeInfoController : Controller
    {
        private readonly IVolumeInfoService service;

        public VolumeInfoController(IVolumeInfoService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateVolumeInfo()
        {
            return View("CreateNewVolumeInfo");
        }

        public IActionResult CreateNewVolumeInfo(VolumeInfoCreateViewModel model)
        {
            service.Create(model);
            return View(model);
        }
    }
}
