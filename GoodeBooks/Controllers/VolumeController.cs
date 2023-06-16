using GoodeBooks.Database;
using GoodeBooks.Database.Migrations;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts.Volumes;
using GoodeBooks.Services.ViewModels.Volumes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding;
using PagedList;

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
        [Authorize(Roles = "Admin")]
        public IActionResult CreateVolume()
        {
            return View("CreateNewVolume");
        }
        public IActionResult CreateNewVolume(VolumeCreateViewModel model) 
        { 
            var res = service.Create(model);

            return View(model);
        }
        [Authorize(Roles = "Admin, User")]
        public IActionResult GetById(string id)
        {
            return View(service.GetById(id));
        }
        [Authorize(Roles = "Admin, User")]
        public IActionResult GetAll(int pageNumber = 1)
        {
            var volumes = service.GetAll();
            return View(volumes.ToPagedList(pageNumber, 10));
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

        public IActionResult AddToBookshelf(string volumeId, int bookshelfId)
        {
            service.AddToBookshelf(volumeId, bookshelfId);

            return View();
        }

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string id)
        {
            return View(service.Delete(id));
        }
    }
}
