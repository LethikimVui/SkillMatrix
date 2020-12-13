using System;
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
using SharedObjects.StoreProcedures;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;

namespace APISkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkilMatrixController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public SkilMatrixController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet("gettopicbyntid/{sap}")]
        public async Task<List<VTopicByTrainer>> GetTopicByTrainerNTID(string sap)
        {
        var result = await context.Query<VTopicByTrainer>().AsNoTracking().FromSql(SPSkillMatrix.GetTopicByTrainerNTID, sap).ToListAsync();

            return result;
        }

        [HttpGet("getskill/{sap}")]
        public async Task<List<VSkillMatrix>> GetSkill(string sap)
        {
            var result = await context.Query<VSkillMatrix>().AsNoTracking().FromSql(SPSkillMatrix.SkillMatrix, sap).ToListAsync();

            return result;
        }
        [HttpGet("countskillmatrix/{input}")]
        public async Task<int> CountSkillMatrix(string input)
        {
            var output = new SqlParameter
            {
                DbType = DbType.Int32,
                Direction = ParameterDirection.Output
            };

            await context.Database.ExecuteSqlCommandAsync(SPSkillMatrix.CountSkillMatrix, input, output);
            var result = (int)output.Value;
            return result;

        }
        [HttpPost("pagination")]
        public async Task<List<VSkillMatrix>> GetPaginationWithCondition([FromBody] PaginationConditionViewModel model)
        {
            var result = await context.Query<VSkillMatrix>().AsNoTracking().FromSql(SPSkillMatrix.GetSkillMatrixPagination, model.Input, model.PageIndex, model.PageSize).ToListAsync();
            return result;
        }

        [HttpPost("updatescore")]
        public async Task<IActionResult> UpdateScore([FromBody] UpdateScoreViewModel model)
        {
           {
                try
                {
                    await context.Database.ExecuteSqlCommandAsync(SPSkillMatrix.UpdateScore, model.Id, model.Sap, model.EvalScore, model.AssesScore);
                    return Ok(new ResponseResult(200));
                }

                catch (Exception ex)
                {
                    return BadRequest(new ResponseResult(400, ex.Message));
                }
            }
        }
        [HttpGet("getsingleresult")]
        public async Task<VResult> GetSingleResult([FromBody] GetSingleResultViewModel model)
        {
            var result = await context.Query<VResult>().AsNoTracking().FromSql(SPSkillMatrix.GetSingleResult, model.NTID, model.TopicId).FirstOrDefaultAsync();
            return result;
        }
    }
}
