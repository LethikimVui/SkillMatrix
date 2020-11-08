using Newtonsoft.Json;
using Services.Interfaces;
using SharedObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class SkillMatrixService : BaseService, ISkillMatrixService
    {
        public async Task<List<VSkillMatrix>> GetSkill(string sap)
        {
            List<VSkillMatrix> skillmatrix = new List<VSkillMatrix>();

            using (var response = await httpClient.GetAsync("api/SkilMatrix/getskill/" + sap))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                skillmatrix = JsonConvert.DeserializeObject<List<VSkillMatrix>>(apiResponse);
            }
            return skillmatrix;
        }
    }
}
