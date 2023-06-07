using GoodeBooks.Services.ServiceContracts.VolumeInfos;
using GoodeBooks.Services.ViewModels.SearchInfos;
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
        public IActionResult GetById(string id)
        {
            return View(service.GetById(id));
        }
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
        public IActionResult Delete(string id)
        {
            return View(service.Delete(id));
        }
    }
}
