using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using SharedObjects.Models;

namespace SkillMatrix.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;
        private readonly ISkillMatrixService skillMatrixService;
        private readonly ISectorService sectorService;

        public AdminController(IAdminService adminService, ISkillMatrixService skillMatrixService, ISectorService sectorService)
        {
            this.adminService = adminService;
            this.skillMatrixService = skillMatrixService;
            this.sectorService = sectorService;
        }
        public async Task<IActionResult> GetAll()
        {

            var employees = await adminService.GetAll();
            return View(employees);
        }
        public IActionResult GetEmployeePagination()
        {
            return View();
        }
        public async Task<IActionResult> Pagination_PartialView([FromBody] PaginationViewModel model)
        {
            var articles = await adminService.GetPagination(model);
            return PartialView(articles);

        }
        public async Task<IActionResult> Count()
        {
            var count = await adminService.Count();
            return Json(new { result = count });
        }
        public IActionResult SearchEmloyee()
        {
            return View();
        }

        public async Task<IActionResult> GetBySAP(string sap)
        {
            var users = await adminService.GetBySAP(sap);
            return Json(new { result = users });
        }

        [HttpPost]

        public async Task<IActionResult> GetSkillMatrix(string sap)
        {

            var skills = await skillMatrixService.GetSkill(sap);
            //return Json(new { result = skills });

            return PartialView(skills);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var sectors = await sectorService.GetAll();
            ViewData["sectors"] = sectors;
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = await UploadedFileAsync(model);

                AddEmployeeModel employee = new AddEmployeeModel
                {
                    Sap = model.Sap,
                    Name = model.Name,
                    SuperiorEmail = model.SuperiorEmail,
                    Email = model.Email,
                    Workcell = model.Workcell,
                    Position=model.Position,
                    Sector = model.Sector,
                    Image = uniqueFileName,
                };
                var result = await adminService.Add(employee);
                if (result.StatusCode == 200)
                {
                    //await SendEmail();
                    return Redirect("/admin/GetAll");
                    //return Redirect("http://vnhcmm0teapp02/imageapp");
                }
                else
                {

                    return View(model);
                }
            }
            return View(model);
        }

        private async Task<string> UploadedFileAsync(AddEmployeeViewModel model)
        {
            string fileName;
            try
            {
                var extension = "." + model.Image.FileName.Split('.')[model.Image.FileName.Split('.').Length - 1];
                fileName = Guid.NewGuid().ToString() + extension; //Create a new Name for the file due to security reasons.
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                //var path = Path.Combine(Directory.GetCurrentDirectory(), "C:\\inetpub\\wwwroot\\ImageASPNETCore\\publish\\wwwroot\\images", fileName);


                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await model.Image.CopyToAsync(bits);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return fileName;
        }

   

    }
}
