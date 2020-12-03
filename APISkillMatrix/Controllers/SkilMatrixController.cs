using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISkillMatrix.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedObjects.StoreProcedures;
using SharedObjects.ValueObjects;

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
    }
}
