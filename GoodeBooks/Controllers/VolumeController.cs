using GoodeBooks.Services.ServiceContracts.Volumes;
using GoodeBooks.Services.ViewModels.Volumes;
using Microsoft.AspNetCore.Mvc;

namespace GoodeBooks.Controllers
{
    public class VolumeController : Controller 
    {
        private readonly IVolumeService service;

        public VolumeController(IVolumeService service)
        {
            this.service = service;
        }

        public IActionResult CreateVolume()
        {
            return View("CreateVolume");
        }
        public IActionResult CreateNewVolume(VolumeCreateViewModel model) 
        { 
            var res = service.Create(model);

            return View(model);
        }
    }
}
