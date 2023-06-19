using GoodeBooks.Services.ServiceContracts.VolumeInfos;
using GoodeBooks.Services.ViewModels.SearchInfos;
using GoodeBooks.Services.ViewModels.VolumeInfos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using System.Text;

namespace GoodeBooks.Controllers
{
    public class VolumeInfoController : Controller
    {
        private readonly IVolumeInfoService service;
        private readonly StringBuilder stringBuilder;

        private VolumeInfoCreateViewModel model;

        public VolumeInfoController(IVolumeInfoService service, StringBuilder stringBuilder)
        {
            this.service = service;
            this.stringBuilder = stringBuilder;
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

            string authorsNames = TempData["AuthorsNames"] as string;

            if (authorsNames != null)
            {
                var model = new VolumeInfoCreateViewModel
                {
                    Authors = authorsNames
                };


                return View("CreateNewVolumeInfo", model);
            }
            else
                return View("CreateNewVolumeInfo");
        }

        public IActionResult CreateNewVolumeInfo(VolumeInfoCreateViewModel model)
        {
            //model.Authors = new List<string>();
            //model.Authors.Add(TempData["AuthorsName"] as string);

            service.Create(model);
            TempData["VolumeInfoTitle"] = model.Title;
            TempData.Keep("VolumeInfoTitle");
            return Redirect("/Volume/CreateVolume");//View(model);
        }
        [Authorize(Roles = "Admin, User")]
        public IActionResult GetById(string id)
        {
            return View(service.GetById(id));
        }

        public IActionResult GetAll(int pageNumber = 1)
        {
            return View(service.GetAll().ToPagedList(pageNumber, 10));
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
