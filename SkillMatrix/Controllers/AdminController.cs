﻿using System;
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
        private readonly IWorkCellService workCellService;
        private readonly IPositionService positionService;

        public AdminController(IAdminService adminService, ISkillMatrixService skillMatrixService, ISectorService sectorService, IWorkCellService workCellService, IPositionService positionService)
        {
            this.adminService = adminService;
            this.skillMatrixService = skillMatrixService;
            this.sectorService = sectorService;
            this.workCellService = workCellService;
            this.positionService = positionService;
        }
        [HttpPost]
        public async Task<IActionResult> GetSingleResult([FromBody] GetSingleResultViewModel model)
        {
            var result1 = await skillMatrixService.GetSingleResult(model);
            return Json(new { result = result1 });
        }
        public async Task<IActionResult> UpdateScore([FromBody] UpdateScoreViewModel model)
        {
            var result = await skillMatrixService.UpdateScore(model);
            return Json(new { statusCode = result.StatusCode });
        }
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeViewModel model)
        {
            string uniqueFileName = await UpdateImagesync(model);

            UpdateEmployeeModel Image = new UpdateEmployeeModel
            {
                //SAP = model.SAP,               
                Image = uniqueFileName,
            };
            var result = await adminService.Update(Image);
            return Json(new { statusCode = result.StatusCode });
        }
        public async Task<IActionResult> GetAll()
        {
            var employees = await adminService.GetAll();
            return View(employees);
        }

        [HttpPost]
        public async Task<IActionResult> GetEmployeeBySAP(string sap)
        {
            var users = await adminService.GetEmployeeBySAP(sap);
            return Json(new { result = users });
        }

        public async Task<IActionResult> GetBySAP(string sap)
        {
            var user = await adminService.GetBySAP(sap);

            return Json(new { result = user });
        }

        public async Task<IActionResult> GetBySAP_partialview(string sap)
        {
            var user = await adminService.GetBySAP(sap);
            return PartialView(user);
        }

        public IActionResult GetEmployeePagination()
        {
            return View();
        }

        public async Task<IActionResult> Pagination_PartialView([FromBody] PaginationViewModel model)
        {
            var employees = await adminService.GetPagination(model);
            return PartialView(employees);
        }
        [HttpPost]
        public async Task<IActionResult> GetPaginationWithCondition([FromBody] PaginationConditionViewModel model)
        {
            var employees = await adminService.GetPaginationWithCondition(model);
            return PartialView(employees);
        }
        [HttpPost]
        public async Task<IActionResult> GetSkillPagination([FromBody] PaginationConditionViewModel model)
        {
            var skills = await skillMatrixService.GetPaginationWithCondition(model);
            return PartialView(skills);
        }
        public async Task<IActionResult> Count()
        {
            var count = await adminService.Count();
            return Json(new { result = count });
        }
        [HttpPost]
        public async Task<IActionResult> CountEmployeeWithCondition(string input)
        {
            var count = await adminService.CountEmployeeWithCondition(input);
            return Json(new { result = count });
        }
        [HttpPost]
        public async Task<IActionResult> CountSkillMatrix(string input)
        {
            var count = await skillMatrixService.CountSkillMatrix(input);
            return Json(new { result = count });
        }
        public IActionResult SearchEmloyee()
        {
            return View();
        }
        public IActionResult SearchEmloyees()
        {
            return View();
        }

        public IActionResult SearchEmloyeesAndEvaluate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetSkillMatrix(string sap)
        {
            var skills = await skillMatrixService.GetSkill(sap);
            //var topics = await skillMatrixService.GetTopicByTrainerNTID("123");

            //ViewData["topics"] = topics;
            return PartialView(skills);
        }
        [HttpPost]
        public async Task<IActionResult> GetEmployeeBySAP_partialView(string sap)
        {
            var users = await adminService.GetEmployeeBySAP(sap);
            return PartialView(users);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var sectors = await sectorService.GetAll();
            var WCs = await workCellService.GetAll();
            var Positions = await positionService.GetAll();
            
            ViewData["sectors"] = sectors;
            ViewData["WCs"] = WCs;
            ViewData["Positions"] = Positions;
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
                    Position = model.Position,
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
                    foreach (var item in result.Notifications)
                    {
                        ModelState.AddModelError("", item);
                    }
                    return View(model);
                }
            }
            else
            {
                return View(model);

            }
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
        private async Task<string> UpdateImagesync(UpdateEmployeeViewModel model)
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
