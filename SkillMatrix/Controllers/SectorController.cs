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
    }
}
