using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts.Volumes;
using GoodeBooks.Services.ViewModels.Volumes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding;

namespace GoodeBooks.Controllers
{
    public class VolumeController : Controller 
    {
        private readonly IVolumeService service;
        private readonly BookstoreDbContext context;

        public VolumeController(IVolumeService service, BookstoreDbContext context)
        {
            this.service = service;
            this.context = context;
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

        public IActionResult Update(string id)
        {
            Volume volume = context.Volumes.FirstOrDefault(x => x.Id == id);
            VolumeUpdateViewModel updateModel = new VolumeUpdateViewModel() { Id = volume.Id, SaleInfoId =  volume.SaleInfo.Id, 
                SearchInfoId = volume.SearchInfo.Id, VolumeInfoId = volume.VolumeInfo.Id };
            return View("UpdateVolume", updateModel);
        }
        public IActionResult UpdateVolume(VolumeUpdateViewModel model) 
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
