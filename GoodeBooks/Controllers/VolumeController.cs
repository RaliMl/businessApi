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

        [Authorize(Roles = "Admin,User")]
        public IActionResult Search(string searchTerm, int pageNumber = 1)
        {
            return View("GetAll", service.Search(searchTerm).ToPagedList(pageNumber, 10));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreateVolume()
        {
            string title = TempData["VolumeInfoTitle"] as string;
            string saleInfoId = TempData["SaleInfoId"] as string;
            string searchInfoId = TempData["SearchInfoId"] as string;
            VolumeCreateViewModel model;
            if (title != null)
            {
                TempData.Keep("VolumeInfoTitle");
                if (saleInfoId != null)
                {
                    TempData.Keep("SaleInfoId");
                    if (searchInfoId != null)
                    {
                        TempData.Keep("SearchInfoId");
                        model = new VolumeCreateViewModel()
                        {
                            VolumeInfotTitle = title,
                            SaleInfoId = saleInfoId,
                            SearchInfoId = searchInfoId
                        };
                    }
                    model = new VolumeCreateViewModel()
                    {
                        VolumeInfotTitle = title,
                        SaleInfoId = saleInfoId
                    };
                }
                model = new VolumeCreateViewModel()
                {
                    VolumeInfotTitle = title
                };
                return View("CreateNewVolume", model);
            }
            else return View("CreateNewVolume");
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
            var nextPage = currentPage + 1;

            return RedirectToAction("GetAll", new { pageNumber = nextPage });
        }

        public IActionResult PreviousPage(int currentPage)
        {
            var previousPage = currentPage - 1;

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
            var volume = service.GetById(id);
            
            return View("UpdateVolume", volume);
        }
        public IActionResult UpdateVolume(VolumeViewModel model) 
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
