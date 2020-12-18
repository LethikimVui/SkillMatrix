using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISkillMatrix.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedObjects.Common;
using SharedObjects.StoreProcedures;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;

namespace APISkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public SectorController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("get-all")]
        public async Task<List<VSector>> GetAll()
        {
            var result = await context.Query<VSector>().AsNoTracking().FromSql(SPSector.GetAll).ToListAsync();

            return result;
        }
        [HttpGet("get-all-not-active")]
        public async Task<List<VSector>> GetAllNotActive()
        {
            var result = await context.Query<VSector>().AsNoTracking().FromSql(SPSector.GetAllNotActive).ToListAsync();

            return result;
        }
        [HttpGet("search/{sector}")]
        public async Task<VSector> FindSector(string sector)
        {
            var result = await context.Query<VSector>().AsNoTracking().FromSql(SPSector.FindSector, sector).FirstOrDefaultAsync();

            return result;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddSectorViewModel model)
        {
            try
            {
                await context.Database.ExecuteSqlCommandAsync(SPSector.AddSector, model.Sector);
                return Ok(new ResponseResult(200));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseResult(400, ex.Message));
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await context.Database.ExecuteSqlCommandAsync(SPSector.Delete, id);
                return Ok(new ResponseResult(200));
            }

            catch (Exception ex)
            {
                return BadRequest(new ResponseResult(400, ex.Message));

            }
        }
        [HttpDelete("recover/{id}")]

        public async Task<IActionResult> Recover(int id)
        {
            try
            {
                await context.Database.ExecuteSqlCommandAsync(SPSector.Recover, id);
                return Ok(new ResponseResult(200));
            }

            catch (Exception ex)
            {
                return BadRequest(new ResponseResult(400, ex.Message));

            }
        }
    }
}
