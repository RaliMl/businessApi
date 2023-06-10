using GoodeBooks.Services.ServiceContracts.VolumeInfos;
using GoodeBooks.Services.ViewModels.SearchInfos;
using GoodeBooks.Services.ViewModels.VolumeInfos;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin")]
        public IActionResult CreateVolumeInfo()
        {
            if (!User.IsInRole("Admin"))
            {
                return RedirectToPage("/Account/AccessDenied");
            }
            return View("CreateNewVolumeInfo");
        }

        public IActionResult CreateNewVolumeInfo(VolumeInfoCreateViewModel model)
        {
            service.Create(model);
            return View(model);
        }
        [Authorize(Roles = "Admin, User")]
        public IActionResult GetById(string id)
        {
            return View(service.GetById(id));
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Update(string id)
        {
            var volumeInfo = service.GetById(id);
            return View("UpdateVolumeInfo", volumeInfo);
        }
        public IActionResult UpdateVolumeInfo(VolumeInfoViewModel model)
        {
            var res = service.Update(model);

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string id)
        {
            return View(service.Delete(id));
        }
    }
}
