using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using SharedObjects.ViewModels;

namespace SkillMatrix.Controllers
{
    public class SectorController : Controller
    {
        private readonly ISectorService sectorService;

        public SectorController(ISectorService sectorService)
        {
            this.sectorService = sectorService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([FromBody] AddSectorViewModel model)
        {
            var result = await sectorService.Add(model);
            return Json(new { statusCode = result.StatusCode });         
        }
        public async Task<IActionResult> FindSector(string sectorName)
        {
            var sectors = await sectorService.FindSector(sectorName);
            return Json(new { result = sectors });
        }
        public async Task<IActionResult> GetAll()
        {
            var sectors = await sectorService.GetAll();
            return PartialView(sectors);
        }

        public async Task<IActionResult> GetAllNotActive()
        {
            var sectors = await sectorService.GetAllNotActive();
            return PartialView(sectors);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await sectorService.Delete(id);
            return Json(new { statusCode = result.StatusCode });
        }

        public async Task<IActionResult> Recover(int id)
        {
            var result = await sectorService.Recover(id);
            return Json(new { statusCode = result.StatusCode });
        }
    }
}
