using GoodeBooks.Services.ServiceContracts.Volumes;
using GoodeBooks.Services.ViewModels.Volumes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding;

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
            return View("CreateNewVolume");
        }
        public IActionResult CreateNewVolume(VolumeCreateViewModel model) 
        { 
            var res = service.Create(model);

            return View(model);
        }
        public IActionResult GetById(string id)
        {
            return View(service.GetById(id));
        }

        public IActionResult UpdateVolume()
        {
            return View("Update");
        }
        public IActionResult Update(string id, VolumeUpdateViewModel model) 
        {
            var res = service.Update(id, model);

            return View(model);
        }
        public IActionResult Delete(string id)
        {
            return View(service.Delete(id));
        }
    }
}
