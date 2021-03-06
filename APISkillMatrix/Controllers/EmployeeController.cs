﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using APISkillMatrix.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedObjects.Common;
using SharedObjects.Models;
using SharedObjects.StoreProcedures;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;

namespace APISkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EmployeeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("get-all")]
        public async Task<List<VEmployee>> GetAll()
        {
            var result = await context.Query<VEmployee>().AsNoTracking().FromSql(SPEmployee.GetAll).ToListAsync();

            return result;
        }


        [HttpGet("count")]
        public async Task<int> Count()
        {
            var output = new SqlParameter
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Output
            };

            await context.Database.ExecuteSqlCommandAsync(SPEmployee.CountEmployee, output);
            var result = (int)output.Value;
            return result;

        }
        [HttpGet("countemployeewithcondition/{input}")]
        public async Task<int> CountEmployeeWithCondition(string input)
        {
            var output = new SqlParameter
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Output
            };

            await context.Database.ExecuteSqlCommandAsync(SPEmployee.CountEmployeeWithCondition, input, output);
            var result = (int)output.Value;
            return result;

        }

        [HttpPost("pagination")]
        public async Task<List<VEmployee>> GetPagination([FromBody] PaginationViewModel model)
        {
            var result = await context.Query<VEmployee>().AsNoTracking().FromSql(SPEmployee.GetEmployeePagination, model.PageIndex, model.PageSize).ToListAsync();

            return result;
        }

        [HttpPost("paginationwithcondition")]
        public async Task<List<VEmployee>> GetPaginationWithCondition([FromBody] PaginationConditionViewModel model)
        {
            var result = await context.Query<VEmployee>().AsNoTracking().FromSql(SPEmployee.GetEmployeePaginationWithCondition, model.Input, model.PageIndex, model.PageSize).ToListAsync();
            return result;
        }


        [HttpGet("searchs/{sap}")]
        public async Task<List<VSearchResult>> GetEmployeeBySAP(string sap)
        {
            var result = await context.Query<VSearchResult>().AsNoTracking().FromSql(SPEmployee.GetBySAP, sap).ToListAsync();

            return result;
        }
        [HttpGet("search/{sap}")]

        public async Task<VSearchResult> GetBySAP(string sap)
        {
            var result = await context.Query<VSearchResult>().AsNoTracking().FromSql(SPEmployee.GetBySAP, sap).FirstOrDefaultAsync();

            return result;
        }


        [HttpGet("getscore/{sap}")]
        public async Task<List<VScore>> GetScoreBySAP(string sap)
        {
            var result = await context.Query<VScore>().AsNoTracking().FromSql(SPEmployee.GetScoreBySAP, sap).ToListAsync();

            return result;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddEmployeeModel model)
        {
            try
            {
                await context.Database.ExecuteSqlCommandAsync(SPEmployee.AddEmployee, model.Sap, model.Name, model.SuperiorEmail, model.Email, model.Workcell, model.Position, model.Sector, model.Image);
                return Ok(new ResponseResult(200));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseResult(400, ex.Message));
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeModel model)
        {
            try
            {
                await context.Database.ExecuteSqlCommandAsync(SPEmployee.Update, model.Image, model.SAP);
                return Ok(new ResponseResult(200));
            }

            catch (Exception ex)
            {
                return BadRequest(new ResponseResult(400, ex.Message));

            }
        }
    }
}
